using src;

namespace src
{
    public class WinnerMessage : GameMessage
    {
        public Player Winner { get; private set; }

        public WinnerMessage(Player winner)
        {
            Winner = winner;
        }
    }
}