using System;
using System.Linq;
using System.IO;
using System.Xml.Linq;

namespace LinqProjectIpi
{
    public class Starwarscharacters
    {
        private XElement xmlFile = XElement.Load($@"{Directory.GetCurrentDirectory()}/XML/starwarscharacters.xml");

        public void getAllcharacters()
        {
            var characters = from element in xmlFile.Descendants("characters")
                             select element;

            foreach(var character in characters)
            {
                Console.WriteLine(character.Value);
            }
        }


    }
}