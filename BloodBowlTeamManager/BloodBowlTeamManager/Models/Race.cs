using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BloodBowlTeamManager
{
    public class Race
    {
       public Race()
        {

        }

        [Column("id")]
        public virtual string Id { get; set; }
        public string RaceName { get; set; }
        public virtual  ICollection<Player> Players { get; set; }
        public int RerollCost { get; set; }
        public bool Apothecary { get; set; }
        
    }
}
