using System;

namespace SnapTheGame.Models
{
    /// <summary>
    /// The player
    /// </summary>
    internal class Player
    {
        /// <summary>
        /// Player's name
        /// </summary>
        internal string Name { get; set; }

        /// <summary>
        /// Collection of players cards facing downwards
        /// </summary>
        internal Cards Cards { get; set; }

        /// <summary>
        /// Collection of players cards facing upwards
        /// </summary>
        internal Cards FlippedCards { get; set; }

        /// <summary>
        /// Player's most recently flipped card
        /// </summary>
        internal Card TopFlippedCard { get; set; }

        /// <summary>
        /// Describes if the player holds any downwards facing cards
        /// </summary>
        internal bool HasCards => Cards.Count > 0;

        /// <summary>
        /// Describes if the player holds any upward facing cards
        /// </summary>
        internal bool HasFlippedCards => FlippedCards.Count > 0;

        /// <summary>
        /// Total number of cards held by the player
        /// </summary>
        internal int Score => Cards.Count + FlippedCards.Count;

        internal Player(string name)
        {
            Name = name;
            Cards = new Cards();
            FlippedCards = new Cards();
        }

        /// <summary>
        /// Moves a card from players cards pile to players flipped cards pile
        /// </summary>
        internal void FlipTopCard()
        {
            var topCard = Cards[0];
            topCard.Flip();

            Cards.Remove(topCard);
            FlippedCards.Add(topCard);
            TopFlippedCard = topCard;
        }

        /// <summary>
        /// Flips all cards or all but the top card in the flipped cards pile to face downwards
        /// </summary>
        internal void ReuseFlippedCards(bool excludeTopCard)
        {
            foreach (var card in FlippedCards)
            {
                if (excludeTopCard)
                {
                    if (card != TopFlippedCard)
                    {
                        card.Flip();
                    }
                }
                else
                {
                    card.Flip();
                }                             
            }
        }
    }
}
