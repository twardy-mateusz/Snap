using SnapTheGame.Enums;
using System;

namespace SnapTheGame.Models
{
    /// <summary>
    /// The deck of cards
    /// </summary>
    internal class Deck
    {
        /// <summary>
        /// All available cards
        /// </summary>
        internal readonly Cards Cards;

        internal Deck()
        {
            Cards = new Cards();

            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    Cards.Add(new Card(rank, suit));
                }
            }
        }

        /// <summary>
        /// Shuffles the deck
        /// </summary>
        internal void ShuffleDeck()
        {
            Random random = new Random();

            for (int n = Cards.Count - 1; n > 0; --n)
            {
                int k = random.Next(n + 1);
                Card temp = Cards[n];
                Cards[n] = Cards[k];
                Cards[k] = temp;                
            }
        }
    }
}
