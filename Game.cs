using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace JeuDeLaVieWindowsForm
{
    public class Game
    {
        private int n;
        private int iter;
        public Grid grid;
        private List<Coords> AliveCellsCoords;
        
        private Random rand = new Random();

        public Game(int nbCells, int nbIterations)
        {
            n = nbCells;
            iter = nbIterations;

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

        public void RunGameConsole()
        {
            grid.DisplayGrid();
            for (int i = 0; i < iter; i++)
            {
                //Console.WriteLine(grid.nbAliveAdded);
                List<Coords> aliveList = grid.getCoordsCellsAlive();
                //Console.WriteLine(aliveList.Count);
                grid.UpdateGrid();
                grid.DisplayGrid();
                Thread.Sleep(1000);
            }
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