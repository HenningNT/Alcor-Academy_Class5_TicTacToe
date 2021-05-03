using NUnit.Framework;
using src;

namespace test
{
    [TestFixture]
    public class TicTacToeShould
    {
        /*
         * What is 1,1? Is it top left?
         * 3,2 outside of board
         * Capital X?
         * What is a Row and Column?
         */
        private TicTacToe _ticTacToe;

        [SetUp]
        public void SetUp()
        {
            _ticTacToe = new TicTacToe();
        }

        [Test]
        public void Make_first_player_x()
        {
            var currentPlayer = _ticTacToe.GetCurrentPlayer();

            Assert.AreEqual("X", currentPlayer);
        }

        [Test]
        public void Make_second_player_o()
        {
            _ticTacToe.Place(1, 1);

            Assert.AreEqual("O", _ticTacToe.GetCurrentPlayer());
        }

        [Test]
        public void Make_third_player_x()
        {
            _ticTacToe.Place(1, 1);
            _ticTacToe.Place(1, 0);

            Assert.AreEqual("X", _ticTacToe.GetCurrentPlayer());
        }

        [Test]
        public void Ignore_invalid_consecutive_move()
        {
            _ticTacToe.Place(1, 1);
            _ticTacToe.Place(1, 1);

            Assert.AreEqual("O", _ticTacToe.GetCurrentPlayer());
        }
        
        [Test]
        public void Ignore_any_invalid_move()
        {
            _ticTacToe.Place(1, 1);
            _ticTacToe.Place(1, 0);
            _ticTacToe.Place(0, 1);
            _ticTacToe.Place(1, 1);

            Assert.AreEqual("O", _ticTacToe.GetCurrentPlayer());
        }

        [Test]
        public void Return_x_as_winner_top_row()
        {
            _ticTacToe.Place(0,0);
            _ticTacToe.Place(1,0);
            _ticTacToe.Place(0,1);
            _ticTacToe.Place(1,1);
            _ticTacToe.Place(0,2);
            
            Assert.AreEqual("X", _ticTacToe.Winner());
        }
        
        [Test]
        public void Return_o_as_winner_top_row()
        {
            _ticTacToe.Place(3,2);
            _ticTacToe.Place(0,0);
            _ticTacToe.Place(1,0);
            _ticTacToe.Place(0,1);
            _ticTacToe.Place(1,1);
            _ticTacToe.Place(0,2);
            
            Assert.AreEqual("O", _ticTacToe.Winner());
        }
        
        [Test]
        public void Return_o_as_winner_middle_row()
        {
            _ticTacToe.Place(3,2);
            _ticTacToe.Place(1,0);
            _ticTacToe.Place(0,0);
            _ticTacToe.Place(1,1);
            _ticTacToe.Place(3,1);
            _ticTacToe.Place(1,2);
            
            Assert.AreEqual("O", _ticTacToe.Winner());
        }
        
        [Test]
        public void Return_o_as_winner_bottom_row()
        {
            _ticTacToe.Place(3,2);
            _ticTacToe.Place(2,0);
            _ticTacToe.Place(0,0);
            _ticTacToe.Place(2,1);
            _ticTacToe.Place(3,1);
            _ticTacToe.Place(2,2);
            
            Assert.AreEqual("O", _ticTacToe.Winner());
        }
        
        [Test]
        public void Return_no_winner_after_one_movement()
        {
            _ticTacToe.Place(3,2);
            
            Assert.IsEmpty(_ticTacToe.Winner());
        }
        
    }
}