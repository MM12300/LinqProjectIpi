using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqProjectIpi
{
    class Program
    {
        static void Main(string[] args)
        {

            Menu();
        }

        private void Menu(){
            Console.Clear();

            Console.WriteLine("-..-=-..-=-..-=-..-=-..-=-..-=-..-=-..-=-..-=-..-=-..-");
            Console.WriteLine("                 Welcome to this Project");
            Console.WriteLine("-..-=-..-=-..-=-..-=-..-=-..-=-..-=-..-=-..-=-..-=-..-");

            Console.WriteLine("Choose your option:");
            Console.WriteLine("1) Option 1");
            Console.WriteLine("2) Option 2");
            Console.WriteLine("3) Exit");

            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("In Option 1");


                    case "2":
                        Console.WriteLine("In Option 2");


                    case "3":
                        Console.WriteLine("Exiting the program...");
                        return null;

                    default:
                        Console.WriteLine("Bad input, exiting the program...");
                        return null;
                }
            }
    }
}
