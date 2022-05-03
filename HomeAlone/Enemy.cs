using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace HomeAlone
{
    class Enemy
    {
        private ConsoleColor EnemyColor;
        public string EnemyrMarker;
        private int x,y;
        public int Hp;
        public int Dmg;
        public bool _isAlive = true;
        private UI u= new UI();


        //gets a random location to start on the map
        public Enemy(int initx, int inity)
        {
            Random rnd = new Random();
            x = initx;
            y = inity;
            EnemyrMarker = "E";
            EnemyColor = ConsoleColor.Red;
            Dmg = 1;
        }

        //draw the enemy
        public void Draw()
        {
            ForegroundColor = EnemyColor;
            SetCursorPosition(x, y);
            Write(EnemyrMarker);
            ResetColor();
        }
        //check the dist between the enemy and the player in each frame 
        public void EnemyMovement(Player p, Maps map)
        {
            float distx = p.x - x;
            float disty = p.y - y;
                if (x < map.map.GetLength(1) && y < map.map.GetLength(0) && x > 0 && y > 0)
                {
                    if (distx > 0)
                    {
                        x += 1;
                    }
                    else if (distx < 0)
                    {
                        distx *= -1;
                        if (distx > 0)
                        {
                            x -= 1;
                        }
                    }
                    if (disty > 0)
                    {
                        y += 1;
                    }
                    else if (disty < 0)
                    {
                        disty *= -1;
                        if (disty > 0)
                        {
                            y -= 1;
                        }
                    }
                }
          
        }

        //takes dmg during battle
        public void TakeDamage(int dmg)
        {
            Hp -= dmg;
            if(Hp<=0)
            {
                Hp = 0;
                _isAlive = false;
            }
        }

        //check if the player and the enemy location are the same
        public bool Catch(Player player)
        {
            if (x== player.x && y==player.y)
            {
                return true;
            }
            else
                return false;
        }
        //checks if alive
        public bool IsAlive()
        {
            if (Hp <= 0)
            {
                Hp = 0;
                //Console.WriteLine("Enemy is dead");
                return _isAlive = false;
            }
            else
                return _isAlive = true;
        }
    }
}
