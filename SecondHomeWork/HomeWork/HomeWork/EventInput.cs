using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    class EventInput
    {
        public delegate void Cooperation(string s);
        public event Cooperation OnProcessed;        

        public void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();
                OnProcessed.Invoke(input);
            }
        }
    }
}
