using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using LinqProjectIpi.SpaceMissions;

namespace LinqProjectIpi
{
    public class SpaceMissionHMI{

        private JObject missionCollection = JObject.Parse(File.ReadAllText($@"{Directory.GetCurrentDirectory()}/JSON/spacemission.json"));
        private String collectionName = "AllMissions";


        public void main(){
            start();
            options();
        }

        void start()
        {
            Console.Clear();
            Console.WriteLine("-..-=-..-=-..-=-..-=-..-=-..-=-..-=-..-=-..-=-..-=-..-");
            Console.WriteLine("Les Missions Spatiales depuis 1957 :-)");
            Console.WriteLine("-..-=-..-=-..-=-..-=-..-=-..-=-..-=-..-=-..-=-..-=-..-");
        }

        void options()
        {
            Console.WriteLine("Choississez votre option :");
            Console.WriteLine("1 - Lister toute les missions");
            Console.WriteLine("2 - Recherche par société");
            Console.WriteLine("3 - Recherche par pays");
            Console.WriteLine("4 - Fin du programme");
            Console.WriteLine();
            Console.WriteLine("\r\n Choississez une option (1 2 ou 3)");

            switch (Console.ReadLine())
                {
                    case "1":                        
                        Console.WriteLine("L'ensemble des missions spatiales depuis 1957");
                        getAllMissions();
                        main();
                        break;
                        
                    case "2":
                        Console.WriteLine("Recherche par société");
                        Console.WriteLine("Liste des sociétés disponibles:");
                        getCompanies();
                        break;

                    case "3":
                        Console.WriteLine("Recherche par pays");
                        Console.WriteLine("Liste des pays disponibles:");
                        getCountries();
                        searchByCountry();
                        break;

                    default:
                        Console.WriteLine("Choississez une des 3 options uniquement !");
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine();
                        break;
                }
            }

        void getAllMissions(){
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

        public void getCountries(){

            //Location
            var locations = simpleSelectRequest("Location").Distinct();
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

        public void searchByCountry(){
            Console.WriteLine("Ecrivez votre pays ...");
            var userInput = Console.ReadLine();

            var missions = from mission in missionCollection[collectionName]
                            where mission["Location"].ToString().Contains(userInput, StringComparison.InvariantCultureIgnoreCase)
                            select new SpaceMission(Convert.ToInt16(mission[""]), 
                                                    mission["Company Name"].ToString(), 
                                                    mission["Detail"].ToString(), 
                                                    mission["Status Rocket"].ToString(), 
                                                    mission["Status Mission"].ToString());

            cappedChoice(missions.ToList());
        }

        public void searchByCompany(){

        }


        private IEnumerable<JToken> simpleSelectRequest(string fieldName){
            var elements = from element in missionCollection[collectionName]                
                select element[fieldName];

                return elements;        
        }

        private void cappedChoice(List<SpaceMission> missionList){
            Console.WriteLine("J'ai trouvé {0} missions", missionList.Count());
            Console.WriteLine("Combien veux tu en afficher ?");
            var userInput = Convert.ToInt16(Console.ReadLine());

            for(int i = 1; i <= userInput; i++){
                //Mission
                var mission = missionList.ToList()[i];
                mission.missionDetail();
            }
        }

        


    }
}