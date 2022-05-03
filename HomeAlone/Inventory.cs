using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAlone
{
    class Inventory
    {
        public int count = 0;
        public string [] str;
        public Inventory()
        {

        }
        public void Edit()
        {
            count++;
            Create();
        }
        public void Remove()
        {
            count--;
            Create();
        }
        public void Create()
        {
            str = new string[count];
            for(int i=0; i<count; i++)
            {
                str[i] = "sword";
            }
        }
    }
}
