using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{ 
    class DelegateInput
    {
        public delegate void Cooperation(string s);
        public Cooperation GetCooperation;

        public void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();
                GetCooperation.Invoke(input);
            }
        }
    }
}
