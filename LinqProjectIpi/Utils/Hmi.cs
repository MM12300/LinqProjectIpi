using System;
using System.Globalization;

namespace LinqProjectIpi.Utils
{
    public class Hmi
    {
        public static void showTitle(string title)
        {
            Console.Clear();
            centeredOutput("-..-=-..-=-..-=-..-=-..-=-..-=-..-=-..-=-..-=-..-=-..-");
            centeredOutput(title);
            centeredOutput("-..-=-..-=-..-=-..-=-..-=-..-=-..-=-..-=-..-=-..-=-..-");
        }

        public static void centeredOutput(string input){
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (input.Length / 2)) + "}", input));
        }

        public static void pushEnter()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Push enter to continue...");
            Console.ResetColor();
            Console.ReadLine();
        }

        public static void wrongOptions()
        {
            Console.WriteLine("------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Choose from mentionned options only");
            Console.ResetColor();
            Console.WriteLine("------------------------------------------");
            pushEnter();
        }

        public static string cleanOutput(string input)
        {
            input = input.Replace("_", " ");
            return toPascalCase(input);
        }

        private static string toPascalCase(string input){
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower()); 
        }


        public static void main(){
            Hmi.start();
            Hmi.options();
            Console.ReadLine();
        }

        public static void start()
        {
            Console.Clear();
            Hmi.showTitle("Welcome to Raphaël's and Matthieu's project :-)");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            centeredOutput("                            :::           :::::::::::          ::::    :::          ::::::::                      ");
            centeredOutput("                           :+:               :+:              :+:+:   :+:         :+:    :+:                      ");
            centeredOutput("                          +:+               +:+              :+:+:+  +:+         +:+    +:+                       ");
            centeredOutput("   +#++:++#++:++         +#+               +#+              +#+ +:+ +#+         +#+    +:+        +#++:++#++:++   ");
            centeredOutput("                        +#+               +#+              +#+  +#+#+#         +#+    +#+                         ");
            centeredOutput("                       #+#               #+#              #+#   #+#+#         #+#    #+##                         ");
            centeredOutput("                      ##########    ###########          ###    ####          ##############                      ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Here are our two data-sets:");
        }

        public static void options()
        {
            Console.WriteLine("Choose an option :");
            Console.WriteLine("1 - Space Missions since 1957");
            Console.WriteLine("2 - Star Wars Characters");
            Console.WriteLine("3 - Quit");
            Console.WriteLine();
            Console.WriteLine("\r\n Choose an option (1,2,3)");

            switch (Console.ReadLine())
                {
                    case "1":                        
                        SpaceMissionHMI hmi = new SpaceMissionHMI();
                        hmi.main();
                        break;

                    case "2":
                        StarWarsCharactersHMI starwarscharactersHMI = new StarWarsCharactersHMI();
                        starwarscharactersHMI.main();
                        break;

                    case "3":
                        Console.WriteLine("Exiting the program...");
                        break;

                    default:
                        Console.WriteLine("Choose from one on these options only !");
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine();
                        main();
                        break;
                        
                }
            }
        
    }
}