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
        
    }
}