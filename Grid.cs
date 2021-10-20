using System;
using System.Collections.Generic;
using System.Linq;

namespace JeuDeLaVieWindowsForm

{
    public class Grid
    {
        public int _n { get; private set; } // taille de la grille accesseurs en lecture et en écriture

        public Cell[,] TabCells;  // Tableau à deux dimensions contenant des objets de type Cell

        public Grid(int nbCells, List<Coords> AliveCellsCoords) //Constructeur de la class Grid
        {
            this._n = nbCells; // Initialisation de l’attribut _n au travers de l’accesseur en écriture
            TabCells = new Cell[_n, _n];// Création d’un tableau à deux dimensions de taille n,n
            
            /* Remplissage du tableau avec à chaque emplacement une instance d’une cellule
            Cell créée vivante (true) si les coordonnées sont dans la liste AliveCellsCoords
            ou absente (false) sinon. */
            for (int y = 0; y < _n; y++)
            {
                for (int x = 0; x < _n; x++)
                {
                    TabCells[x,y] = new Cell(false);
                    for (int i = 0; i < AliveCellsCoords.Count; i++)
                    {
                        
                        if (AliveCellsCoords[i]._x == x && AliveCellsCoords[i]._y == y)
                        {
                            TabCells[x,y] = new Cell(true);
                            break;
                        }
                    }
                }
            }
        }

        public int getNbAliveNeighboor(int i, int j) // Méthode qui permet de déterminer le nombre de cellules vivantes autour d’un emplacement de coordonnées (i,j)
        {
            int nbCells = 0;
            if (i - 1 >= 0 && TabCells[i - 1, j]._isAlive == true)
            {
                nbCells += 1;
            }
            if (i + 1 < _n && TabCells[i + 1, j]._isAlive == true)
            {
                nbCells += 1;  
            }
            if (j - 1 >= 0 && TabCells[i, j - 1]._isAlive == true)
            {
                nbCells += 1;
            }
            if (j + 1 < _n && TabCells[i, j + 1]._isAlive == true)
            {
                nbCells += 1;
            }
            if (j + 1 < _n && i + 1 < _n && TabCells[i + 1, j + 1]._isAlive == true)
            {
                nbCells += 1;
            }
            if (i - 1 >= 0 && j - 1 >= 0 && TabCells[i - 1, j - 1]._isAlive == true)
            {
                nbCells += 1;
            }
            if (i + 1 < _n && j - 1 >= 0 && TabCells[i + 1, j - 1]._isAlive == true)
            {
                nbCells += 1;
            }
            if (i - 1 >= 0 && j + 1 < _n && TabCells[i - 1, j + 1]._isAlive == true)
            {
                nbCells += 1;
            }
            return nbCells;
        }

        /*Méthode qui parcourt chaque cellule et qui met
        à jour leur attribut _nextStep, via son accesseur en écriture, en fonction des règles
        de la simulation. L’attribut est mis à true si la cellule reste en vie ou apparaît et
        à false si la cellule à cet emplacement disparaît ou reste absente. Une fois toute la
        grille parcourue, une deuxième passe est effectué pour associer la valeur de nexStep
        à l’attribut isAlive de chaque cellule.*/
        public void UpdateGrid()
        {
            for (int y = 0; y < _n; y++)
            {
                for (int x = 0; x < _n; x++)
                {
                    if (TabCells[x,y]._isAlive && (getNbAliveNeighboor(x,y) == 2 || getNbAliveNeighboor(x,y) == 3))
                    {
                        TabCells[x,y].Comealive();
                    } else if (getNbAliveNeighboor(x,y) == 3 && !TabCells[x,y]._isAlive)
                    {
                        TabCells[x,y].Comealive();
                    } else
                    {
                        TabCells[x,y].PassAway();
                    }
                }
            }
            for (int y = 0; y < _n; y++)
            {
                for (int x = 0; x < _n; x++)
                {
                    TabCells[x,y].Update();
                }
            }
        }
    }
}