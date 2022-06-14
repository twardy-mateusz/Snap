using SnapTheGame.Models;
using System;
using System.Linq;
using System.Threading;

namespace SnapTheGame
{
    /// <summary>
    /// The logic required to play the Snap! game
    /// </summary>
    public class SnapLogic
    {
        internal Deck Deck;
        internal Player CurrentPlayer;
        internal readonly Player Kenny;
        internal readonly Player Player;

        internal SnapLogic(string playerName)
        {
            Player = new Player(playerName);
            Kenny = new Player(KennysVoice.Kenny);            
        }

        /// <summary>
        /// Starts the game
        /// </summary>
        internal void StartGame()
        {            
            CurrentPlayer = Player;

            Console.WriteLine(KennysVoice.NewDeckMessage);
            Deck = new Deck();

            Console.WriteLine(KennysVoice.AttentionMessage);
            Deck.ShuffleDeck();
            Console.WriteLine(KennysVoice.ShuffledMessage);

            DealCards();
            GameOn();
        }

        /// <summary>
        /// Deals the cards evenly between the player and Kenny
        /// </summary>
        internal void DealCards()
        {
            var index = 1;

            foreach (var item in Deck.Cards)
            {
                if ((index % 2) == 0)
                {
                    Player.Cards.Add(item);
                }
                else
                {
                    Kenny.Cards.Add(item);
                }

                index++;
            }

            Deck = null;
        }

        /// <summary>
        /// The main game logic
        /// </summary>
        private void GameOn()
        {
            Random random = new Random();

            while (Player.Score != 0 && Kenny.Score != 0)
            {
                if (CurrentPlayer == Player)
                {
                    Console.WriteLine($"{KennysVoice.PlayersTurn}{CurrentPlayer.Name}");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine($"{KennysVoice.KennysTurn}");
                }

                PlayerMove();

                if (CompareCards())
                {
                    bool playerWasFirst = false;
                    int seconds = 1;                    

                    while (true)
                    {
                        if (Console.KeyAvailable)
                        {
                            if (Console.ReadKey(true).Key == ConsoleKey.Spacebar)
                            {
                                CallSnap(Player.Name);
                                playerWasFirst = true;
                                break;
                            }
                        }

                        Thread.Sleep(500);

                        if (seconds++ > random.Next(1, 3))
                        {
                            Console.WriteLine(seconds);
                            CallSnap(Kenny.Name);
                            break;
                        }
                    }

                    if (playerWasFirst)
                    {
                        MoveCards(Player, Kenny, false);
                    }
                    else
                    {
                        MoveCards(Kenny, Player, false);
                    }

                    Kenny.TopFlippedCard = null;
                    Player.TopFlippedCard = null;

                    AnnounceScore();
                }                
                
                NextPlayer();
                ReuseCards();
            }

            AnnounceWinner();            
        }

        /// <summary>
        /// Performs the current player's move
        /// </summary>
        internal void PlayerMove()
        {
            CurrentPlayer.FlipTopCard();

            Console.WriteLine($"{CurrentPlayer.Name}'s card is {CurrentPlayer.TopFlippedCard}");
        }

        /// <summary>
        /// Checks if cards have the same rank
        /// </summary>
        /// <returns></returns>
        internal bool CompareCards()
        {        
            if (Player.TopFlippedCard?.Rank == Kenny.TopFlippedCard?.Rank)
            {
                return true;
            }

            return false;
        }        

        /// <summary>
        /// Moves cards from flipped cards pile to cards pile
        /// </summary>
        /// <param name="to"></param>
        /// <param name="from"></param>
        internal void MoveCards(Player to, Player from, bool excludeTopCard)
        {
            from.ReuseFlippedCards(excludeTopCard);
            to.Cards.AddRange(from.FlippedCards.Where(flippedCard => !flippedCard.FaceUp));
            from.FlippedCards.RemoveAll(flippedCard => !flippedCard.FaceUp);
        }

        /// <summary>
        /// Announces the current score
        /// </summary>
        private void AnnounceScore()
        {
            Console.WriteLine(KennysVoice.Separator);
            Console.WriteLine($" The current score is: ");
            Console.WriteLine($"{Kenny.Name}: {Kenny.Score} {Player.Name}: {Player.Score} ");
            Console.WriteLine(KennysVoice.Separator);
        }

        /// <summary>
        /// Decides who's turn it is
        /// </summary>
        internal void NextPlayer()
        {
            CurrentPlayer = CurrentPlayer == Player ? Kenny : Player;
        }

        /// <summary>
        /// Moves cards back from a flipped pile to a card pile if a player has run out of cards to play
        /// </summary>
        private void ReuseCards()
        {
            if (!CurrentPlayer.HasCards && CurrentPlayer.HasFlippedCards)
            {
                MoveCards(CurrentPlayer, CurrentPlayer, true);
            }
        }

        private void CallSnap(string playerName)
        {
            Console.WriteLine($" {playerName}: SNAP! ");
        }

        private void AnnounceWinner()
        {
            Console.WriteLine(Player.HasCards ? KennysVoice.PlayerWinsMessage : KennysVoice.KennyWinsMessage);            
            Console.ReadLine();
        }
    }
}
