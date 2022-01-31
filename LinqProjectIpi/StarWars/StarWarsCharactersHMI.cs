using System;
using System.Linq;
using System.IO;
using System.Xml.Linq;
using System.Collections.Generic;
using LinqProjectIpi.Utils;

namespace LinqProjectIpi
{
    public class StarWarsCharactersHMI{

        private XElement xmlFile = XElement.Load($@"{Directory.GetCurrentDirectory()}/XML/starwarscharacters.xml");

        public void main(){
            Console.WriteLine(Directory.GetCurrentDirectory());
            Hmi.showTitle("Star Wars Characters");
            options();
        }

        void options()
        {
            Console.WriteLine("Choose an option :");
            Console.WriteLine("1 - All Characters Details");
            Console.WriteLine("2 - Search Mode");
            Console.WriteLine("3 - Characters by special traits");
            Console.WriteLine("4 - Return to main menu");
            Console.WriteLine();
            Console.WriteLine("\r\n Choose an option (1,2,3)");

            switch (Console.ReadLine())
                {
                case "1":                        
                    Console.WriteLine("Displays all Star Wars Characters Names");
                    getAllCharactersDetails();
                    main();
                    break;

                case "2":
                    Console.WriteLine();
                    Console.WriteLine("Search characters with different criterias");
                    searchMenu();
                    main();
                    break;

                case "3":
                    Console.WriteLine();
                    Console.WriteLine("Search characters with special traits");
                    specialTraits();
                    main();
                    break;

                case "4":
                    Console.WriteLine("Return to main menu");
                    //TODO: faire un retour au menu principal
                    break;

                default:
                    Hmi.wrongOptions();
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
            Hmi.pushEnter();
        }

        public void characterOutput(IEnumerable<XElement> allcharacters)
        {
            string output = "";
            if (allcharacters.Any() && allcharacters != null )
            {
                foreach (XElement character in allcharacters)
                {
                    foreach (var element in character.Elements())
                    {
                        if (element.Value != "none" && element.Value != "NA")
                        {
                            if (element.Name == "Height")
                            {
                                output += element.Name + " : " + element.Value + "cm" + "\r\n";
                            }
                            else if (element.Name == "Mass")
                            {
                                output += element.Name + " : " + element.Value + "kg" + "\r\n";
                            }
                            else
                            {
                                output += element.Name + " : " + element.Value + "\r\n";
                            }
                        }
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                output = "No Results";
            }
            output = Hmi.cleanOutput(output);
            Console.WriteLine(output);
            Console.ResetColor();
            Console.WriteLine("--");
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
            Console.WriteLine("\r\n Choose an option");

            switch (Console.ReadLine())
            {
                case "1":
                    searchProcess("Name");
                    searchMenu();
                    break;
                case "2":
                    searchProcess("Height");
                    searchMenu();
                    break;
                case "3":
                    searchProcess("Mass");
                    searchMenu();
                    break;
                case "4":
                    searchProcess("hair_color");
                    searchMenu();
                    break;
                case "5":
                    searchProcess("skin_color");
                    searchMenu();
                    break;
                case "6":
                    searchProcess("eye_color");
                    searchMenu();
                    break;
                case "7":
                    searchProcess("birth_year");
                    searchMenu();
                    break;
                case "8":
                    searchProcess("Gender");
                    searchMenu();
                    break;
                case "9":
                    searchProcess("Homeworld");
                    searchMenu();
                    break;
                case "10":
                    searchProcess("Specie");
                    searchMenu();
                    break;
                case "11":
                    main();
                    break;

                default:
                    Hmi.wrongOptions();
                    searchMenu();
                    break;
            }
        }
   

        public void getCharactersBy(string criteria, string filter, string search)
        {
            IEnumerable<XElement> characters = Enumerable.Empty<XElement>();

            if (search == "male")
            {
                characters = from element in xmlFile.Descendants("character")
                             orderby element.Element(filter).Value ascending
                             where element.Element("Gender").Value == "male"
                             select element;
            }else if(search == "female")
            {
                characters = from element in xmlFile.Descendants("character")
                                orderby element.Element(filter).Value ascending
                                where element.Element("Gender").Value == "female"
                                select element;
            }          
            else
            {
                characters = from element in xmlFile.Descendants("character")
                             orderby element.Element(filter).Value ascending
                             where element.Element(criteria).Value.Contains(search, StringComparison.InvariantCultureIgnoreCase)
                             select element;
            }

            characterOutput(characters);
            Console.WriteLine("Lets go for another search !");
            Hmi.pushEnter();
        }

        public string characterOrder(string searchBy, string searchValue)
        {
            Console.WriteLine();
            Console.WriteLine("Order your result by :");
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
            Console.WriteLine();
            Console.WriteLine("\r\n Choose an option");

            string orderBy = "";

            switch (Console.ReadLine())
            {
                case "1":
                    orderBy = "Name";
                    break;
                case "2":
                    orderBy = "Height";
                    break;
                case "3":
                    orderBy = "Mass";
                    break;
                case "4":
                    orderBy = "hair_color";
                    break;
                case "5":
                    orderBy = "skin_color";
                    break;
                case "6":
                    orderBy = "eye_color";
                    break;
                case "7":
                    orderBy = "birth_year";
                    break;
                case "8":
                    orderBy = "Gender";
                    break;
                case "9":
                    orderBy = "Homeworld";
                    break;
                case "10":
                    orderBy = "Specie";
                    break;
                default:
                    Hmi.wrongOptions();
                    characterOrder(searchBy, searchValue);
                    break;
            }

            if(searchBy == orderBy)
            {
                Console.WriteLine("You can't order by {0} as you search by {1}", Hmi.cleanOutput(orderBy), Hmi.cleanOutput(searchBy));
                Console.WriteLine("Please specify again what you would like to order your search by");
                Hmi.pushEnter();
                return characterOrder(searchBy, searchValue);
            }
            else
            {
                Console.WriteLine("You want to search the --{0}-- : {1} ordered by --{2}--", Hmi.cleanOutput(searchBy), searchValue, Hmi.cleanOutput(orderBy));
                confirmSearch();
                return orderBy;
            }
        }

        public void searchProcess(string criteria)
        {
            string search = "";
            Console.WriteLine();
            if (criteria == "Gender")
            {
                Console.WriteLine("Search characters by {0}", Hmi.cleanOutput(criteria));
                Console.WriteLine("Choose :");
                Console.WriteLine("1 - male character(s)");
                Console.WriteLine("2 - female character(s)");
                Console.WriteLine();
                Console.WriteLine("\r\n Choose an option");

                switch (Console.ReadLine())
                {
                    case "1":
                        search = "male";
                        break;
                    case "2":
                        search = "female";
                        break;
                    default:
                        Hmi.wrongOptions();
                        searchProcess("gender");
                        break;
                }
                string order = characterOrder(criteria, search);
                getCharactersBy(criteria, order, search);
            }
            else
            {
                Console.WriteLine("Search characters by {0}", Hmi.cleanOutput(criteria));
                Console.WriteLine("Which --{0}-- would you like to search for ?", Hmi.cleanOutput(criteria));
                search = Console.ReadLine();
                string order = characterOrder(criteria, search);
                getCharactersBy(criteria, order, search);
            }
        }

        public void confirmSearch()
        {
            Console.WriteLine("Do you confirm this research ?");
            Console.WriteLine("1 - Yes");
            Console.WriteLine("2 - No");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine();
                    Console.WriteLine("Research Confirmed");
                    Hmi.pushEnter();
                    break;
                case "2":
                    Console.WriteLine();
                    Console.WriteLine("Return to Star Wars main menu :-(");
                    Hmi.pushEnter();
                    searchMenu();
                    break;
                default:
                    Hmi.wrongOptions();
                    break;
            }
        }

        public void specialTraits()
        {
            Console.WriteLine("Which characters special traits would you like to explore ?");
            Console.WriteLine("1 - The giants : size >= 190cm");
            Console.WriteLine("2 - The midgets : size <= 120cm");
            Console.WriteLine("3 - The light-ones : mass <= 50kg");
            Console.WriteLine("4 - The big-ones : size >= 150kg");
            Console.WriteLine("5 - The elders : age >= 100 years old");
            Console.WriteLine("6 - Return to Star Wars menu");
            switch (Console.ReadLine())
            {
                case "1":
                    getCharactersBySpecialTraits("giants");
                    specialTraits();
                    break;
                case "2":
                    getCharactersBySpecialTraits("midgets");
                    specialTraits();
                    break;
                case "3":
                    getCharactersBySpecialTraits("light");
                    specialTraits();
                    break;
                case "4":
                    getCharactersBySpecialTraits("heavy");
                    specialTraits();
                    break;
                case "5":
                    getCharactersBySpecialTraits("old");
                    specialTraits();
                    break;
                case "6":
                    main();
                    break;
                default:
                    Hmi.wrongOptions();
                    break;
            }
        }

        public void getCharactersBySpecialTraits(string trait)
        {
            IEnumerable<XElement> characters = Enumerable.Empty<XElement>();
            if (trait == "giants")
            {
                characters = from element in xmlFile.Descendants("character")
                             orderby element.Element("Name").Value ascending
                             where element.Element("Height").Value != "NA" && int.Parse(element.Element("Height").Value) >= 200
                             select element;
            }else if (trait == "midgets")
            {
                characters = from element in xmlFile.Descendants("character")
                             orderby element.Element("Name").Value ascending
                             where element.Element("Height").Value != "NA" && int.Parse(element.Element("Height").Value) <= 120
                             select element;
            }
            else if (trait == "light")
            {
                characters = from element in xmlFile.Descendants("character")
                             orderby element.Element("Name").Value ascending
                             where element.Element("Mass").Value != "NA" && int.Parse(element.Element("Mass").Value) <= 50
                             select element;
            }
            else if (trait == "heavy")
            {
                characters = from element in xmlFile.Descendants("character")
                             orderby element.Element("Name").Value ascending
                             where element.Element("Mass").Value != "NA" && int.Parse(element.Element("Mass").Value) >= 100
                             select element;
            }
            else if (trait == "old")
            {
                characters = from element in xmlFile.Descendants("character")
                             orderby element.Element("Name").Value ascending
                             where element.Element("birth_year").Value != "NA" && int.Parse(element.Element("birth_year").Value) >= 100
                             select element;
            }

            characterOutput(characters);
            Hmi.pushEnter();
        }
    }
}