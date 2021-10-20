using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace JeuDeLaVieWindowsForm
{
    public class Game
    {
        private int n; // taille de la grille
        public Grid grid; // grille des emplacements possibles
        private List<Coords> AliveCellsCoords; // liste des coordonnées des cellules vivantes en début de simulation.

        
        private Random rand = new Random();

        //Constructeur de la class Game
        public Game(int nbCells)
        {
            n = nbCells;

            AliveCellsCoords = new List<Coords>();
            for (int y = 0; y < n; y++)
            {
                for (int x = 0; x < n; x++)
                {
                    if (rand.Next(0,101) <= 50)
                    {
                        AliveCellsCoords.Add(new Coords(x,y));
                    }
                }
            }
            
            grid = new Grid(n, AliveCellsCoords);
        }

        public void Paint(Graphics g)
        {
            for (int y = 0; y < n; y++)
            {
                for (int x = 0; x < n; x++)
                {
                    if (grid.TabCells[x,y]._isAlive)
                    {
                        g.FillRectangle(Brushes.White, x * 5, y * 5, 5 , 5);
                    }
                }
            }
        }
    }
}