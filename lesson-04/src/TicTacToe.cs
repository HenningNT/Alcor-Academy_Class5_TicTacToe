using System.Collections.Generic;

namespace src
{
    public class TicTacToe
    {
        private string _currentPlayer = "X";
        private readonly Dictionary<string, string> _positionToPlayer = new Dictionary<string, string>();

        public string GetCurrentPlayer()
        {
            return _currentPlayer;
        }

        public void Place(int x, int y)
        {
            if (_positionToPlayer.ContainsKey($"{x}{y}"))
            {
                return;
            }

            _positionToPlayer.Add($"{x}{y}", _currentPlayer);

            if (_currentPlayer == "O")
            {
                _currentPlayer = "X";
            }
            else
            {
                _currentPlayer = "O";
            }
        }

        public string Winner()
        {
            if (_positionToPlayer.ContainsKey("00") &&
                _positionToPlayer.ContainsKey("01") &&
                _positionToPlayer.ContainsKey("02") &&
                _positionToPlayer["00"] == _positionToPlayer["01"] &&
                _positionToPlayer["00"] == _positionToPlayer["02"])
            {
                return _positionToPlayer["00"];
            }

            if (_positionToPlayer.ContainsKey("10") &&
                _positionToPlayer.ContainsKey("11") &&
                _positionToPlayer.ContainsKey("12") &&
                _positionToPlayer["10"] == _positionToPlayer["11"] &&
                _positionToPlayer["10"] == _positionToPlayer["12"])
            {
                return _positionToPlayer["10"];
            }

            if (_positionToPlayer.ContainsKey("20") &&
                _positionToPlayer.ContainsKey("21") &&
                _positionToPlayer.ContainsKey("22") &&
                _positionToPlayer["20"] == _positionToPlayer["21"] &&
                _positionToPlayer["20"] == _positionToPlayer["22"])
            {
                return _positionToPlayer["20"];
            }

            return string.Empty;
        }
    }
}