using System;
using System.Reactive.Subjects;
using System.Reactive.Linq;

using static src.Player;

namespace src
{
    public class TicTacToeRx
    {

        Player _currentPlayer = Player.X;

        public Subject<Player> CurrentPlayer { get; internal set; }

        public Subject<Request> Messages { get; internal set; }

        public TicTacToeRx()
        {
            CurrentPlayer = new Subject<Player>();
            Messages = new Subject<Request>();

            Messages.Subscribe(MessageHandler);
        }

        private void MessageHandler(Request request)
        {
            CurrentPlayer.OnNext(_currentPlayer);
        }

        public void RequestCurrentPlayer()
        {
            Messages.OnNext(Request.CurrentPlayer);
        }

        public void Place(Position position)
        {
            if (_currentPlayer == O)
            {
                _currentPlayer = X;
                return;
            }

            _currentPlayer = O;

            RequestCurrentPlayer();
        }
    }

    public enum Request
    {
        CurrentPlayer
    }
}