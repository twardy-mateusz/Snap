using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SnapTheGame.Tests
{
    [TestClass]
    public class SnapLogicTests
    {
        private const string TestPlayerName = "Test Player";

        [TestMethod]
        public void SnapLogic_Test()
        {            
            var snapLogic = new SnapLogic(TestPlayerName);

            Assert.AreEqual(TestPlayerName, snapLogic.Player.Name);
        }

        [TestMethod]
        public void DealCards_Test()
        {
            var snapLogic = new SnapLogic(TestPlayerName);
            snapLogic.Deck = new Models.Deck();
            snapLogic.DealCards();

            Assert.IsNull(snapLogic.Deck);
            Assert.IsTrue(snapLogic.Player.Cards.Count == 26);
        }

        [TestMethod]
        public void CompareCards_Test()
        {
            var snapLogic = new SnapLogic(TestPlayerName);
            var aceCard = new Models.Card(Enums.Rank.Ace, Enums.Suit.Spade);            

            snapLogic.Player.TopFlippedCard = aceCard;
            snapLogic.Kenny.TopFlippedCard = aceCard;

            var positiveResult = snapLogic.CompareCards();
            Assert.IsTrue(positiveResult);

            var queenCard = new Models.Card(Enums.Rank.Queen, Enums.Suit.Spade);
            snapLogic.Kenny.TopFlippedCard = queenCard;

            var negativeResult = snapLogic.CompareCards();
            Assert.IsFalse(negativeResult);
        }

        [TestMethod]
        public void PlayerMove_Test()
        {
            var snapLogic = new SnapLogic(TestPlayerName);
            snapLogic.Deck = new Models.Deck();
            snapLogic.DealCards();
            snapLogic.CurrentPlayer = snapLogic.Player;
            snapLogic.PlayerMove();

            Assert.IsNotNull(snapLogic.Player.TopFlippedCard);
            Assert.IsTrue(snapLogic.Player.FlippedCards.Count == 1);
        }

        [TestMethod]
        public void MoveCards_Test()
        {
            var snapLogic = new SnapLogic(TestPlayerName);
            snapLogic.Deck = new Models.Deck();
            snapLogic.DealCards();
            snapLogic.CurrentPlayer = snapLogic.Kenny;
            snapLogic.PlayerMove();
            snapLogic.MoveCards(snapLogic.Player, snapLogic.Kenny, false);

            Assert.IsTrue(snapLogic.Kenny.FlippedCards.Count == 0);
        }

        [TestMethod]
        public void MoveCardsExclude_Test()
        {
            var snapLogic = new SnapLogic(TestPlayerName);
            snapLogic.Deck = new Models.Deck();
            snapLogic.DealCards();
            snapLogic.CurrentPlayer = snapLogic.Kenny;
            snapLogic.PlayerMove();
            snapLogic.PlayerMove();
            snapLogic.MoveCards(snapLogic.Player, snapLogic.Kenny, true);

            Assert.IsTrue(snapLogic.Kenny.FlippedCards.Count == 1);
        }

        [TestMethod]
        public void NextPlayer_Test()
        {
            var snapLogic = new SnapLogic(TestPlayerName);
            snapLogic.CurrentPlayer = snapLogic.Kenny;
            snapLogic.NextPlayer();

            Assert.IsTrue(snapLogic.CurrentPlayer == snapLogic.Player);
        }
    }
}
