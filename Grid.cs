using System;
using System.Collections.Generic;
using System.Linq;

namespace JeuDeLaVieWindowsForm

{
    public class Grid
    {
        public int _n { get; private set; }

        public Cell[,] TabCells;
        public int nbAliveAdded = 0;

        public Grid(int nbCells, List<Coords> AliveCellsCoords)
        {
            this._n = nbCells;
            TabCells = new Cell[_n, _n];
            for (int y = 0; y < _n; y++)
            {
                for (int x = 0; x < _n; x++)
                {
                    TabCells[x,y] = new Cell(false);
                    for (int i = 0; i < AliveCellsCoords.Count; i++)
                    {
                        
                        if (AliveCellsCoords[i]._x == x && AliveCellsCoords[i]._y == y)
                        {
                            nbAliveAdded++;
                            TabCells[x,y] = new Cell(true);
                            break;
                        }
                    }
                }
            }
        }

        public int getNbAliveNeighboor(int i, int j)
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

        public List<Coords> getCoordsNeighboors(int i, int j)
        {
            List<Coords> coordsNeighboor = new List<Coords>();
            int minI = i - 1;
            int maxI = i + 1;
            int minJ = j - 1;
            int maxJ = j + 1;

            for (int y = minI; y <= maxI && y >= 0; y++)
            {
                for (int x = minJ; x <= maxJ && x >= 0; x++)
                {
                    if (!TabCells[x,y]._isAlive)
                    {
                        coordsNeighboor.Add(new Coords(x,y));
                    }
                }
            }

            if (coordsNeighboor.Contains(new Coords(i,j)))
            {
                coordsNeighboor.Remove(new Coords(i,j));
            }
            return coordsNeighboor;
        }

        public List<Coords> getCoordsCellsAlive()
        {
            List<Coords> aliveCoordsCells = new List<Coords>();
            for (int y = 0; y < _n && y >= 0; y++)
            {
                for (int x = 0; x < _n && x >= 0; x++)
                {
                    if (TabCells[x,y]._isAlive)
                    {
                        aliveCoordsCells.Add(new Coords(x,y));
                    }
                }
            }

            return aliveCoordsCells;
        }

        public void DisplayGrid()
        {
            for (int y = 0; y < _n; y++)
            {
                Console.Write(String.Concat(Enumerable.Repeat("+---", _n)));
                Console.Write("+\n");
                for (int x = 0; x < _n; x++)
                {
                    if (TabCells[x,y]._isAlive)
                    {
                        Console.Write("| X ");
                    }
                    else
                    {
                        Console.Write("|   ");
                    }
                    
                }
                Console.Write("|\n");
                
                
            }
            Console.Write(String.Concat(Enumerable.Repeat("+---", _n)));
            Console.Write("+\n");
        }

        public void UpdateGrid()
        {
            //Console.WriteLine($"Taille du tableau : {TabCells.Length}, n : {_n}");
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