using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBowlTeamManager
{
    public class TeamPlayersOverviewResponse
    {
        public string Id { get; set; }
        public string Position { get; set; }
        public string PlayerName { get; set; }
        public int Number { get; set; }
        public int Cost { get; set; }
    }
}
