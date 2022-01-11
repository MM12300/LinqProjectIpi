using System;
namespace LinqProjectIpi.SpaceMissions
{
    public class SpaceMission
    {
        public int missionId { get; set; }
        public string companyName { get; set; }
        public string detail { get; set; }
        public string statusRocket { get; set; }
        public string statusMission { get; set; }
        

        public SpaceMission(int missionId, string companyName, string detail, string statusRocket, string statusMission)
        {
            this.missionId = missionId;
            this.companyName = companyName;
            this.detail = detail;
            this.statusRocket = statusRocket;
            this.statusMission = statusMission;
        }

        public void missionDetail(){
            Console.WriteLine("==================== Mission Id {0} ====================", this.missionId);
            Console.WriteLine("Société: {0}", this.companyName);
            Console.WriteLine("Lanceur: {0}", this.detail);
            Console.WriteLine("Status de la fusée: {0}", this.statusRocket);
            Console.WriteLine("Status de la mission: {0}", this.statusMission);
            Console.WriteLine("======================================================", this.missionId);
        }

    }
}