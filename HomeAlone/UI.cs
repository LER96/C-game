using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAlone
{
    class UI
    {
        private int col, row; 
        private int lvl;      
        private string [,] m;
        private Player p;
        private int Height, Width;

        //gets the player state, progress and map size
        public UI(string[,] map, Player playa, int pro)
        {
            m = map;
            p = playa;
            col = map.GetLength(0);
            row = map.GetLength(1);
            lvl = pro;
            Height = Console.WindowHeight;
            Width = Console.WindowWidth;
        }

        //gets only the dimension of the screen
        public UI()
        {
            Height = Console.WindowHeight;
            Width = Console.WindowWidth;
        }

        //show the stats
        public void ShowUI()
        {
            Console.SetCursorPosition(col+1, 0);
            Console.Write($"HP:{p.Hp}");
            Console.SetCursorPosition(col + 1, 1);
            Console.Write($"Mana:{p.mana}");
            Console.SetCursorPosition(col + 1, 2);
            Console.Write($"Coins:{p.coins}");
            Console.SetCursorPosition(col + 1, 3);
            Console.Write($"Invetory:{p.swords} swords");
            Console.SetCursorPosition(0, col+1);
            Console.Write($"Lvl:{lvl}");
        }

        //shows the shop options
        public void ShopUI()
        {
            Console.SetCursorPosition(Width / 3, Height / 4 * 3 - 5);
            Console.Write($"Your coins:{p.coins}");
            Console.SetCursorPosition(Width/3, Height / 4 * 3);
            Console.Write("Q) HP (+1): 1 coin");
            Console.SetCursorPosition(Width / 3, Height / 4 * 3 + 1);
            Console.Write("W) MANA (+1): 1 coin");
            Console.SetCursorPosition(Width / 3, Height / 4 * 3 + 2);
            Console.Write("E) Sword (+1): 1 coin (one time use)");
            Console.SetCursorPosition(Width / 3, Height / 4 * 3+3);
            Console.Write("EXIT) AnyKey");
            Console.SetCursorPosition(Width / 3, Height / 4 * 3 - 3);
            Console.Write("Enter your choice:");
        }


        //print if enemy catches you
        public void ShowCatch()
        {
            Console.SetCursorPosition(0, col + 2);
            Console.Write("Enemy grabbed you, Fight\npress anykey to continue");
        
        }

        //print if you won the combat
        public void Winner()
        {
            Console.SetCursorPosition(0, col + 2);
            Console.Write("You Won! nice job mate! Here take a coin\npress anykey to continue");
        
        }

        //print if you got a coin
        public void Grab()
        {
            Console.SetCursorPosition(0, col + 2);
            Console.Write("Tou grabbed a coin\npress anykey to continue");
        }

        //print if you got to the next lvl
        public void LVLup()
        {
            Console.SetCursorPosition(0, col + 2);
            Console.Write("Nice you moved to the next room, another step to your destination");
        }

        //print if you land on a trap
        public void Trap()
        {
            Console.SetCursorPosition(0, col + 2);
            Console.Write("A trap, you lost 1 hp");
        }

        //print the combat option, depends on the mana or inventory
        public void ShowCombat(int mana, int swords)
        {
            if (mana <= 0)
                mana = 0;
            switch (mana)
            {
                case 0:
                    Console.SetCursorPosition(0, Height / 5 * 4);
                    Console.Write("Q) Reload(adss 1 mana pt)");
                    break;
                case 1:
                    Console.SetCursorPosition(0, Height / 5 * 4);
                    Console.Write("Q) Reload(adds 1 mana pt)\nW) Basic Attack(take 1 mana pt)\nF) Deffence (adds 1 HP)");
                    break;
                case 2:
                    Console.SetCursorPosition(0, Height / 5 * 4);
                    Console.Write("Q) Reload(adds 1 mana pt)\nW) Basic Attack(takes 1 mana pt)\nE)Medium Attack(takes 2 mana pt)\nF) Deffence (adds 1 HP)");
                    break;
                case 3:
                    Console.SetCursorPosition(0, Height / 5 * 4);
                    Console.Write("Q) Reload(adds 1 mana pt)\nW) Basic Attack(takes 1 mana pt)\nE)Medium Attack(takes 2 mana pt)\nR)Ultra Attack(takes 3 mana pt)\nF) Deffence (adds 1 HP)");
                    break;
                default:
                    Console.SetCursorPosition(0, Height / 5 * 4);
                    Console.Write("Q) Reload(adds 1 mana pt)\nW) Basic Attack(takes 1 mana pt\nE)Medium Attack(takes 2 mana pt)\nR)Ultra Attack(takes 3 mana pt)\nF) Deffence (adds 1 HP)");
                    break;
            }
            if (swords> 0)
            {
                Console.SetCursorPosition(0, Height / 5 * 3);
                Console.Write("S) swords(4 dmg points without taking mana");
            }
        }

        //print the combat state, your hp, mana and your opponent hp
        public void ShowState(Player playa, Enemy enemy)
        {
            Console.SetCursorPosition(Width/4, Height / 5 * 4-3);
            Console.Write($"HP:{playa.Hp}");
            Console.SetCursorPosition(Width / 4, Height / 5 * 4-2 );
            Console.Write($"MANA:{playa.mana}");
            Console.SetCursorPosition(Width / 4*3, Height / 5 * 4 - 3);
            Console.Write($"HP:{enemy.Hp}");
        }

    }
}
