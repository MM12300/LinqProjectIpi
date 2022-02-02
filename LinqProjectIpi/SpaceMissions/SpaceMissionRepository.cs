using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.IO;
using LinqProjectIpi.Utils;
using System.Text;
using Newtonsoft.Json;
using System.Runtime.InteropServices.WindowsRuntime;

namespace LinqProjectIpi.SpaceMissions
{
    public class SpaceMissionRepository
    {

        private JObject missionCollection = JObject.Parse(File.ReadAllText($@"{Directory.GetCurrentDirectory()}/JSON/spacemission.json"));
        private String collectionName = "AllMissions";
        
        public void getAllMissions(){
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Hmi.centeredOutput("All missions since 1957:");
            Console.ResetColor();
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
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Enter the location to retrieve the associated missions ...");
            Console.ResetColor();
            //CHoix de l'utilisateur pour le pays
            var userInput = Console.ReadLine();
            //Récupération des missions
            var missions = whereRequest("Location", userInput);
            //Select ordering
            missions = orderBy(missions);
            //Affichage
            cappedChoice(missions.ToList());
        }

        public void searchByCompany(){
            //Affichage de la liste des sociétés
            getCompanies();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Enter the company's name to retrieve the associated missions ...");
            Console.ResetColor();
            //CHoix de l'utilisateur pour la société
            var userInput = Console.ReadLine();
            //Récupération des missions
            var missions = whereRequest("Company Name", userInput);
            //Select ordering
            orderBy(missions);
            //Affichage
            cappedChoice(missions.ToList());
        }

        public void searchByRocketStatus(){
            IEnumerable<SpaceMission> missions;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Select the rocket status to retrieve the associated missions ...");
            Console.ResetColor();
            Console.WriteLine("1) Active");
            Console.WriteLine("2) Retired");
            var userInput = Console.ReadLine();
            switch(userInput){

                case "1":
                    missions = whereRequest("Status Rocket", "StatusActive");
                    //Select ordering
                    orderBy(missions);
                    cappedChoice(missions.ToList());
                    break;

                case "2":
                    missions = whereRequest("Status Rocket", "StatusRetired");
                    //Select ordering
                    orderBy(missions);
                    cappedChoice(missions.ToList());
                    break;
                
                default:
                    Hmi.wrongOptions();
                    break;
            }
        }

        public void searchByMissionStatus(){
            IEnumerable<SpaceMission> missions;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Select the mission status to retrieve the associated missions ...");
            Console.ResetColor();
            Console.WriteLine("1) Success");
            Console.WriteLine("2) Failure");
            var userInput = Console.ReadLine();
            switch(userInput){

                case "1":
                    missions = whereRequest("Status Mission", "Success");
                    //Select ordering
                    orderBy(missions);
                    cappedChoice(missions.ToList());
                    break;

                case "2":
                    missions = whereRequest("Status Mission", "Failure");
                    //Select ordering
                    orderBy(missions);
                    cappedChoice(missions.ToList());
                    break;
                
                default:
                    Hmi.wrongOptions();
                    break;
            }
        }



        public IEnumerable<SpaceMission> orderBy(IEnumerable<SpaceMission> missions){
            string order;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("By which field would you like to order the list ?");
            Console.ResetColor();
            Console.WriteLine("1) Order by company name");
            Console.WriteLine("2) Order by location");
            Console.WriteLine("3) Order by year");
            Console.WriteLine("4) Order by rocket stauts");
            Console.WriteLine("5) Order by mission status");
            var option = Console.ReadLine();
            
            switch(option){
                //By company name
                case "1":
                    order = selectOrder();
                    if(order == "Ascending"){
                        return missions.OrderBy(x => x.companyName);
                    }
                    else if (order == "Descending"){
                        return missions.OrderBy(x => x.companyName).Reverse();
                    }
                    else{
                        Hmi.wrongOptions();
                        return missions;
                    }
      

                //By location
                case "2":
                    order = selectOrder();
                    if(order == "Ascending"){
                        return missions.OrderBy(x => x.location);
                    }
                    else if (order == "Descending"){
                        return missions.OrderBy(x => x.location).Reverse();
                    }
                    else{
                        Hmi.wrongOptions();
                        return missions;
                    }


                //By date
                case "3":
                    order = selectOrder();
                    if(order == "Ascending"){
                        return missions.OrderBy(x => x.datum);
                    }
                    else if (order == "Descending"){
                        return missions.OrderBy(x => x.datum).Reverse();
                    }
                    else{
                        Hmi.wrongOptions();
                        return missions;
                    }

                //By rocket status
                case "4":
                    order = selectOrder();
                    if(order == "Ascending"){
                        return missions.OrderBy(x => x.statusRocket);
                    }
                    else if (order == "Descending"){
                        return missions.OrderBy(x => x.statusRocket).Reverse();
                    }
                    else{
                        Hmi.wrongOptions();
                        return missions;
                    }


                //By mission status
                case "5":
                    order = selectOrder();
                    if(order == "Ascending"){
                        return missions.OrderBy(x => x.statusMission);
                    }
                    else if (order == "Descending"){
                        return missions.OrderBy(x => x.statusMission).Reverse();
                    }
                    else{
                        Hmi.wrongOptions();
                        return missions;
                    }
            }
            return missions;                   

        }

