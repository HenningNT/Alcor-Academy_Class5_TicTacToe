using NUnit.Framework;
using src;

using static src.Player;
using static src.Position;

namespace test
{
    [TestFixture]
    public class TicTacToeOCShould
    {
        private TicTacToeOC _ticTacToeOc;

        [SetUp]
        public void SetUp()
        {
            _ticTacToeOc = new TicTacToeOC();
        }
        
        [Test]
        public void FirstPlayerIsPlayerX()
        {
            var currentPlayer = _ticTacToeOc.GetCurrentPlayer();
            
            Assert.AreEqual(X,currentPlayer);
        }  
        
        [Test]
        public void SecondPlayerIsPlayerO()
        {
            _ticTacToeOc.Place(TopLeft);
            
            var currentPlayer = _ticTacToeOc.GetCurrentPlayer();
            
            Assert.AreEqual(O,currentPlayer);
        }
        
        [Test]
        public void ThirdPlayerIsPlayerX()
        {
            _ticTacToeOc.Place(TopLeft);
            _ticTacToeOc.Place(TopMiddle);
            
            var currentPlayer = _ticTacToeOc.GetCurrentPlayer();
            
            Assert.AreEqual(X,currentPlayer);
        }

        [Test]
        public void NotHaveAWinnerAtStart()
        {
            var winner = _ticTacToeOc.FindWinner();
            
            Assert.AreEqual(None, winner);
        }
        
        [Test]
        public void MakeXWinWhenTopRowContainsAllXs()
        {
            _ticTacToeOc.Place(TopLeft);
            _ticTacToeOc.Place(BottomLeft);
            _ticTacToeOc.Place(TopMiddle);
            _ticTacToeOc.Place(BottomMiddle);
            _ticTacToeOc.Place(TopRight);
            
            var winner = _ticTacToeOc.FindWinner();
            
            Assert.AreEqual(X, winner);
        }

        [Test]
        public void MakeOWinWhenTopRowContainsAllOs()
        {
            _ticTacToeOc.Place(MiddleMiddle);
            _ticTacToeOc.Place(TopLeft);
            _ticTacToeOc.Place(BottomLeft);
            _ticTacToeOc.Place(TopMiddle);
            _ticTacToeOc.Place(BottomMiddle);
            _ticTacToeOc.Place(TopRight);
            
            var winner = _ticTacToeOc.FindWinner();
            
            Assert.AreEqual(O, winner);
        }
        
        [Test]
        public void MakeXWinWhenMiddleRowContainsAllXs()
        {
            _ticTacToeOc.Place(MiddleMiddle);
            _ticTacToeOc.Place(TopLeft);
            _ticTacToeOc.Place(MiddleLeft);
            _ticTacToeOc.Place(TopMiddle);
            _ticTacToeOc.Place(MiddleRight);
            
            var winner = _ticTacToeOc.FindWinner();
            
            Assert.AreEqual(X, winner);
        }

        [Test]
        public void MakeNoWinnerWhenBoardFull()
        {
            _ticTacToeOc.Place(TopRight); // X
            _ticTacToeOc.Place(TopLeft); // O
            _ticTacToeOc.Place(TopMiddle); // X

            _ticTacToeOc.Place(MiddleRight);// O
            _ticTacToeOc.Place(MiddleMiddle);// X
            _ticTacToeOc.Place(BottomLeft);// O

            _ticTacToeOc.Place(MiddleLeft);// X
            _ticTacToeOc.Place(BottomMiddle);// O
            _ticTacToeOc.Place(BottomRight);// X

            var winner = _ticTacToeOc.FindWinner();

            Assert.AreEqual(None, winner);
        }

        [Test]
        public void NotSwitchPlayerWhenPlacingAtAlreadyPlacedPosition()
        {
            _ticTacToeOc.Place(TopRight); // X
            _ticTacToeOc.Place(TopRight); // O

            var player = _ticTacToeOc.GetCurrentPlayer();

            Assert.AreEqual(O, player);
        }
    }
}