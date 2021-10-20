namespace JeuDeLaVieWindowsForm
{
    public class Cell
    {
        public bool _isAlive { get; private set; }
        

        public bool _nextState { get; private set; }
        

        public Cell(bool state)
        {
            _isAlive = state;
        }

        public void Comealive()
        {
            _nextState = true;
        }

        public void PassAway()
        {
            _nextState = false;
        }

        public void Update()
        {
            _isAlive = _nextState;
        }
        
    }
}