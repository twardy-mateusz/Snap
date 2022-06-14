using SnapTheGame.Enums;

namespace SnapTheGame.Models
{
    /// <summary>
    /// The card
    /// </summary>
    internal class Card
    {
        /// <summary>
        /// Card's Rank
        /// </summary>
        internal Rank Rank { get; set; }

        /// <summary>
        /// Card's Suit
        /// </summary>
        internal Suit Suit { get; set; }

        /// <summary>
        /// Describes if a card is facing upwards
        /// </summary>
        internal bool FaceUp { get; set; }

        /// <summary>
        /// Creates a new Card with specified rank and suit.
        /// </summary>
        /// <param name="rank"></param>
        /// <param name="suit"></param>
        internal Card(Rank rank, Suit suit)
        {
            Rank = rank;
            Suit = suit;
        }

        /// <summary>
        /// Flips the card and changes its visible side
        /// </summary>
        internal void Flip()
        {
            FaceUp = !FaceUp;
        }

        /// <summary>
        /// Returns a text representation of card's suit and rank
        /// </summary>
        public override string ToString()
        {
            return $"{Suit} {Rank}";
        }        
    }
}
