using src;
using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using static src.Player;

namespace src
{
    public class TicTacToeReactive
    {
        private readonly Board _board = new Board();
        public Subject<GameMessage> Messages = new Subject<GameMessage>();
        private Player _currentPlayer = X;

        public TicTacToeReactive()
        {
            Messages.Where(msg => msg is RequestWinnerMessage).Subscribe(GetWinner);
            Messages.Where(msg => msg is RequestCurrentPlayer).Subscribe(GetCurrentPlayer);
            Messages.Where(msg => msg is PlaceMessage).Subscribe(msg => Place(msg as PlaceMessage));
        }

        private void Place(PlaceMessage message)
        {
            if (_board.IsTaken(message.Position))
            {
                return;
            }

            _board.MarkAt(message.Position, _currentPlayer);

            GetWinner(null);

            AlternatePLayer();

            GetCurrentPlayer(null);
        }

        private void AlternatePLayer()
        {
            if (_currentPlayer == O)
            {
                _currentPlayer = X;
                return;
            }

            _currentPlayer = O;
        }

        private void GetCurrentPlayer(GameMessage obj)
        {
            Messages.OnNext(new CurrentPlayerMessage(_currentPlayer));
        }

        private void GetWinner(GameMessage obj)
        {
            var winner = _board.FindWinner();
            Messages.OnNext(new WinnerMessage(winner));
        }
    }
}