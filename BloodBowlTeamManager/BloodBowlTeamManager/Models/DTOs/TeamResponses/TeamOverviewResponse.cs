using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBowlTeamManager
{
    public class TeamOverviewResponse 
    {
        public string Id { get; set; }
        public string Race { get; set; }
        public string Coach { get; set; }
        public string TeamName { get; set; }
        public int Teamvalue { get; set; }
        public int NumberOfReRolls { get; set; }
    }
}
