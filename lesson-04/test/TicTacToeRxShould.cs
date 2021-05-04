using NUnit.Framework;
using src;
using System;
using System.Reactive.Linq;

namespace test
{
    [TestFixture]
    public class TicTacToeRxShould
    {
        private TicTacToeRx _ticTacToeRx;

        [SetUp]
        public void SetUp()
        {
            _ticTacToeRx = new TicTacToeRx();
        }

        [Test]
        public void FirstPlayerIsPlayerX()
        {
            Player currentPlayer = Player.None;
            _ticTacToeRx.CurrentPlayer.Subscribe(player => currentPlayer = player);

            _ticTacToeRx.RequestCurrentPlayer();


            Assert.AreEqual(Player.X, currentPlayer);
        }

        [Test]
        public void SecondPlayerIsPlayerO()
        {
            Player currentPlayer = Player.None;
            _ticTacToeRx.CurrentPlayer.Subscribe(player => currentPlayer = player);

            _ticTacToeRx.Place(Position.TopLeft);

            Assert.AreEqual(Player.O, currentPlayer);
        }
    }
}