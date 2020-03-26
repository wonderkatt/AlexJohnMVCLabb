using System.Collections.Generic;

namespace BloodBowlTeamManager
{
    public class TeamDTO
    {
        public string Id { get; set; }
        public RaceDTO Race { get; set; }

        public CoachDTO Coach { get; set; }
        public ICollection<PlayerDTO> Players { get; set; }
        public string TeamName { get; set; }
        public int Teamvalue { get; set; }
        public int NumberOfReRolls { get; set; }

    }
}