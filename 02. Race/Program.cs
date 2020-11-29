using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._Race
{
    class Program
    {
        static void Main(string[] args)
        {
            string patternName = @"[\W\d]";
            string patternDigit = @"[\WA-Za-z]";

            string[] names = Console.ReadLine().Split(", ");

            string racer = Console.ReadLine();
            Dictionary<string, int> allRacers = new Dictionary<string, int>();

            foreach (string currentName in names)
            {
                allRacers.Add(currentName, 0);
            }

            while (racer != "end of race")
            {

                string name = Regex.Replace(racer, patternName, "");
                string distance = Regex.Replace(racer, patternDigit, "");

                int sum = 0;

                foreach (var item in distance)
                {
                    sum += int.Parse(item.ToString());
                }

                if (allRacers.ContainsKey(name))
                {
                    allRacers[name] += sum;
                }

                racer = Console.ReadLine();
            }

            int place = 1;

            foreach (var currentRacer in allRacers.OrderByDescending(x => x.Value))
            {
                string text = place == 1 ? "st" : place == 2 ? "nd" : "rd";

                Console.WriteLine($"{place++}{text} place: {currentRacer.Key}");

                if (place == 4)
                {
                    break;
                }
            }
        }
    }
}