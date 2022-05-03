using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAlone
{
    class Attacks
    {
        public int dmg;
        //public int state;
        public int mana;
        //public int def;
        public bool isdeff = false;
        public Player p;

        //build the basic for the combat attacks and dmg
        public Attacks(Player player)
        {
            p = player;
            mana = player.mana;
            dmg = 1;
            //def = 2;
        }

        //takes the player choices and add them the damage they need
        public int Choice(string choose)
        {
            isdeff = false;
            if(mana<=0)
            {
                mana = 0;
            }
            switch(choose)
            {
                case "Q":
                    Reload();
                    return 0;
                    //break;
                case "W":
                    if (mana > 0)
                    {
                        dmg *= 1;
                        mana -= 1;
                        return dmg;
                    }
                    else
                        return 0;
                    //break;
                case "E":
                    if (mana > 1)
                    {
                        dmg *= 2;
                        mana -= 2;
                        return dmg;
                    }
                    else
                        return 0;
                    //break;
                case "R":
                    if (mana > 2)
                    {
                        dmg *= 3;
                        mana -= 3;
                        return dmg;
                    }
                    else
                        return 0;
                   // break;
                case "F":
                    if(mana>0)
                    {
                        //def--;
                        mana--;
                        isdeff = true;
                        p.Hp += 1;
                        return 0;
                    }
                    else
                        return 0;
                case "S":
                    if (p.swords > 0)
                    {
                        p.swords-=1;
                        dmg *= 4;
                        return dmg;
                    }
                    else
                        return 0;
                    //break;
                default:
                    return 0;
            }
        }

        public void Reload()
        {
            mana++;
        }

    }
}
