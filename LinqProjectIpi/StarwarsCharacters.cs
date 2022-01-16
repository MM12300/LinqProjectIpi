using System;
using System.Linq;
using System.IO;
using System.Xml.Linq;
using System.Collections.Generic;

namespace LinqProjectIpi
{
    public class Starwarscharacters
    {
        private XElement xmlFile = XElement.Load($@"{Directory.GetCurrentDirectory()}/XML/starwarscharacters.xml");

        public void getAllcharacters()
        {
            var characters = from element in xmlFile.Descendants("character")
                             select element;

            foreach(var character in characters)
            {
                Console.WriteLine(character.Value);
            }
        }

        public void getAllCharactersNames()
        {
            var characters = from element in xmlFile.Descendants("character")
                             select element.Element("name");

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
                foreach(var element in character.Elements())
                {
                    if(element.Value != "none" && element.Value != "NA")
                    {
                        output += element.Name + " : " + element.Value + "\r\n";
                    }
                }
                Console.WriteLine(output);
                Console.WriteLine("--");
            }
        }


        public string cleanOutput(string output, string sex)
        {
            output = output.Replace("skin_color", "Skin Color");
            output = output.Replace("hair_color", "Hair Color");
            output = output.Replace("eye_color", "Eye Color");
            output = output.Replace("birth_year", "Birth Year");
            return output;
        }


    }
}