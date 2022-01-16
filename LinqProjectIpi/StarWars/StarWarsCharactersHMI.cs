using System;
using System.Linq;
using System.IO;
using System.Xml.Linq;
using System.Collections.Generic;

namespace LinqProjectIpi
{
    public class StarWarsCharactersHMI{

        private XElement xmlFile = XElement.Load($@"{Directory.GetCurrentDirectory()}/XML/starwarscharacters.xml");

        public void main(){
            Console.WriteLine(Directory.GetCurrentDirectory());
            start();
            options();
        }

        void start()
        {
            Console.Clear();
            Console.WriteLine("-..-=-..-=-..-=-..-=-..-=-..-=-..-=-..-=-..-=-..-=-..-");
            Console.WriteLine("Star Wars Characters");
            Console.WriteLine("-..-=-..-=-..-=-..-=-..-=-..-=-..-=-..-=-..-=-..-=-..-");
        }

        void options()
        {
            Console.WriteLine("Choose an option :");
            Console.WriteLine("1 - All Characters Details");
            Console.WriteLine();
            Console.WriteLine("\r\n Choose an option (1)");

            switch (Console.ReadLine())
                {
                    case "1":                        
                        Console.WriteLine("Displays all Star Wars Characters Names");
                        getAllCharactersDetails();
                        main();
                        break;
                        
                    default:
                        Console.WriteLine("Choose from mentionned options only");
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine();
                        break;
                }
            }


        public void getAllcharacters()
        {
            var characters = from element in xmlFile.Descendants("character")
                             select element;

            foreach (var character in characters)
            {
                Console.WriteLine(character.Value);
            }
        }

        public void getAllCharactersDetails()
        {
            IEnumerable<XElement> allcharacters = from characters in xmlFile.Descendants("character")
                                                  select characters;

            foreach (XElement character in allcharacters)
            {
                string output = "";
                foreach (var element in character.Elements())
                {
                    if (element.Value != "none" && element.Value != "NA")
                    {
                        output += element.Name + " : " + element.Value + "\r\n";
                    }
                }
                output = cleanOutput(output);
                Console.WriteLine(output);
                Console.WriteLine("--");
            }
            Console.ReadLine();
        }


        public string cleanOutput(string output)
        {
            output = output.Replace("skin_color", "Skin Color");
            output = output.Replace("hair_color", "Hair Color");
            output = output.Replace("eye_color", "Eye Color");
            output = output.Replace("birth_year", "Birth Year");
            return output;
        }
    }
}