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
            Console.WriteLine("2 - Search Mode");
            Console.WriteLine("3 - Return to main menu");
            Console.WriteLine();
            Console.WriteLine("\r\n Choose an option (1)");

            switch (Console.ReadLine())
                {
                case "1":                        
                    Console.WriteLine("Displays all Star Wars Characters Names");
                    getAllCharactersDetails();
                    main();
                    break;

                case "2":
                    Console.WriteLine("Search characters with different criterias");
                    searchMenu();
                    main();
                    break;

                case "3":
                    Console.WriteLine("Return to main menu");
                    //TODO: faire un retour au menu principal
                    break;

                default:
                    wrongOptions();
                    options();
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

            characterOutput(allcharacters);
            pushEnter();
        }

        public void characterOutput(IEnumerable<XElement> allcharacters)
        {
            foreach (XElement character in allcharacters)
            {
                string output = "";
                foreach (var element in character.Elements())
                {
                    if (element.Value != "none" && element.Value != "NA")
                    {
                        if(element.Name == "Height")
                        {
                            output += element.Name + " : " + element.Value + "cm" + "\r\n";
                        }
                        else if(element.Name == "Mass")
                        {
                            output += element.Name + " : " + element.Value + "kg" + "\r\n";
                        }
                        else
                        {
                            output += element.Name + " : " + element.Value + "\r\n";
                        }

                    }
                }
                output = cleanOutput(output);
                Console.WriteLine(output);
                Console.WriteLine("--");
            }
        }

        public string cleanOutput(string output)
        {
            output = output.Replace("skin_color", "Skin Color");
            output = output.Replace("hair_color", "Hair Color");
            output = output.Replace("eye_color", "Eye Color");
            output = output.Replace("birth_year", "Birth Year");
            return output;
        }

        public void searchMenu()
        {
            Console.WriteLine("Search by :");
            Console.WriteLine("1 - Name");
            Console.WriteLine("2 - Height");
            Console.WriteLine("3 - Mass");
            Console.WriteLine("4 - Hair");
            Console.WriteLine("5 - Skin");
            Console.WriteLine("6 - Eye");
            Console.WriteLine("7 - Birth Year");
            Console.WriteLine("8 - Gender");
            Console.WriteLine("9 - Homeworld");
            Console.WriteLine("10 - Specie");
            Console.WriteLine("11 - Return to Star Wars Menu");
            Console.WriteLine();
            Console.WriteLine("\r\n Choose an option)");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Search characters by name");
                    getCharactersBy("Name");
                    searchMenu();
                    break;
                case "2":
                    Console.WriteLine("Search characters by height");
                    getCharactersBy("Height");
                    searchMenu();
                    break;
                case "3":
                    Console.WriteLine("Search characters by mass");
                    getCharactersBy("Mass");
                    searchMenu();
                    break;
                case "4":
                    Console.WriteLine("Search characters by hair color");
                    getCharactersBy("hair_color");
                    searchMenu();
                    break;
                case "5":
                    Console.WriteLine("Search characters by skin color");
                    getCharactersBy("skin_color");
                    searchMenu();
                    break;
                case "6":
                    Console.WriteLine("Search characters by eye color");
                    getCharactersBy("eye_color");
                    searchMenu();
                    break;
                case "7":
                    Console.WriteLine("Search characters by birth year");
                    getCharactersBy("birth_year");
                    searchMenu();
                    break;
                case "8":
                    Console.WriteLine("Search characters by gender");
                    getCharactersBy("Gender");
                    searchMenu();
                    break;
                case "9":
                    Console.WriteLine("Search characters by homeworld");
                    getCharactersBy("Homeworld");
                    searchMenu();
                    break;
                case "10":
                    Console.WriteLine("Search characters by specie");
                    getCharactersBy("Specie");
                    searchMenu();
                    break;
                case "11":
                    Console.WriteLine("'Return to main menu");
                    main();
                    break;

                default:
                    wrongOptions();
                    searchMenu();
                    break;
            }
        }
   

        public void getCharactersBy(string criteria)
        {
            IEnumerable<XElement> characters = Enumerable.Empty<XElement>();
            Console.WriteLine("What " + criteria + " would you like to search characters by ?");

            if(criteria == "Gender")
            {
                Console.WriteLine("Filter by :");
                Console.WriteLine("1 - male character(s)");
                Console.WriteLine("2 - female character(s)");
                switch (Console.ReadLine())
                {
                    case "1":
                        characters = from element in xmlFile.Descendants("character")
                                     where element.Element("Gender").Value == "male"
                                     select element;
                        break;
                    case "2":
                        characters = from element in xmlFile.Descendants("character")
                                     where element.Element("Gender").Value == "female"
                                     select element;
                        break;
                    default:
                        wrongOptions();
                        break;
                }
            }
            else
            {
                string search = Console.ReadLine();
                characters = from element in xmlFile.Descendants("character")
                             where element.Element(criteria).Value.Contains(search, StringComparison.InvariantCultureIgnoreCase)
                             select element;
            }

            characterOutput(characters);
            Console.ReadLine();
        }

        public void pushEnter()
        {
            Console.WriteLine("Push enter to continue...");
            Console.ReadLine();
        }

        public void wrongOptions()
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Choose from mentionned options only");
            Console.WriteLine("------------------------------------------");
            pushEnter();
        }
    }
}