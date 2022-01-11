using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace LinqProjectIpi
{
    public class SpaceMissions{

        private JObject missionCollection = JObject.Parse(File.ReadAllText($@"{Directory.GetCurrentDirectory()}/JSON/spacemission.json"));
        private String collectionName = "AllMissions";


        public void main(){
            
        }

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
            //Compagnies
            var companies = simpleSelectRequest("Company Name").Distinct();
            
            //Affichage
            foreach (var companie in companies){
                Console.WriteLine(companie);
            }
            
        }

        public void getLocations(){

            //Location
            var locations = simpleSelectRequest("Location").Distinct();

            //Affichage
            foreach (var location in locations){
                var country = location.ToString().Split(",").Last();
                Console.WriteLine(country);
            }
        }

        public void searchByLocation(){

        }


        private IEnumerable<JToken> simpleSelectRequest(string fieldName){
            var elements = from element in missionCollection[collectionName]                
                select element[fieldName];

                return elements;        
        }


    }
}