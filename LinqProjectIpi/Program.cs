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

            start();
            string option = options();
            Console.WriteLine(option);
            Console.ReadLine();
        }

        static void start()
        {
            Console.Clear();
            Console.WriteLine("-..-=-..-=-..-=-..-=-..-=-..-=-..-=-..-=-..-=-..-=-..-");
            Console.WriteLine("Bienvenue sur le projet Linq de Raphaël et Matthieu :-)");
            Console.WriteLine("-..-=-..-=-..-=-..-=-..-=-..-=-..-=-..-=-..-=-..-=-..-");
            Console.WriteLine("Nous allons vous présenter deux jeux de données :");
        }

        static string options()
        {
            Console.WriteLine("Choississez votre option :");
            Console.WriteLine("1 - Les missions spatiales depuis 1957");
            Console.WriteLine("2 - Les personnages de l'univers Star Wars");
            Console.WriteLine("3 - Fin du programme");
            Console.WriteLine();
            Console.WriteLine("\r\n Choississez une option (1 2 ou 3)");

            switch (Console.ReadLine())
                {
                    case "1":                        
                        Console.WriteLine("Les missions spatiales depuis 1957");
                        return "space";
                    case "2":
                        Console.WriteLine("In Option 2");
                        Starwarscharacters starwarscharacters = new Starwarscharacters();
                        starwarscharacters.getAllcharacters();
                    return "starwars";
                    case "3":
                        Console.WriteLine("Exiting the program...");
                        return "exit";
                    default:
                        Console.WriteLine("Choississez une des 3 options uniquement !");
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine();

                        return options();
                }
            }
    }
}
