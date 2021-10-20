namespace JeuDeLaVieWindowsForm
{
    public class Cell
    {
        public bool _isAlive { get; private set; }// État de la cellule, Accesseurs en lecture et en écriture pour _isAlive
        

        public bool _nextState { get; private set; }// Stockage temporaire de l’état de la cellule pour le prochain pas de la simulation
        

        public Cell(bool state)// Constructeur de la classe Cell qui modifie l’attribut _isAlive via son accesseur en écriture pour lui attribuer la valeur state
        {
            _isAlive = state;
        }

        public void Comealive()// Méthode qui modifie à true l’attribut _nextState via son accesseur en écriture.
        {
            _nextState = true;
        }

        public void PassAway()// Méthode qui modifie à false l’attribut _nextState via son accesseur en écriture.
        {
            _nextState = false;
        }

        public void Update()// Méthode qui met à jour l’attribut _isAlive via son accesseur en écriture en lui associant la valeur contenue dans la variable _nextState via son accesseur en lecture
        {
            _isAlive = _nextState;
        }
        
    }
}