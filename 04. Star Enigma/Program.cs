using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace _04._Star_Enigma
{
    class Program
    {
        static void Main(string[] args)
        {
            string patterStar = @"[STARstar]";
            string patternPlanet = @"@(?<planet>[A-z]+)[^@:!\->]*:(?<population>\d+)[^@:!\->]*!(?<command>[AD])![^@:!\->]*\->(?<soilder>\d+)";
            Regex regex = new Regex(patternPlanet);
            int n = int.Parse(Console.ReadLine());

            List<string> attacked = new List<string>();
            List<string> destroyed = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string message = Console.ReadLine();
                MatchCollection stars = Regex.Matches(message, patterStar);
                int key = stars.Count;
                string messageFilter = string.Empty;

                foreach (var currenLetter in message)
                {
                    int newLetter = currenLetter - key;
                    messageFilter += (char)newLetter;

                }
                Match planet = regex.Match(messageFilter);
                if (planet.Groups[3].Value == "A")
                {
                    attacked.Insert(0, planet.Groups[1].Value);
                }
                else if (planet.Groups[3].Value == "D")
                {
                    destroyed.Insert(0, planet.Groups[1].Value);
                }

            }
            attacked.Sort();
            destroyed.Sort();
           
            Console.WriteLine($"Attacked planets: {attacked.Count}");
            if (attacked.Count > 0)
            {
                foreach (var curPlanet in attacked)
                {
                    Console.WriteLine($"-> {curPlanet}");
                }
            }
            Console.WriteLine($"Destroyed planets: {destroyed.Count}");
            if (destroyed.Count > 0)
            {
                foreach (var curPlanet in destroyed)
                {
                    Console.WriteLine($"-> {curPlanet}");
                }
            }

        }
    }
}