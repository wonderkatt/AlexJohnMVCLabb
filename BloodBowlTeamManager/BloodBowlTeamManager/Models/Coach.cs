using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodBowlTeamManager
{
    public class Coach
    {
        [Column("id")]
        public virtual string Id { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
    }
}