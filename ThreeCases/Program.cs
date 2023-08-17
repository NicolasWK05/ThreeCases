using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeCases
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Password password = new Password();
            password.isLoggedIn = false;
            
            // Initial login
            do
            {
                // Checking if there already exists a password
                while (password.ReadPass() == "" || password.ReadPass() == null)
                {
                    Console.WriteLine("You have to make a password first, here's the requirements for the password:\n" +
                        "1. Password needs to be a minimum of 12 characters.\n" +
                        "2. Password needs to include both lowercase and uppercase letters.\n" +
                        "3. Password needs to contain one of these special characters: ! \" # $ % & '\n" +
                        "4. Numbers are not allowed in either end of the password.\n" +
                        "5. Password can't contain a space.\n" +
                        "6. Password can't be all lowercase\n" +
                        "7. Password can't be the same as an old password");
                    password.SetPass();
                    Console.Clear();
                }

                Console.WriteLine("Enter your password:");
                string pass = Console.ReadLine();
                if(pass == password.ReadPass())
                {
                    Console.WriteLine("You successfully logged in!");
                    password.isLoggedIn = true;
                } else
                {
                    Console.WriteLine("Password is wrong, try again.");
                }
            } while (!password.isLoggedIn);

            bool mainLoop = true;
            while(mainLoop)
            {
                Console.WriteLine("What do you want to do now?\n" +
                    "1. Football\n" +
                    "2. Dance grading\n" +
                    "3. Change password\n" +
                    "4. Exit");
                int.TryParse(Console.ReadLine(), out int choice);
                switch (choice)
                {
                    case 1:
                        Console.WriteLine(Football.FootballPasses());
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        Dance person1 = new Dance();
                        Dance person2 = new Dance();

                        person1.Grade();
                        person2.Grade();

                        Dance pair = person1 + person2;

                        Console.WriteLine($"{pair.Name} {pair.Points}");
                        
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        Console.WriteLine("Here's the requirements for the password:\n" +
                            "1. Password needs to be a minimum of 12 characters.\n" +
                            "2. Password needs to include both lowercase and uppercase letters.\n" +
                            "3. Password needs to contain one of these special characters: ! \" # $ % & '\n" +
                            "4. Numbers are not allowed in either end of the password.\n" +
                            "5. Password can't contain a space.\n" +
                            "6. Password can't be all lowercase\n" +
                            "7. Password can't be the same as an old password");
                        password.SetPass();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                }
            }

            
            
        }
    }
}
