using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace HomeAlone
{
    class Player
    {
        public int x;
        public int y;
        private ConsoleColor PlayerColor;
        private string PlayerMarker;
        private int row, col;

        public int Hp;
        public int mana=3;
        public bool _isAlive = true;
        public int coins = 0;
        public int swords;
        //public Data data;
        //private Maps W;

        //public Player(int initialX, int initialY, int hp, int man,int coin)
        //{
        //    coins = coin;
        //    mana = man;
        //    Hp = hp;
        //    x = initialX;
        //    y = initialY;
        //    PlayerMarker = "P";
        //    PlayerColor = ConsoleColor.Green;
        //}

        //the player gets his location and correct data (hp, mana, swords)
        public Player(int initialX, int initialY, Data d)
        {
            coins = d.coins;
            mana = d.mana;
            Hp = d.Hp;
            swords = d.swords;
            x = initialX;
            y = initialY;
            PlayerMarker = "P";
            PlayerColor = ConsoleColor.Green;
        }

        //draw the player
        public void Draw()
        {
            ForegroundColor = PlayerColor;
            SetCursorPosition(x, y);
            Write(PlayerMarker);
            ResetColor();
        }

        //gets the player movment input and checks if he is in bounds 
        public void PlayerInput(Maps MyW)
        {
            row = MyW.IsWalkableX();
            col= MyW.IsWalkableY();
            ConsoleKeyInfo keyin = Console.ReadKey(true);
            ConsoleKey k = keyin.Key;
            switch (k)
            {
                case ConsoleKey.UpArrow:
                    if (y-1>0)
                    {
                        y -= 1;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (y+1<col-1)
                    {
                        y += 1;                        
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (x+1<row-1|| MyW.GetElement(x + 1, y) == "X")
                    {
                        x += 1;
                        
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (x-1>0)
                    {
                        x -= 1;
                        
                    }
                    break;

                default:
                    break;
            }
        }

        //reduce Hp during battle
        public void TakeDmg(int dmg)
        {
            if (IsAlive())
            {
                Hp -= dmg;
            }
            else
            {
                Hp = 0;
                _isAlive = false;
            }
        }

        //check if alive
        public bool IsAlive()
        {
            if (Hp > 0)
            {
                return _isAlive = true;
            }
            else
            {
                Hp = 0;
                return _isAlive = false;
            }
        }
    }
}
