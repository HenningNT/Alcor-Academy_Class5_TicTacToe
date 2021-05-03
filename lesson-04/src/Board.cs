using System.Collections.Generic;
using System.Linq;

using static src.Player;
using static src.Position;

namespace src
{
    internal sealed class Board
    {
        private readonly Dictionary<Position, Player> _positionToPlayer = new Dictionary<Position, Player>
        {
            {TopLeft, None},
            {TopMiddle, None},
            {TopRight, None},
            {MiddleLeft, None},
            {MiddleMiddle, None},
            {MiddleRight, None},
            {BottomLeft, None},
            {BottomMiddle, None},
            {BottomRight, None}
        };

        private readonly List<WinningLine> _winningConditions =
            new List<WinningLine>()
            {
                new WinningLine(TopLeft, TopMiddle, TopRight),
                new WinningLine(MiddleLeft, MiddleMiddle, MiddleRight),
                new WinningLine(BottomLeft, BottomMiddle, BottomRight),

                new WinningLine(TopLeft, MiddleLeft, BottomLeft),
                new WinningLine(TopMiddle, MiddleMiddle, BottomMiddle),
                new WinningLine(TopRight, MiddleRight, BottomRight),

                new WinningLine(TopLeft, MiddleMiddle, BottomRight),
                new WinningLine(TopRight, MiddleMiddle, BottomLeft),
            };

        internal void MarkAt(Position position, Player player)
        {
            if (_positionToPlayer[position] == None)
            {
                _positionToPlayer[position] = player;
            }
        }

        internal Player FindWinner()
        {
             var win = _winningConditions.FirstOrDefault(wc => WinnerInLine(wc) != None);

            if (win == default)
            {
                return None;
            }

            return _positionToPlayer[win.First];
        }

        private Player WinnerInLine(WinningLine line)
        {
            if (_positionToPlayer[line.First] == _positionToPlayer[line.Second] &&
                _positionToPlayer[line.First] == _positionToPlayer[line.Third] &&
                _positionToPlayer[line.First] != None)
            {
                return _positionToPlayer[line.First];
            }

            return None;
        }

        internal bool IsTaken(Position position)
        {
            return _positionToPlayer[position] != None;
        }
    }
}