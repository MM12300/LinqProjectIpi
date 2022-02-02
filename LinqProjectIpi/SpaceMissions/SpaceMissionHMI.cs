using System;
using System.IO;
using Newtonsoft.Json.Linq;
using LinqProjectIpi.Utils;
using LinqProjectIpi.SpaceMissions;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

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
            Console.WriteLine("Available options: :");
            Console.WriteLine("1 - All space missions");
            Console.WriteLine("2 - Search");
            Console.WriteLine("3 - Add Mission");
            Console.WriteLine("4 - Convert Json Dataset into XML");


            Console.WriteLine("5 - Return to main menu");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\r\n Choose an option");
            Console.ResetColor();

            switch (Console.ReadLine())
                {
                    case "1":
                        Hmi.showTitle(title);
                        repo.getAllMissions();
                        main();
                        break;

                    case "2":
                        Hmi.showTitle(title);
                        searchProcess();
                        main();
                        break;

                    case "3":
                        addMissionMenu();
                        break;

                    case "4":
                        Misc.saveJsonToXml();
                        break;
                    
                    case "5":
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

            SpaceMission newSpacemission = new SpaceMission(missionId, companyName, location, date, details, rocketStatus, missionStatus);
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
            IEnumerable<SpaceMission> missions;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Select a year to retrieve the associated missions ...");
            //CHoix de l'utilisateur pour l'année
            var year = Console.ReadLine();
            Console.WriteLine("Would you like to select missions before or after your selected year ?");
            Console.ResetColor();
            Console.WriteLine("1) After");
            Console.WriteLine("2) Before");


            var option = Console.ReadLine();

            switch(option){
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

                switch (Console.ReadLine())
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

    }
}