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
            
            _ticTacToeRx.Messages.OnNext(Request.CurrentPlayer);


            Assert.AreEqual(Player.X, currentPlayer);
        }
    }
}