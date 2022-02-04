using System;
using System.IO;
using Newtonsoft.Json.Linq;
using LinqProjectIpi.Utils;
using LinqProjectIpi.SpaceMissions;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using LinqProjectIpi.SpaceMissionModels;
using System.Text.RegularExpressions;

namespace LinqProjectIpi
{
    public class SpaceMissionHMI{


        private SpaceMissionRepository repo = new SpaceMissionRepository();
        private string title = "Space Missions since 1957";


        public void main(){
            //Hmi.showTitle(title);
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Hmi.centeredOutput("███████╗██████╗  █████╗  ██████╗███████╗    ███╗   ███╗██╗███████╗███████╗██╗ ██████╗ ███╗   ██╗███████╗");
            Hmi.centeredOutput("██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝    ████╗ ████║██║██╔════╝██╔════╝██║██╔═══██╗████╗  ██║██╔════╝");
            Hmi.centeredOutput("███████╗██████╔╝███████║██║     █████╗      ██╔████╔██║██║███████╗███████╗██║██║   ██║██╔██╗ ██║███████╗");
            Hmi.centeredOutput("╚════██║██╔═══╝ ██╔══██║██║     ██╔══╝      ██║╚██╔╝██║██║╚════██║╚════██║██║██║   ██║██║╚██╗██║╚════██║");
            Hmi.centeredOutput("███████║██║     ██║  ██║╚██████╗███████╗    ██║ ╚═╝ ██║██║███████║███████║██║╚██████╔╝██║ ╚████║███████║");
            Hmi.centeredOutput("╚══════╝╚═╝     ╚═╝  ╚═╝ ╚═════╝╚══════╝    ╚═╝     ╚═╝╚═╝╚══════╝╚══════╝╚═╝ ╚═════╝ ╚═╝  ╚═══╝╚══════╝");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");

            options();
        }

        void options()
        {
            IEnumerable<SpaceMissionModel> missions;
            Console.WriteLine("Available options: :");
            Console.WriteLine("1 - All space missions");
            Console.WriteLine("2 - Recent missions (less than 15)");
            Console.WriteLine("3 - Old missions (more than 40 years)");
            Console.WriteLine("4 - Search");
            Console.WriteLine("5 - Advanced search");
            Console.WriteLine("6 - Add Mission");
            Console.WriteLine("7 - Convert Json Dataset into XML");


            Console.WriteLine("8 - Return to main menu");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\r\n Choose an option");
            Console.ResetColor();

            switch (Misc.validateIntegerInput(Console.ReadLine()))
                {
                    case "1":
                        Hmi.showTitle(title);
                        repo.getAllMissions();
                        main();
                        break;
                        

                    
                    case "2":
                        Hmi.showTitle(title);
                        missions = repo.searchByYearRequest((DateTime.Now.Year - 15), "After");
                        repo.cappedChoice(missions.ToList());
                        main();
                        break;

                    case "3":
                        Hmi.showTitle(title);
                        missions = repo.searchByYearRequest((DateTime.Now.Year - 40), "Before");
                        repo.cappedChoice(missions.ToList());
                        main();
                        break;

                    case "4":
                        Hmi.showTitle(title);
                        searchProcess();
                        main();
                        break;

                    case "5":
                        Hmi.showTitle(title);
                        advancedSearchProcess();
                        main();
                        break;

                    case "6":
                        addMissionMenu();
                        break;

                    case "7":
                        Misc.saveJsonToXml();
                        break;
                    
                    case "8":
                        Hmi.main();
                        return;

                    default:
                        Hmi.wrongOptions();
                        main();
                        break;
                }
            }


        public void addMissionMenu(){
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Add a new space mission:");
            Console.ResetColor();

            //Fetch last id
            int missionId = repo.fetchLastId();

            Console.WriteLine("Enter a company name:");
            var companyName = Console.ReadLine();
            Console.WriteLine("Enter a location:");
            var location = Console.ReadLine();
            Console.WriteLine("Enter a date using the following format:");
            Console.WriteLine("Thu, 21 Jan 2010 17:47:00 UTC");
            var date = Console.ReadLine();
            Console.WriteLine("Enter mission details:");
            var details = Console.ReadLine();
            Console.WriteLine("Enter the rocket status:");
            var rocketStatus = Console.ReadLine();
            Console.WriteLine("Enter the mission status:");
            var missionStatus = Console.ReadLine();

            SpaceMissionModel newSpacemission = new SpaceMissionModel(missionId, companyName, location, date, details, rocketStatus, missionStatus);
            Console.WriteLine("Overview of the new space mission:");
            newSpacemission.missionDetail();
            Console.WriteLine("Do you want to procedd ?  Y/N");
            
            var userInput = Console.ReadLine();
            if(userInput == "Y"){
                Console.WriteLine("Adding new space mission");
                repo.addMission(newSpacemission);
            }
            else if(userInput == "N"){
                Console.WriteLine("Mission will not be added");
            }

            else{
                Hmi.wrongOptions();
            }     
        }

        public void searchByYear(){
            IEnumerable<SpaceMissionModel> missions;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Select a year to retrieve the associated missions ...");
            //CHoix de l'utilisateur pour l'année
            var year = Console.ReadLine();
            Console.WriteLine("Would you like to select missions before or after your selected year ?");
            Console.ResetColor();
            Console.WriteLine("1) After");
            Console.WriteLine("2) Before");

            switch(Misc.validateIntegerInput(Console.ReadLine())){
                case "1":
                    missions = repo.searchByYearRequest(int.Parse(year), "After");
                    repo.orderBy(missions);
                    repo.cappedChoice(missions.ToList());
                    break;
                
                case "2":
                    missions = repo.searchByYearRequest(int.Parse(year), "Before");
                    repo.orderBy(missions);
                    repo.cappedChoice(missions.ToList());
                    break;
                
                default:
                    Hmi.wrongOptions();
                    break;
            }
                    
        }

