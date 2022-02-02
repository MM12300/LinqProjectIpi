using System;
using System.Text;
using LinqProjectIpi.Utils;

namespace LinqProjectIpi.SpaceMissions
{
    public class SpaceMission
    {
        public int missionId { get; set; }
        public string companyName { get; set; }
        public string detail { get; set; }
        public string statusRocket { get; set; }
        public string statusMission { get; set; }
        public DateTime date { get; set; }
        public string location { get; set; }
        

        public SpaceMission(int missionId, string companyName, string detail, string statusRocket, string statusMission, string date, string location)
        {
            this.missionId = missionId;
            this.companyName = companyName;
            this.detail = detail;
            this.statusRocket = statusRocket.Replace("Status", "");
            this.statusMission = statusMission;
            this.date = Misc.parseRFC1123Date(date);
            this.location = location;
        }

        public void missionDetail(){
            Console.WriteLine("==================== Mission Id {0} ====================", this.missionId);
            Console.WriteLine("Company: {0}", this.companyName);
            Console.WriteLine("Rocket and payload: {0}", this.detail);
            Console.WriteLine("Date: {0} UTC", this.date.ToString());
            Console.WriteLine("Date: {0} UTC", this.location);
            Console.WriteLine("Rocket Status: {0}", this.statusRocket);
            Console.WriteLine("Mission Status: {0}", this.statusMission);
            Console.WriteLine("======================================================", this.missionId);
        }

    }
}