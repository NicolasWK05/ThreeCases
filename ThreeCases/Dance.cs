using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeCases
{
    internal class Dance
    {
        public string Name { get; set; }
        public int Points { get; set; }

        public void Grade()
        {
            Console.WriteLine("Enter name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter points:");
            int points = int.Parse(Console.ReadLine());

            Name = name;
            Points = points;
            Console.WriteLine("Done");
        }

        public static Dance operator+ (Dance a, Dance b)
        {
            Dance partners = new Dance();
            partners.Points = a.Points + b.Points;
            partners.Name = a.Name + " & " + b.Name;
            return partners;
        }
    }
}
