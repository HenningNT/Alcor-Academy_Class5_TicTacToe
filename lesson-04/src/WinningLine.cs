namespace src
{
    internal class WinningLine
    {
        public Position First;
        public Position Second;
        public Position Third;

        public WinningLine(Position first, Position second, Position third)
        {
            First = first;
            Second = second;
            Third = third;
        }
    }
}