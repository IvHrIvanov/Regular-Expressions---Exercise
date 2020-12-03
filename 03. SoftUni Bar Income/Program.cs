using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _03._SoftUni_Bar_Income
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"%(?<Name>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*[A-z]*\|(?<count>\d+)\|[^|$%.]*?(?<price>\d+\.?\d+)\$";

            string input = Console.ReadLine();
            Regex regex = new Regex(pattern);
            double totalPrice = 0;

            List<Soft> bar = new List<Soft>();

            while (input != "end of shift")
            {
                
                Match currentShift = regex.Match(input);
                if (currentShift.Success)
                {
                    string name = currentShift.Groups[1].Value;
                    int count = int.Parse(currentShift.Groups[3].Value);
                    string product = currentShift.Groups[2].Value;
                    double price = double.Parse(currentShift.Groups[4].Value) * count;

                    Soft newPerson = new Soft(name, product, price);
                    bar.Add(newPerson);
                    totalPrice += price;
                }
                input = Console.ReadLine();
            }
            if (bar.Count != 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, bar));
                Console.WriteLine($"Total income: {totalPrice:f2}");
            } 

        }
    }

    class Soft
    {
        public Soft(string person, string product, double price)
        {
            Person = person;
            Product = product;
            Price = price;
        }

        public string Person { get; set; }
        public string Product { get; set; }

        public double Price { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{Person}: {Product} - {Price:f2}");
            return sb.ToString();
        }


    }
}