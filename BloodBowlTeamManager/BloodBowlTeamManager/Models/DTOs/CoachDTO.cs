using System.Collections.Generic;

namespace BloodBowlTeamManager
{
    public class CoachDTO
    {
        public  string Id { get; set; }
        public  ICollection<TeamDTO> Teams { get; set; }
    }
}