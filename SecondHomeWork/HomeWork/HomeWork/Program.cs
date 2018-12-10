using HomeWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event
{ 
    class Program
    {
        static void Main(string[] args)
        {
            AlphaNumbericCollector ncollector = new AlphaNumbericCollector();
            StringCollector acollector = new StringCollector();
            EventInput input = new EventInput();
            input.OnProcessed += ncollector.Numberic;
            input.OnProcessed += acollector.String;
            input.Run();                      
        }       
    }
}
