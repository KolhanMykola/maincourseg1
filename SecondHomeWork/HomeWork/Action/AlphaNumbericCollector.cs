using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Action
{
    class AlphaNumbericCollector
    {
        private static List<string> inputed = new List<string>();

        public void Numberic(string input)
        {
            if (input.Any(p => char.IsDigit(p)))
            {
                inputed.Add(input);
                Console.WriteLine("Item saved to AlphaNumbericCollector class");
            }
        }
    }
}
