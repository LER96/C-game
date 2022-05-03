using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace HomeAlone
{
    class Maps
    {
        public string[,] map;
        private int exit, col;
        private int x1=1,y1=1, x2=1, y2=1;
        private int[] trapX;
        private int[] trapY;
        //private string[,] traps;
        Random rnd;
        public Maps()
        {
            rnd = new Random();
            col = rnd.Next(10, 30);
            map = new string[col, col];
            exit = rnd.Next(1, col-1);
            int j = rnd.Next(1, 8);
            trapX = new int[j];
            trapY = new int[j];
            for(int i=0; i<j; i++)
            {
                trapX[i] = rnd.Next(1, col - 1);
                trapY[i] = rnd.Next(1, col - 1);
            }
        }
        public void Draw()
        {
            for(int y=0; y<map.GetLength(0); y++)
            {
                for(int x=0; x<map.GetLength(1); x++)
                {
                    if (y == 0 || y == map.GetLength(0) - 1)
                    {
                        if (x == 0 || x == map.GetLength(1) - 1)
                            map[y, x] = "+";
                        else
                            map[y, x] = "=";
                    }
                    if(x==0 || x == map.GetLength(1) - 1)
                    {
                        if (y == 0 || y == map.GetLength(0) - 1)
                            map[y, x] = "+";
                        else
                            map[y, x] = "|";
                    }

                }
            }

            while (x1 == x2 && y1 == y2)
            {
                if (x1 == 1 && y1 == 1 && x2 == 1 && y2 == 1)
                {
                    x1 = rnd.Next(1, col - 1);
                    x2 = rnd.Next(1, col - 1);
                    y1 = rnd.Next(1, col - 1);
                    y2 = rnd.Next(1, col - 1);
                }
            }
            map[x1, y1] = "S";
            map[x2, y2] = "C";
            map[exit, col - 1] = "X";
            Print();
        }

        public void Print()
        {
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    string st = map[y, x];
                    SetCursorPosition(x, y);
                    Write(st);
                }
            }
        }

        //public bool IsWalkable(int x, int y)
        //{
        //    return map[y, x] == "" || map[y, x] == "X";
        //}
        public int IsWalkableY()
        {
            return map.GetLength(0);
        }
        public int IsWalkableX()
        {
            return map.GetLength(1);
        }


        public string GetElement(int x, int y)
        {
            for(int i=0; i<trapX.Length; i++)
            {
                if( x==trapX[i] && y==trapY[i])
                {
                    return "T";
                }
            }

            return map[y, x];
        }
    }
}
