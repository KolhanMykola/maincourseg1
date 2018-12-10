using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Action
{
    class Program
    {        
        static void Main(string[] args)
        {
            AlphaNumbericCollector ncollector = new AlphaNumbericCollector();
            StringCollector acollector = new StringCollector();
            ActionInput input = new ActionInput();

            input.op += ncollector.Numberic;
            input.op += acollector.String;
            input.Run();             
        }
    }
}

