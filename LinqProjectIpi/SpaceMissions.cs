using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace LinqProjectIpi
{
    public class SpaceMissions{

        private JObject missionCollection = JObject.Parse(File.ReadAllText($@"{Directory.GetCurrentDirectory()}/JSON/spacemission.json"));

        public void getAllMissions(){

            //Requête
            var missions = from mission in missionCollection["AllMissions"]
                            where mission["Status Rocket"].ToString().Contains("StatusActive", StringComparison.InvariantCultureIgnoreCase) 
                            select mission;

            //Affichage
            foreach (var mission in missions){
                Console.WriteLine(mission);
            }
        }

        public void getCompanies(){
            
        }
    }
}