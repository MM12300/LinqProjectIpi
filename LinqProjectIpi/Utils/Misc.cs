using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Xml;
using LinqProjectIpi.SpaceMissions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace LinqProjectIpi.Utils
{
    public class Misc
    {

        
        public static DateTime parseRFC1123Date(string date){
            date = date.Replace("UTC", "");
            DateTime result = DateTime.Parse(date);
            return result;
        }

        public static void saveJsonToXml(){
            var json = File.ReadAllText($@"{Directory.GetCurrentDirectory()}/JSON/spacemission.json");
            XmlDocument doc = JsonConvert.DeserializeXmlNode(json, "AllMissions");
            Console.WriteLine(doc.ToString());
            File.WriteAllText(@"./XML/spacemission.xml", doc.OuterXml);   
       
        }

        public static void saveXmlToJson(){
            XElement xmlFile = XElement.Load($@"{Directory.GetCurrentDirectory()}/XML/starwarscharacters.xml");

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlFile.ToString());

            string jsonText = JsonConvert.SerializeXmlNode(doc);
            File.WriteAllText(@"./JSON/starwarscharacters.json", jsonText);
            Console.WriteLine("The Star Wars dataset has been converted from XML to JSON");
            Hmi.pushEnter();
        }
        
    }
}