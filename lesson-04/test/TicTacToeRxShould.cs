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

        [Test]
        public void MakeXWinWhenTopRowContainsAllXs()
        {
            Player winner = X;
            _ticTacToeRx.Winner.Subscribe(wnr => winner = wnr);

            _ticTacToeRx.Place(TopLeft);
            _ticTacToeRx.Place(BottomLeft);
            _ticTacToeRx.Place(TopMiddle);
            _ticTacToeRx.Place(BottomMiddle);
            _ticTacToeRx.Place(TopRight);

            _ticTacToeRx.RequestWinner();

            Assert.AreEqual(X, winner);
        }


        [Test]
        public void MakeOWinWhenTopRowContainsAllOs()
        {
            Player winner = X;
            _ticTacToeRx.Winner.Subscribe(wnr => winner = wnr);

            _ticTacToeRx.Place(MiddleMiddle);
            _ticTacToeRx.Place(TopLeft);
            _ticTacToeRx.Place(BottomLeft);
            _ticTacToeRx.Place(TopMiddle);
            _ticTacToeRx.Place(BottomMiddle);
            _ticTacToeRx.Place(TopRight);

            _ticTacToeRx.RequestWinner();

            Assert.AreEqual(O, winner);
        }

        [Test]
        public void MakeXWinWhenMiddleRowContainsAllXs()
        {
            Player winner = X;
            _ticTacToeRx.Winner.Subscribe(wnr => winner = wnr);

            _ticTacToeRx.Place(MiddleMiddle);
            _ticTacToeRx.Place(TopLeft);
            _ticTacToeRx.Place(MiddleLeft);
            _ticTacToeRx.Place(TopMiddle);
            _ticTacToeRx.Place(MiddleRight);

            _ticTacToeRx.RequestWinner();

            Assert.AreEqual(X, winner);
        }

        [Test]
        public void MakeNoWinnerWhenBoardFull()
        {
            Player winner = X;
            _ticTacToeRx.Winner.Subscribe(wnr => winner = wnr);

            _ticTacToeRx.Place(TopRight); // X
            _ticTacToeRx.Place(TopLeft); // O
            _ticTacToeRx.Place(TopMiddle); // X

            _ticTacToeRx.Place(MiddleRight);// O
            _ticTacToeRx.Place(MiddleMiddle);// X
            _ticTacToeRx.Place(BottomLeft);// O

            _ticTacToeRx.Place(MiddleLeft);// X
            _ticTacToeRx.Place(BottomMiddle);// O
            _ticTacToeRx.Place(BottomRight);// X

            _ticTacToeRx.RequestWinner();

            Assert.AreEqual(None, winner);
        }

        [Test]
        public void NotSwitchPlayerWhenPlacingAtAlreadyPlacedPosition()
        {
            Player player = X;
            _ticTacToeRx.CurrentPlayer.Subscribe(playa => player = playa);

            _ticTacToeRx.Place(TopRight); // X
            _ticTacToeRx.Place(TopRight); // O

            _ticTacToeRx.RequestCurrentPlayer();

            Assert.AreEqual(O, player);
        }
    }
}