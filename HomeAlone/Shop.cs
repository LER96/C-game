using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAlone
{
    class Shop
    {
        private int Height;
        private int Width;
        public bool check=false ;
        public Shop()
        {     
            Height = Console.WindowHeight;
            Width = Console.WindowWidth;

        }

        //draw the shop
        public void Draw()
        {
            Console.Clear();
            Console.SetCursorPosition(Width / 2-5, Height / 3);
            Console.Write("Your seller: 50cent");
            Console.SetCursorPosition(Width / 2-5, Height / 3-5);
            Console.Write("The candy shop");
        }

        //takes what ever you desire to choose and add to the player states 
        public void Choice(string s, Player player)
        {
            //Console.Clear();
            //ConsoleKeyInfo keyin = Console.ReadKey(true);
            //ConsoleKey k = keyin.Key;
            if (player.coins > 0)
            {
                switch (s)
                {
                    case "Q":  
                        player.Hp += 1;
                        player.coins -= 1;
                        break;
                    case "W":     
                        player.mana += 1;
                        player.coins -= 1;
                        break;
                    case "E":
                        player.coins -= 1;
                        player.swords+=1;
                        break;
                    default:
                        check = true;
                        break;
                }

            }
            else
            {
                Console.Clear();
                Console.SetCursorPosition(Width / 3, Height / 4 * 3 - 4);
                Console.Write("You fool, you're BROKE Press anykey to EXIT");
                Console.ReadKey(true);
                check = true;
            }
        }
    }
}
