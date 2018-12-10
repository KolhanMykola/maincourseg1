using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Action
{
    class ActionInput
    {
        //public delegate void Cooperation(string s);
        //public Cooperation GetCooperation;
        public Action<string> op;

        public void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();
                op.Invoke(input);
            }
        }
    }
}
