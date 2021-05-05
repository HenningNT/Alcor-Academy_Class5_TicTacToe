namespace src
{
    public class PlaceMessage : GameMessage
    {
        public Position Position { get; private set; }

        public PlaceMessage(Position position)
        {
            Position = position;
        }
    }
}