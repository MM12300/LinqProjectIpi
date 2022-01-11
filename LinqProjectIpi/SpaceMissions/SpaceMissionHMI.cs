using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using LinqProjectIpi.SpaceMissions;
using System.Threading;

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
                        searchByCompany();
                        main();
                        break;

                    case "3":
                        Console.WriteLine("Recherche par pays");
                        Console.WriteLine("Liste des pays disponibles:");
                        searchByCountry();
                        main();
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

        public void searchByCountry(){
            //Affichage de la liste des pays
            getCountries();
            Console.WriteLine("Entrez le pays dont vous voulez récupérer les missions ...");
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
            Console.WriteLine("Entrez la société dont vous voulez récupérer les missions ...");
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

        private void cappedChoice(List<SpaceMission> missionList){
            Console.WriteLine("J'ai trouvé {0} missions", missionList.Count());
            Console.WriteLine("Combien veux tu en afficher ?");
            var userInput = Convert.ToInt16(Console.ReadLine());

            for(int i = 0; i < userInput; i++){
                //Mission
                Console.WriteLine(i);
                var mission = missionList.ToList()[i];
                mission.missionDetail();
            }
            
            Console.WriteLine();
            Console.WriteLine("Appuyez sur entrée pour continuer");
            Console.ReadLine();
        }    
    }
}