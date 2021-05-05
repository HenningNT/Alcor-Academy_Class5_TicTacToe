using NUnit.Framework;
using src;
using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

using static src.Player;
using static src.Position;

namespace test
{
    [TestFixture]
    public class TicTacToeReactiveShould
    {
        Player _player = None;
        Player _winner = None;
        private Subject<GameMessage> _messages;

        [SetUp]
        public void SetUp()
        {
            var ticTacToeReactive = new TicTacToeReactive();
            _messages = ticTacToeReactive.Messages;

            _messages.Where(msg => msg is CurrentPlayerMessage).Subscribe(wnr => _player = ((CurrentPlayerMessage)wnr).CurrentPlayer);
            _messages.Where(msg => msg is WinnerMessage).Subscribe(wnr => _winner = ((WinnerMessage)wnr).Winner);

            _messages.OnNext(new RequestGameState());
        }

        [Test]
        public void FirstPlayerIsX()
        {
            // Assert
            Assert.AreEqual(X, _player);
        }

        [Test]
        public void SecondPlayerIsPlayerO()
        {
            _messages.OnNext(new PlaceMessage(TopLeft));

            Assert.AreEqual(O, _player);
        }

        [Test]
        public void ThirdPlayerIsPlayerX()
        {
            _messages.OnNext(new PlaceMessage(TopLeft));
            _messages.OnNext(new PlaceMessage(TopMiddle));

            Assert.AreEqual(X, _player);
        }


        [Test]
        public void NotHaveAWinnerAtStart()
        {
            Assert.AreEqual(None, _winner);
        }

        [Test]
        public void MakeXWinWhenTopRowContainsAllXs()
        {
            _messages.OnNext(new PlaceMessage(TopLeft));
            _messages.OnNext(new PlaceMessage(BottomLeft));
            _messages.OnNext(new PlaceMessage(TopMiddle));
            _messages.OnNext(new PlaceMessage(BottomMiddle));
            _messages.OnNext(new PlaceMessage(TopRight));

            Assert.AreEqual(X, _winner);
        }

        [Test]
        public void MakeOWinWhenTopRowContainsAllOs()
        {
            _messages.OnNext(new PlaceMessage(MiddleMiddle));
            _messages.OnNext(new PlaceMessage(TopLeft));
            _messages.OnNext(new PlaceMessage(BottomLeft));
            _messages.OnNext(new PlaceMessage(TopMiddle));
            _messages.OnNext(new PlaceMessage(BottomMiddle));
            _messages.OnNext(new PlaceMessage(TopRight));

            Assert.AreEqual(O, _winner);
        }

        [Test]
        public void MakeXWinWhenMiddleRowContainsAllXs()
        {
            _messages.OnNext(new PlaceMessage(MiddleMiddle));
            _messages.OnNext(new PlaceMessage(TopLeft));
            _messages.OnNext(new PlaceMessage(MiddleLeft));
            _messages.OnNext(new PlaceMessage(TopMiddle));
            _messages.OnNext(new PlaceMessage(MiddleRight));

            Assert.AreEqual(X, _winner);
        }

        [Test]
        public void MakeNoWinnerWhenBoardFull()
        {
            _messages.OnNext(new PlaceMessage(TopRight)); // X
            _messages.OnNext(new PlaceMessage(TopLeft)); // O
            _messages.OnNext(new PlaceMessage(TopMiddle)); // X

            _messages.OnNext(new PlaceMessage(MiddleRight));// O
            _messages.OnNext(new PlaceMessage(MiddleMiddle));// X
            _messages.OnNext(new PlaceMessage(BottomLeft));// O

            _messages.OnNext(new PlaceMessage(MiddleLeft));// X
            _messages.OnNext(new PlaceMessage(BottomMiddle));// O
            _messages.OnNext(new PlaceMessage(BottomRight));// X

            Assert.AreEqual(None, _winner);
        }

        [Test]
        public void NotSwitchPlayerWhenPlacingAtAlreadyPlacedPosition()
        {
            _messages.OnNext(new PlaceMessage(TopRight)); // X
            _messages.OnNext(new PlaceMessage(TopRight)); // O

            Assert.AreEqual(O, _player);
        }
    }
}