using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeCases
{
    internal class Password
    {
        public bool isLoggedIn { get; set; }

        public string ReadPass()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "password.txt");
            string text = "";
            try
            {
                text = File.ReadAllText(path);
            } catch
            {
            }

            return text;
        }

        public void SetPass()
        {
            string passInput = Console.ReadLine();

            if(!MinLength(passInput))
            {
                Console.WriteLine("Password needs to be a minimum of 12 characters.");
                Console.ReadKey();
                return;
            }
            if(!CapitalLetters(passInput))
            {
                Console.WriteLine("Password needs to include both lowercase and uppercase letters.");
                Console.ReadKey();
                return;
            }
            if(!SpecialCharacters(passInput))
            {
                Console.WriteLine("Password needs to contain one of these special characters: ! \" # $ % & '");
                Console.ReadKey();
                return;
            }
            if (!NumbersInEnds(passInput))
            {
                Console.WriteLine("Numbers are not allowed in either end of the password");
                Console.ReadKey();
                return;
            }
            if(!ContainsSpace(passInput))
            {
                Console.WriteLine("Password can't contain a space");
                Console.ReadKey();
                return;
            }
            if (!ToLower(passInput)) // What a useless check, but sure I'll do it...
            {
                Console.WriteLine("Password can't be all lowercase");
                Console.ReadKey();
                return;
            }
            if(!OldPassword(passInput))
            {
                Console.WriteLine("Password can't be same as an old password");
                Console.ReadKey();
                return;
            }

            // Record current password in the old.txt file
            string oldPath = Path.Combine(Directory.GetCurrentDirectory(), "old.txt");
            string currntPass = ReadPass() + "\n";
            File.AppendAllText(oldPath, currntPass);
            

            string path = Path.Combine(Directory.GetCurrentDirectory(), "password.txt");
            File.WriteAllText(path, passInput);
        }

        bool MinLength(string pass)
        {
            if (pass.Length < 12) return false;
            return true;
        }

        bool CapitalLetters(string pass)
        {
            bool lowerCase = false;
            bool upperCase = false;
            for(int i = 0; i < pass.Length; i++)
            {
                if (Char.IsLower(pass[i])) lowerCase = true;
                else upperCase = true;
            }
            if(lowerCase && upperCase) return true;
            return false;
        }

        bool SpecialCharacters(string pass)
        {
            // Array of special characters to include in pass
            char[] array = new char[] { char.Parse("!"), char.Parse("\""), char.Parse("#"), char.Parse("$"), char.Parse("%"), char.Parse("&"), char.Parse("'") };

            bool specialChar = false;
            bool number = false;

            for(int i = 0; i < pass.Length;i++)
            {
                char c = pass[i];
                if (array.Contains(c))
                {
                    specialChar = true;
                } else if (char.IsDigit(c)) {
                    number = true;
                }
            }
            if(number && specialChar) return true;
            return false;
        }

        bool NumbersInEnds(string pass)
        {
            char first = pass[0];
            char last = pass[pass.Length - 1];

            if (char.IsNumber(first) || char.IsNumber(last)) return false;
            return true;
        } 

        bool ContainsSpace(string pass)
        {
            if (pass.Contains(" ")) return false;
            return true;
        }

        bool ToLower(string pass)
        {
            if (pass.ToLower() == pass) return false;
            return true;
        }

        bool OldPassword(string pass)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "old.txt");

            string text = "";
            try
            {
                text = File.ReadAllText(path);
            } catch
            {
                // If the file doesn't exist, then there's no old passwords
                return true;
            }


            string[] passwords = text.Split('\n');
            for (int i = 0; i < passwords.Length; i++) if (pass == passwords[i]) return false;
            return true;
        }

    }
}