            void searchProcess(){
                Hmi.centeredOutput("Simple search");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Characteristics");
                Console.ResetColor();
                Console.WriteLine("1 - Company name");
                Console.WriteLine("2 - Location");
                Console.WriteLine("3 - Year");
                Console.WriteLine("4 - Rocket Status");
                Console.WriteLine("5 - Mission Status");
                Console.WriteLine("6 - Return");

                switch (Misc.validateIntegerInput(Console.ReadLine()))
                {
                    case "1":
                        Console.WriteLine("Available companies:");
                        repo.searchByCompany();
                        searchProcess();
                        break;
                    
                    case "2":
                        Console.WriteLine("Available locations:");
                        repo.searchByLocation();
                        searchProcess();
                        break;

                    case "3":
                        searchByYear();
                        searchProcess();
                        break;

                    case "4":
                        repo.searchByRocketStatus();
                        searchProcess();
                        break;

                    case "5":
                        repo.searchByMissionStatus();
                        searchProcess();
                        break;

                    case "6":
                    break;

                    default:
                        Hmi.wrongOptions();
                        searchProcess();
                        break;

                }


            }

            void advancedSearchProcess(){
                string firstParam;
                string secondParam;

                Hmi.centeredOutput("Advanced search");
                Console.WriteLine("In this search mode you can target two differents characteristics");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.ResetColor();

                Console.WriteLine("Please select the first characteristic:");
                firstParam = selectParameter();
                string firstFieldName = sanitizeInput(firstParam)["Field"];
                string firstUserChoice = sanitizeInput(firstParam)["UserChoice"];


                Console.WriteLine("Please select the second characteristic:");
                secondParam = selectParameter();
                string secondFieldName = sanitizeInput(secondParam)["Field"];
                string secondUserChoice = sanitizeInput(secondParam)["UserChoice"];
                
                IEnumerable<SpaceMissionModel> missions = repo.searchWithTwoParameters(firstFieldName, secondFieldName, firstUserChoice, secondUserChoice);
                repo.cappedChoice(missions.ToList());

            }


            string selectParameter(){
                string userChoice;
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.ResetColor();
                Console.WriteLine("1 - Company name");
                Console.WriteLine("2 - Location");
                Console.WriteLine("3 - Rocket Status");
                Console.WriteLine("4 - Mission Status");
                Console.WriteLine("5 - Return");

                switch (Misc.validateIntegerInput(Console.ReadLine()))
                {
                    case "1":
                        Console.WriteLine("Available companies:");
                        repo.getCompanies();
                        Console.WriteLine();
                        Console.WriteLine("Enter a company name:");
                        return "Company Name" + "-" + Console.ReadLine();
                    
                    case "2":
                        Console.WriteLine("Available locations:");
                        repo.getCountries();
                        Console.WriteLine();
                        Console.WriteLine("Enter a location:");
                        return "Location" + "-" + Console.ReadLine();

                    case "3":
                        Console.WriteLine("Please enter the chosen rocket status between Active and Retired: ");
                        userChoice = validateRocketStatus(Console.ReadLine());
                        return "Status Rocket" + "-" + userChoice;

                    case "4":
                        Console.WriteLine("Please enter the chosen mission status between Success and Failure: ");
                        userChoice = validateRocketStatus(Console.ReadLine());
                        return "Status Mission" + "-" + userChoice;

                    case "5":
                        return null;

                    default:
                        Hmi.wrongOptions();
                        return null;

                }
            }

        private static string validateMissionYear(string input){

            String result;
            Regex regexNumber = new Regex("[0-9]");

            if(regexNumber.IsMatch(input)){
                if(int.Parse(input) > DateTime.Now.Year){
                    Console.WriteLine("The selected year is greater than the current year, please select a valid year");
                }
                else if (int.Parse(input) < 1957){
                    Console.WriteLine("There is no space missions before 1957, please select a valid year");
                }
                else{
                    result = input;
                    return result;
                }
                
                return null;
            }
            else{
                Console.WriteLine("Your input is not a valid number");
                    return "-1";
            }
        }

        private static string validateRocketStatus(string input){

            if(input == "Active"){
                return input;
            }
            else if (input == "Retired"){
                return input;
            }
            else{
                Console.WriteLine("The selected status is not correct");
                Console.WriteLine("Default value will be used: Active");
                return "Active";
            }
        }

        private static string validateMissionStatus(string input){

            if(input == "Failure"){
                return input;
            }
            else if (input == "Success"){
                return input;
            }
            else{
                Console.WriteLine("The selected status is not correct");
                Console.WriteLine("Default value will be used: Success");
                return "Success";
            }
        }

        private Dictionary<string, string> sanitizeInput(string input){
            Dictionary<string, string> dict = new Dictionary<string, string>();
            string[] parsedInput = input.Split("-");
            Console.WriteLine(parsedInput[0]);
            Console.WriteLine(parsedInput[1]);
            dict.Add("Field", parsedInput[0]);
            dict.Add("UserChoice", parsedInput[1]);
            return dict;

        }




    }
}