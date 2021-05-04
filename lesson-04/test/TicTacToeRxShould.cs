using NUnit.Framework;
using src;
using System;
using System.Reactive.Linq;

using static src.Player;
using static src.Position;

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
            Player currentPlayer = None;
            _ticTacToeRx.CurrentPlayer.Subscribe(player => currentPlayer = player);

            _ticTacToeRx.RequestCurrentPlayer();


            Assert.AreEqual(X, currentPlayer);
        }

        [Test]
        public void SecondPlayerIsPlayerO()
        {
            Player currentPlayer = None;
            _ticTacToeRx.CurrentPlayer.Subscribe(player => currentPlayer = player);

            _ticTacToeRx.Place(TopLeft);

            Assert.AreEqual(O, currentPlayer);
        }

        [Test]
        public void ThirdPlayerIsPlayerX()
        {
            Player currentPlayer = None;
            _ticTacToeRx.CurrentPlayer.Subscribe(player => currentPlayer = player);

            _ticTacToeRx.Place(TopLeft);
            _ticTacToeRx.Place(TopMiddle);


            Assert.AreEqual(X, currentPlayer);
        }

        [Test]
        public void NotHaveAWinnerAtStart()
        {
            Player winner = X;
            _ticTacToeRx.Winner.Subscribe(wnr => winner = wnr);

            _ticTacToeRx.RequestWinner();

            Assert.AreEqual(None, winner);
        }
    }
}