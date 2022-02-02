using System;
using System.IO;
using Newtonsoft.Json.Linq;
using LinqProjectIpi.Utils;
using LinqProjectIpi.SpaceMissions;
using System.Threading;

namespace LinqProjectIpi
{
    public class SpaceMissionHMI{


        private SpaceMissionRepository repo = new SpaceMissionRepository();
        private string title = "Space Missions since 1957";


        public void main(){
            Hmi.showTitle(title);
            options();
        }

        void options()
        {
            Console.WriteLine("Available options: :");
            Console.WriteLine("1 - List all space missions");
            Console.WriteLine("2 - Research");

            Console.WriteLine("3 - Return");
            Console.WriteLine();
            Console.WriteLine("\r\n Choose an option");

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
                        main();
                        break;

                    case "4":
                       repo.searchByYear();

                        break;

                    default:
                        Hmi.wrongOptions();
                        break;
                }
            }



            void searchProcess(){
                Hmi.centeredOutput("Search Menu");
                Console.WriteLine("Choose your option :");
                Console.WriteLine("1 - Simple search");
                Console.WriteLine("2 - Advanced search");
                Console.WriteLine("3 - Return");
                Console.WriteLine();

                switch (Console.ReadLine())
                {
                    case "1":
                    Console.Clear();
                    Hmi.showTitle(title);
                    simpleSearch();
                    break;

                    case "2":
                    Console.Clear();
                    Hmi.showTitle(title);
                    advancedSearch();
                    break;

                    default:
                    Hmi.wrongOptions();
                    Thread.Sleep(1000);
                    advancedSearch();
                    break;



                    
                }

            }

            void simpleSearch(){
                Hmi.centeredOutput("Simple search");
                Console.WriteLine("Characteristics");

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
                        simpleSearch();
                        break;
                    
                    case "2":
                        Console.WriteLine("Available locations:");
                        repo.searchByLocation();
                        simpleSearch();
                        break;

                    case "3":
                        repo.searchByYear();
                        simpleSearch();
                        break;

                    case "4":
                        repo.searchByRocketStatus();
                        simpleSearch();
                        break;

                    case "5":
                        repo.searchByMissionStatus();
                        simpleSearch();
                        break;

                    case "6":
                    break;

                    default:
                    Hmi.wrongOptions();
                    break;

                }


            }

            void advancedSearch(){
                

            }


    }
}