        private string selectOrder(){
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Select order type:");
            Console.ResetColor();
            Console.WriteLine("1) Ascending");
            Console.WriteLine("2) Descending");
            var option = Console.ReadLine();
            switch(option){
                case "1":
                    return "Ascending";
                
                case "2":
                    return "Descending";
                
                default:
                Hmi.wrongOptions();
                return null;
            }
        }

        private IEnumerable<JToken> selectRequest(string fieldName){
            var elements = from element in missionCollection[collectionName]                
                select element[fieldName];

            return elements;        
        }

        private IEnumerable<SpaceMission> selectMissions(){
            var missions = from mission in missionCollection["AllMissions"]
                select new SpaceMission(Convert.ToInt16(mission["missionId"]), 
                            mission["Company Name"].ToString(), 
                            mission["Location"].ToString(), 
                            mission["Datum"].ToString(), 
                            mission["Detail"].ToString(),
                            mission["Status Rocket"].ToString(),
                            mission["Status Mission"].ToString());

            return missions;
        }

        private IEnumerable<SpaceMission> whereRequest(string fieldName, string research){
            var elements = from element in missionCollection[collectionName]
                where element[fieldName].ToString().Contains(research, StringComparison.InvariantCultureIgnoreCase)
                select new SpaceMission(Convert.ToInt16(element["missionId"]), 
                            element["Company Name"].ToString(), 
                            element["Location"].ToString(), 
                            element["Datum"].ToString(), 
                            element["Detail"].ToString(),
                            element["Status Rocket"].ToString(),
                            element["Status Mission"].ToString());
            return elements;
        }

        public IEnumerable<SpaceMission> searchWithTwoParameters(string fiestFieldName, string secondFieldName, string firstParam, string secondParam){
            var elements = from element in missionCollection[collectionName]
                where element[firstParam].ToString().Contains(firstParam, StringComparison.InvariantCultureIgnoreCase) && 
                        element[secondFieldName].ToString().Contains(secondParam, StringComparison.InvariantCultureIgnoreCase)
                select new SpaceMission(Convert.ToInt16(element["missionId"]), 
                            element["Company Name"].ToString(), 
                            element["Location"].ToString(), 
                            element["Datum"].ToString(), 
                            element["Detail"].ToString(),
                            element["Status Rocket"].ToString(),
                            element["Status Mission"].ToString());
            return elements;
        }

        //TODO faire du groupBy
        public void searchUsingGroupBy(){}


        public IEnumerable<SpaceMission> searchByYearRequest(int year, string choice){
            

            if(choice == "After"){
                var elements = from element in missionCollection[collectionName]
                where Misc.parseRFC1123Date(element["Datum"].ToString()).Year > year
                select new SpaceMission(Convert.ToInt16(element["missionId"]), 
                            element["Company Name"].ToString(), 
                            element["Location"].ToString(), 
                            element["Datum"].ToString(), 
                            element["Detail"].ToString(),
                            element["Status Rocket"].ToString(),
                            element["Status Mission"].ToString());
                
                return elements;
            }
            else if(choice == "Before"){
                var elements = from element in missionCollection[collectionName]
                where Misc.parseRFC1123Date(element["Datum"].ToString()).Year < year
                select new SpaceMission(Convert.ToInt16(element["missionId"]), 
                            element["Company Name"].ToString(), 
                            element["Location"].ToString(), 
                            element["Datum"].ToString(), 
                            element["Detail"].ToString(),
                            element["Status Rocket"].ToString(),
                            element["Status Mission"].ToString());
                
                return elements;
            }

            return null;

        }

        public void cappedChoice(List<SpaceMission> missionList){
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("I've found {0} missions", missionList.Count());
            Console.WriteLine("How many of them do you want to display ?");
            Console.ResetColor();
            var userInput = Convert.ToInt16(Console.ReadLine());

            for(int i = 0; i < userInput; i++){
                var mission = missionList.ToList()[i];
                mission.missionDetail();
            }
            Hmi.pushEnter();
        }    

        public int fetchLastId(){
            var jsonSerializerSettings = new JsonSerializerSettings();
            jsonSerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;

            var list = JsonConvert.DeserializeObject<List<SpaceMission>>(missionCollection[collectionName].ToString(), jsonSerializerSettings);
            return list.Last().missionId;

        }

        public void addMission(SpaceMission mission){
            var jsonSerializerSettings = new JsonSerializerSettings();
            jsonSerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;

            var list = JsonConvert.DeserializeObject<List<SpaceMission>>(missionCollection[collectionName].ToString(), jsonSerializerSettings);
            list.Add(mission);
            var convertedJson = JsonConvert.SerializeObject(list, Formatting.None);
            
            var finalJson = "{\"AllMissions\":" + convertedJson.ToString() + "}";
            File.WriteAllText(@"./JSON/spacemission.json", finalJson);
        }    
    }
}