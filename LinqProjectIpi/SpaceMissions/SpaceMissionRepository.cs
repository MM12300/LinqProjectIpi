using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.IO;
using LinqProjectIpi.Utils;

namespace LinqProjectIpi.SpaceMissions
{
    public class SpaceMissionRepository
    {

        private JObject missionCollection = JObject.Parse(File.ReadAllText($@"{Directory.GetCurrentDirectory()}/JSON/spacemission.json"));
        private String collectionName = "AllMissions";
        
        public void getAllMissions(){
            Hmi.centeredOutput("All missions since 1957:");
            //Requête
            var missions = selectMissions();
            //Affichage
            cappedChoice(missions.ToList());
        }

        public void getCompanies(){
            //Compagnies
            var companies = selectRequest("Company Name").Distinct();            
            //Affichage
            foreach (var companie in companies){
                Console.WriteLine(companie);
            }            
        }

        public void getCountries(){

            //Location
            var locations = selectRequest("Location").Distinct();
            List<string> countries = new List<string>();
            //Récupération des pays
            foreach (var location in locations){
                var country = location.ToString().Split(",").Last();
                countries.Add(country);
            }
            //Nettoyage des doublons dans la liste des pays et affichage
            foreach (var country in countries.Distinct()){
                Console.WriteLine(country);
            }
        }

        public void searchByLocation(){
            //Affichage de la liste des pays
            getCountries();
            Console.WriteLine("Enter the location to retrieve the associated missions ...");
            //CHoix de l'utilisateur pour le pays
            var userInput = Console.ReadLine();
            //Récupération des missions
            var missions = whereRequest("Location", userInput);
            //Affichage
            cappedChoice(missions.ToList());
        }

        public void searchByCompany(){
            //Affichage de la liste des sociétés
            getCompanies();
            Console.WriteLine("Enter the company's name to retrieve the associated missions ...");
            //CHoix de l'utilisateur pour la société
            var userInput = Console.ReadLine();
            //Récupération des missions
            var missions = whereRequest("Company Name", userInput);
            //Affichage
            cappedChoice(missions.ToList());

        }

        private IEnumerable<JToken> selectRequest(string fieldName){
            var elements = from element in missionCollection[collectionName]                
                select element[fieldName];

            return elements;        
        }

        private IEnumerable<SpaceMission> selectMissions(){
            var missions = from mission in missionCollection["AllMissions"]
                select new SpaceMission(Convert.ToInt16(mission[""]), 
                            mission["Company Name"].ToString(), 
                            mission["Detail"].ToString(), 
                            mission["Status Rocket"].ToString(), 
                            mission["Status Mission"].ToString());

            return missions;
        }

        private IEnumerable<SpaceMission> whereRequest(string fieldName, string research){
            var elements = from element in missionCollection[collectionName]
                where element[fieldName].ToString().Contains(research, StringComparison.InvariantCultureIgnoreCase)
                select new SpaceMission(Convert.ToInt16(element[""]), 
                                        element["Company Name"].ToString(), 
                                        element["Detail"].ToString(), 
                                        element["Status Rocket"].ToString(), 
                                        element["Status Mission"].ToString());
            return elements;
        }

        public IEnumerable<SpaceMission> searchWithTwoParameters(string fiestFieldName, string secondFieldName, string firstParam, string secondParam){
            var elements = from element in missionCollection[collectionName]
                where element[firstParam].ToString().Contains(firstParam, StringComparison.InvariantCultureIgnoreCase) && 
                        element[secondFieldName].ToString().Contains(secondParam, StringComparison.InvariantCultureIgnoreCase)
                select new SpaceMission(Convert.ToInt16(element[""]), 
                                        element["Company Name"].ToString(), 
                                        element["Detail"].ToString(), 
                                        element["Status Rocket"].ToString(), 
                                        element["Status Mission"].ToString());
            return elements;
        }

        public void searchUsingGroupBy(){}

        private void cappedChoice(List<SpaceMission> missionList){
            Console.WriteLine("I've found {0} missions", missionList.Count());
            Console.WriteLine("How many of them do you want to display ?");
            var userInput = Convert.ToInt16(Console.ReadLine());

            for(int i = 0; i < userInput; i++){
                //Mission
                Console.WriteLine(i);
                var mission = missionList.ToList()[i];
                mission.missionDetail();
            }
            Hmi.pushEnter();
        }    
    }
}