using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAlone
{
    class Data
    {
        public int Hp;
        public int coins;
        public int mana;
        public int swords;
        //public int pro;
        //Player p;

        //the first time the player spawn to the game
        public Data()
        {
            Hp = 13;
            coins = 0;
            mana = 4;
        }

        //save the data of the player
        public void Update(Player player)
        {
            Hp = player.Hp;
            coins = player.coins;
            mana = player.mana;
            swords = player.swords;
        }

        //public Player Renew(Player player)
        //{
        //    player.Hp = hp;
        //    player.coins = coin;
        //    player.mana = mana;
        //    player.swords = swords;
        //    return player;
        //}
    }
}
