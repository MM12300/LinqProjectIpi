using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqProjectIpi.Utils;

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
            Hmi.showTitle("Welcome to Raphaël's and Matthieu's  Linq project :-)");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                            :::           :::::::::::          ::::    :::          ::::::::                      ");
            Console.WriteLine("                           :+:               :+:              :+:+:   :+:         :+:    :+:                      ");
            Console.WriteLine("                          +:+               +:+              :+:+:+  +:+         +:+    +:+                       ");
            Console.WriteLine("   +#++:++#++:++         +#+               +#+              +#+ +:+ +#+         +#+    +:+        +#++:++#++:++   ");
            Console.WriteLine("                        +#+               +#+              +#+  +#+#+#         +#+    +#+                         ");
            Console.WriteLine("                       #+#               #+#              #+#   #+#+#         #+#    #+##                         ");
            Console.WriteLine("                      ##########    ###########          ###    ####          ##############                      ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Here are our two data-sets:");
        }

        static string options()
        {
            Console.WriteLine("Choose an option :");
            Console.WriteLine("1 - Space Missions from 1957");
            Console.WriteLine("2 - Star Wars Characters");
            Console.WriteLine("3 - Quit");
            Console.WriteLine();
            Console.WriteLine("\r\n Choose an option (1,2,3)");

            switch (Console.ReadLine())
                {
                    case "1":                        
                        Console.WriteLine("Space Missions from 1957");
                        SpaceMissionHMI hmi = new SpaceMissionHMI();
                        hmi.main();
                        return "space";

                    case "2":
                        Console.WriteLine("Star Wars Characters");
                        StarWarsCharactersHMI starwarscharactersHMI = new StarWarsCharactersHMI();
                        starwarscharactersHMI.main();
                        return "starwars";

                    case "3":
                        Console.WriteLine("Exiting the program...");
                        return "exit";

                    default:
                        Console.WriteLine("Choose from one on these options only !");
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine();

                        return options();
                }
            }
    }
}
