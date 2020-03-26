using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodBowlTeamManager
{
    public class Team
    {
        [Column("id")]
        public string Id { get; set; }
        public virtual Race Race { get; set; }
        public virtual Coach Coach { get; set; }
        public virtual ICollection<Player> Players { get; set; }
        public string TeamName { get; set; }
        public int Teamvalue { get; set; }
        public int NumberOfReRolls { get; set; }

    }
}