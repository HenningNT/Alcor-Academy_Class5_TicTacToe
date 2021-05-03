using static src.Player;

namespace src
{
    public sealed class TicTacToeOC
    {
        private Player _currentPlayer = X;

        private readonly Board _board = new Board();

        public Player GetCurrentPlayer()
        {
            return _currentPlayer;
        }

        public void Place(Position position)
        {
            if (_board.IsTaken(position))
            {
                return;
            }
            _board.MarkAt(position, _currentPlayer);

            AlternatePlayer();
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

        public Player FindWinner()
        {
            return _board.FindWinner();
        }
    }
}