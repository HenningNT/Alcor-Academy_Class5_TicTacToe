using System;
using System.Reactive.Subjects;
using System.Reactive.Linq;

namespace src
{
    public class TicTacToeRx
    {
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
            CurrentPlayer.OnNext(Player.X);
        }

    }

    public enum Request
    {
        CurrentPlayer
    }
}