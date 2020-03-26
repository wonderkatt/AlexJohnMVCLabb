using System.Collections.Generic;

namespace BloodBowlTeamManager
{
    public class RaceDTO
    {
        public string Id { get; set; }
        public string RaceName { get; set; }
        //public ICollection<PlayerDTO> Players { get; set; }
        public int RerollCost { get; set; }
        public bool Apothecary { get; set; }

    }
}
