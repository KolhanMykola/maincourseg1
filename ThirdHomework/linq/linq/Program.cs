using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linq
{
    class Program
    {
        static void Main(string[] args)
        {            
            string gamers = "Davis, Clyne, Fonte, Hooiveld, Shaw, Davis, Schneiderlin, Cork, Lallana, Rodriguez, Lambert";
            var gamersList = gamers.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).
                Zip(Enumerable.Range(1, 11), (first, second) => " " + second + "." + first).
                Aggregate((current, next) => current + next);
            Console.WriteLine(gamersList);


            string names = "Jason Puncheon, 26 / 06 / 1986;" +
                            "Jos Hooiveld, 22 / 04 / 1983;" +
                            "Kelvin Davis, 29 / 09 / 1976;" +
                            "Luke Shaw, 12 / 07 / 1995;" +
                            "Gaston Ramirez, 02 / 12 / 1990;" +
                            "Adam Lallana, 10 / 05 / 1988";

            var sortedNames = names.Split(';').Select(playeyWithYear => playeyWithYear.Split(',')).
                Select(s => new { Player = s[0], Year = DateTime.Parse(s[1]) }).
                OrderBy(element => element.Year).Select(p => p.Player + " " + p.Year.ToShortDateString()).ToList();
            sortedNames.ForEach(p => Console.WriteLine(p));

          
            var songsDurations = "4:12,2:43,3:51,4:29,3:24,3:14,4:46,3:25,4:52,3:27";           
            var sum = songsDurations.Split(',').Sum(p => TimeSpan.Parse(p).Ticks);
            Console.WriteLine(sum);

            Console.ReadLine();
        }
    }
}