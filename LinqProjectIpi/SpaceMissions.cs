using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace LinqProjectIpi
{
    public class SpaceMissions{
        public void JsonTest()
        {
            var myJson = JObject.Parse(File.ReadAllText($@"{Directory.GetCurrentDirectory()}/JSON/spacemission.json"));

            var marequete = from mission in myJson["AllMissions"]
                            where mission["Status Rocket"].ToString().Contains("StatusActive", StringComparison.InvariantCultureIgnoreCase) select mission
                            ;

            foreach (var mission in marequete)
            {
                Console.WriteLine(mission);
            }
        }
    }
}