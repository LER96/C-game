using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAlone
{
    class Game
    {
        private Player playa;
        private Enemy enemy;
        private Maps map;
        private Combat com;
        private UI u;
        private Shop shop = new Shop();
        private int pro;
        //private int coin;
        //private int CorrectHp;
        //private int correctMana;
        private Screens screen = new Screens();
        private Data data;
        public Game()
        {
            //GameLoops();
        }

        //The all game core
        public void GameLoops()
        {
            screen.Intro();
            Console.Clear();
            screen.Markes();
            //coin = 0;
            pro = 1;
            //CorrectHp = 10;
            //correctMana = 3;
            data = new Data();
            bool checkgrab = true;
            bool checkwin = false;
            bool checkmoved = false;
            NewMap();
            Draw();
         
            //u = new UI();

            //if the player passed all the lvls or dies during it, stop the loop
            while (pro<10 && playa.Hp>0)
            {
                u = new UI(map.map, playa, pro);
                Draw();

                //each time the player passes a lvl
                if(pro>1 && checkmoved==true)
                {
                    u.LVLup();
                    checkmoved = false;
                }

                //if enemy is dead
                if (enemy.EnemyrMarker == "" && checkwin==true)
                {
                    u.Winner();
                    //Console.ReadKey(true);
                    checkwin = false;
                }
                playa.PlayerInput(map);
                string element = map.GetElement(playa.x, playa.y);

                //if player lands on a trap
                if(element=="T")
                {
                    Draw();
                    map.map[playa.y, playa.x] = "T";
                    u.Trap();
                    Console.ReadKey(true);
                    Console.Clear();
                    playa.Hp -= 1;
                    //CorrectHp = playa.Hp;
                    data.Update(playa);
                }

                //if player kills an enemy and stand on the X mark, create new mmap
                if (element == "X" && enemy.EnemyrMarker=="")
                {
                    Draw();
                    checkgrab = true;
                    shop.check = false;
                    checkmoved = true;
                    pro++;
                    NewMap();
                }

                //if player stands on a coin
                if(element=="C")
                {
                    if (checkgrab == true)
                    {
                        u.Grab();
                        Console.ReadKey(true);
                        Console.Clear();
                        playa.coins += 1;
                        //coin = playa.coins;
                        data.Update(playa);
                        checkgrab = false;
                    }
                }

                //if player want to enter the shop, can enter only once
                if(element=="S")
                {
                    Draw();
                    while (shop.check==false)
                    {
                        Console.Clear();
                        shop.Draw();
                        u.ShopUI();
                        string s = Console.ReadLine();
                        shop.Choice(s, playa);
                    }
                    //coin = playa.coins;
                    //CorrectHp = playa.Hp;
                    //correctMana = playa.mana;
                    data.Update(playa);
                }

                //check if enemy is in player location
                if(enemy.Catch(playa)==false)
                {
                    enemy.EnemyMovement(playa, map);
                }
                //if he does... fight!
                if(enemy.Catch(playa))
                {
                    Draw();
                    u.ShowCatch();
                    Console.ReadKey(true);
                    Console.Clear();
                    com= new Combat();
                    if(com.Battle(playa, enemy)==false)
                    {
                        screen.END();
                        break;
                    }
                    else
                    {
                        checkwin = true;
                        playa.coins += 1;
                        //coin = playa.coins;
                        //CorrectHp = playa.Hp;
                        //correctMana = playa.mana;
                        data.Update(playa);
                        enemy = new Enemy(0, 0);
                        enemy.EnemyrMarker = "";
                    }
                    
                }
                //System.Threading.Thread.Sleep(20);
            }

            //check why it exit the loop, is it because the player won, or just because the player died
            if(pro==10)
            {
                screen.Well();
            }
            Console.Clear();
            if(playa.Hp==0)
            {
                Console.Clear();
                screen.END();
            }

        }

        //draw all the elements in the map
        public void Draw()
        {
            Console.Clear();
            map.Draw();
            playa.Draw();
            u.ShowUI();
            enemy.Draw();
        }

        //create a new map and save all the correct data of the player, also creat random enemy with random Hp
        public void NewMap()
        {
            Random rnd = new Random();
            map = new Maps();
            //playa = new Player(1, 1, CorrectHp, correctMana, coin);
            playa = new Player(1, 1, data);
            enemy = new Enemy(rnd.Next(1, map.IsWalkableX()-1), rnd.Next(1, map.IsWalkableY()-1));
            enemy.Hp = rnd.Next(3,6);
            u = new UI(map.map, playa, pro);
        }
    }
}
