using System;
using System.Text.RegularExpressions;

namespace _01._Furniture
{
    class Program
    {
        static void Main(string[] args)
        {

            string pattern = @">>(?<product>[A-z]+)<<(?<Price>\d+\.*\d+)!(?<count>\d*)";

            string input = Console.ReadLine();
            Regex regex = new Regex(pattern);
            double sum = 0;
            Console.WriteLine("Bought furniture:");

            while (input != "Purchase")
            {

                Match stocks = regex.Match(input);
                if (stocks.Success)
                {
                    Console.WriteLine(stocks.Groups[1].Value);
                    double currentPrice = double.Parse(stocks.Groups[2].Value);
                    int currentCount = int.Parse(stocks.Groups[3].Value);
                    sum += currentPrice * currentCount;
                 
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Total money spend: {sum:f2}");
        }
    }
}