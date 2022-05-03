using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAlone
{
    class Combat
    {
        private int Height, Width;
        private Random rnd;
        private UI u;
        private Attacks att;
        public Combat()
        {
            ScreeDime();
            rnd = new Random();
            //Draw();
        }
        //takes screen sizes
        private void ScreeDime()
        {
            Height = Console.WindowHeight;
            Width = Console.WindowWidth;
        }

        //draw the player and the enemy location
        public void Draw()
        {
            Console.Clear();
            Console.SetCursorPosition(Width / 4, Height / 2);
            Console.Write("P");
            Console.SetCursorPosition(Width / 4*3, Height / 2);
            Console.Write("E");
        }

        //turn base battle
        public bool Battle(Player playa,Enemy enemy)
        {
            att = new Attacks(playa);
            u = new UI();
            Draw();
            int turn = rnd.Next(1, 3);
            while(playa._isAlive && enemy._isAlive)
            {
                if (turn == 1)
                {
                    Draw();
                    u.ShowState(playa, enemy);
                    u.ShowCombat(playa.mana, playa.swords);
                    Console.SetCursorPosition(Width / 4, Height / 2 - 5);
                    Console.Write("Turn");
                    Console.SetCursorPosition(0, Height / 5 * 4 - 2);
                    Console.Write("Enter HERE:");
                    int dmg = att.Choice(Console.ReadLine());
                    playa.Hp = att.p.Hp;
                    enemy.TakeDamage(dmg);
                    playa.mana = att.mana;
                    //Console.ReadKey(true);
                    if (enemy._isAlive)
                    {
                        turn = 2;
                    }
                }
                else if (turn == 2)
                {
                    Draw();
                    u.ShowState(playa, enemy);
                    Console.SetCursorPosition(Width / 4 * 3, Height / 2 - 5);
                    Console.Write("Turn");
                    Console.ReadKey(true);
                    if (att.isdeff == false)
                    {
                        playa.TakeDmg(enemy.Dmg);
                    }
                    if (playa._isAlive)
                    {
                        turn = 1;
                    }
                }
            }
            if (playa._isAlive == false)
                return false;
            else
                return true;
            
        }

    }
}
