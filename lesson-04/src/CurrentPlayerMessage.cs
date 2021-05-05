namespace src
{
    public class CurrentPlayerMessage : GameMessage
    {
        public Player CurrentPlayer { get; private set; }
        public CurrentPlayerMessage(Player player)
        {
            CurrentPlayer = player;
        }
    }
}