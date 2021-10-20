namespace JeuDeLaVieWindowsForm
{
    public struct Coords
    {
        public int _x { get; private set; }
        public int _y { get; private set; }
        
        public Coords(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public override string ToString() => $"({_x}, {_y})";
    }
}