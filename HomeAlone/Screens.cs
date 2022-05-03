using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAlone
{
    class Screens
    {
        public Screens()
        {

        }

        public void Intro()
        {
            Console.Write("OHHH I MEMBER YOU! I MEMBER it's XMAS eve and you're all alone in this big house?\nI MEMBER the way out, here...this is the map of the house,I MARKED you as:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("P");
            Console.ResetColor();
            Console.Write("\nHave a good one, and I MEMBER I heard some strange noises in  the house.\nMaybe it's the cat wdk,\nOhhh and before I DONT MEMBER, your EXIT is marked as:");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("X");
            Console.ResetColor();
            Console.WriteLine("\nHow you move? Well with  arrows");
            Console.SetCursorPosition(12, 6);
            Console.Write("^ UP");
            Console.SetCursorPosition(12, 10);
            Console.Write("v Down");
            Console.SetCursorPosition(0, 8);
            Console.Write("Left <");
            Console.SetCursorPosition(20, 8);
            Console.Write("> Right");
            Console.SetCursorPosition(0, 13);
            Console.Write("Press any key to continue");
            Console.ReadKey(true);
            //Console.Clear();
        }

        //explain the signs on the game map
        public void Markes()
        {
            Console.Write("P- player\nE- Thieves/Enemies\nT- Traps\nS- Shop\nC- Coins\nX- Exit\n");
            Console.Write("\n*The traps are invisible to the player, it located randomly on the map, if you step on it you'll lose a point.");
            Console.Write("\n*The shop allows you to buy items, such as: extra Hp, extra Mana or using a Sword that allows you hurt/kill the enemy");
            Console.Write("\n*The enemy is a thieve so he's quick and will catch you, so face your fears and fight!");
            Console.Write("\n\nPress any key to continue");
            Console.ReadKey(true);


        }
        public void END()
        {
            Console.Clear();
            Console.Write("Game OVER Thanks for playing my <3");
            Console.ReadKey(true);
        }

        //if you won
        public void Well()
        {
            Console.Clear();
            Console.Write("Well Done!! Thank you for playing my game <3");
            Console.ReadKey(true);
        }
    }
}
