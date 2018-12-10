using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    class Program
    {       
        static void Main(string[] args)
        {
            AlphaNumbericCollector ncollector = new AlphaNumbericCollector();
            StringCollector acollector = new StringCollector();
            DelegateInput input = new DelegateInput();

            input.GetCooperation += ncollector.Numberic;
            input.GetCooperation += acollector.String;
            input.Run();
        }
    }
}
