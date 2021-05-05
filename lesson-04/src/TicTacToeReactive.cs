using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

using static src.Player;

namespace src
{
    public class TicTacToeReactive
    {
        private readonly Board _board = new Board();
        public Subject<GameMessage> Messages { get; private set; } = new Subject<GameMessage>();
        private Player _currentPlayer = X;

        public TicTacToeReactive()
        {
            Messages.Where(msg => msg is RequestGameState).Subscribe(_ => PublishGameState());
            Messages.Where(msg => msg is PlaceMessage).Subscribe(msg => Place(msg as PlaceMessage));
        }

        private void Place(PlaceMessage message)
        {
            if (_board.IsTaken(message.Position))
            {
                return;
            }

            _board.MarkAt(message.Position, _currentPlayer);

            AlternatePlayer();

            PublishGameState();
        }

        private void AlternatePlayer()
        {
            if (_currentPlayer == O)
            {
                _currentPlayer = X;
                return;
            }

            _currentPlayer = O;
        }

        private void PublishGameState()
        {
            var winner = _board.FindWinner();
            Messages.OnNext(new WinnerMessage(winner));

            Messages.OnNext(new CurrentPlayerMessage(_currentPlayer));
        }
    }
}