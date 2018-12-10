using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
{
    class Program
    {
        static void Main(string[] args)
        {           
            MyList<int> list = new MyList<int>();

            for (int x = 5; x < 15; x++)
            {
                list.Add(x);
            }           

            foreach (int i in list)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine(list.Count);

            int s1 = list[1];

            Console.ReadKey();
        }
    }
}
