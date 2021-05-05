using System;
using System.Reactive.Subjects;
using System.Reactive.Linq;

using static src.Player;

namespace src
{
    public class TicTacToeRx
    {
        private readonly Board _board = new Board();
        Player _currentPlayer = X;

        public Subject<Player> CurrentPlayer { get; internal set; }
        public Subject<Player> Winner { get; internal set; }
        public Subject<Request> Messages { get; internal set; }

        public TicTacToeRx()
        {
            CurrentPlayer = new Subject<Player>();
            Winner = new Subject<Player>();
            Messages = new Subject<Request>();

            Messages.Subscribe(MessageHandler);
        }

        private void MessageHandler(Request request)
        {
            if (request == Request.Winner)
                Winner.OnNext(_board.FindWinner());

            CurrentPlayer.OnNext(_currentPlayer);
        }

        public void RequestCurrentPlayer()
        {
            Messages.OnNext(Request.Winner);
        }

        public void RequestWinner()
        {
            Messages.OnNext(Request.Winner);
        }

        public void Place(Position position)
        {
            if (_board.IsTaken(position))
            {
                return;
            }

            _board.MarkAt(position, _currentPlayer);

            if (_currentPlayer == O)
            {
                SetPlayer(X);
                return;
            }

            SetPlayer(O);

        }

        private void SetPlayer(Player player)
        {
            _currentPlayer = player;

            RequestCurrentPlayer();

        }
    }

    public enum Request
    {
        Winner
    }
}