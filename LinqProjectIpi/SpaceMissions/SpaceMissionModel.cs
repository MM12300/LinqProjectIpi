using System;
using System.Text;
using System.Text.Json.Serialization;
using LinqProjectIpi.Utils;
using Newtonsoft.Json;

namespace LinqProjectIpi.SpaceMissionModels
{
    public class SpaceMissionModel
    {
        [JsonProperty("missionId")]
        public int missionId { get; set; }
        [JsonProperty("Company Name")]
        public string companyName { get; set; }
        [JsonProperty("Detail")]
        public string detail { get; set; }
        [JsonProperty("Status Rocket")]
        public string statusRocket { get; set; }
        [JsonProperty("Status Mission")]
        public string statusMission { get; set; }
        [JsonProperty("Datum")]
        public DateTime datum { get; set; }
        [JsonProperty("Location")]
        public string location { get; set; }
        

        public SpaceMissionModel(int missionId, string companyName, string location, string datum, string detail, string statusRocket, string statusMission)
        {
            this.missionId = missionId;
            this.companyName = companyName;
            this.detail = detail;
            this.statusRocket = statusRocket.Replace("Status", "");
            this.statusMission = statusMission;
            this.datum = Misc.parseRFC1123Date(datum);
            this.location = location;
        }

        public void missionDetail(){
            Console.WriteLine("==================== Mission Id n°{0} ====================", this.missionId);
            Console.WriteLine("Company: {0}", this.companyName);
            Console.WriteLine("Rocket and payload: {0}", this.detail);
            Console.WriteLine("Date: {0} UTC", this.datum.ToString());
            Console.WriteLine("Location: {0} UTC", this.location);
            Console.WriteLine("Rocket Status: {0}", this.statusRocket);
            Console.WriteLine("Mission Status: {0}", this.statusMission);
            Console.WriteLine("======================================================");
        }

    }
}