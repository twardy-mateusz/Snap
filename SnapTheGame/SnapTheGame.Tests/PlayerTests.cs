using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnapTheGame.Models;

namespace SnapTheGame.Tests
{
    [TestClass]
    public class PlayerTests
    {
        private const string TestPlayerName = "Test Player";

        [TestMethod]
        public void FlipTopCard_Test()
        {
            Player player = new Player(TestPlayerName);
            Deck deck = new Deck();
            player.Cards = deck.Cards;
            player.FlipTopCard();

            Assert.IsNotNull(player.TopFlippedCard);
            Assert.IsTrue(player.FlippedCards.Count == 1);
        }

        [TestMethod]
        public void ReuseFlippedCards_Test()
        {
            Player player = new Player(TestPlayerName);
            Deck deck = new Deck();
            player.Cards = deck.Cards;
            player.FlipTopCard();
            player.ReuseFlippedCards(false);

            Assert.IsFalse(player.TopFlippedCard.FaceUp);
        }

        [TestMethod]
        public void ReuseFlippedCardsExclude_Test()
        {
            Player player = new Player(TestPlayerName);
            Deck deck = new Deck();
            player.Cards = deck.Cards;
            player.FlipTopCard();
            player.ReuseFlippedCards(true);

            Assert.IsTrue(player.TopFlippedCard.FaceUp);
        }
    }
}
