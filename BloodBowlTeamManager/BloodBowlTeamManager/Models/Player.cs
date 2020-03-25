using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodBowlTeamManager
{
    public class Player
    {
        [Column("id")]
        public string Id { get; set; }
        public string Position { get; set; }
        public bool isAvailable { get; set; }
        public virtual Race Race { get; set; }
        public virtual Team Team { get; set; }
        public string PlayerName { get; set; }
        public int Number { get; set; }
        public int Cost { get; set; }
        public int Touchdowns { get; set; }
        public int Casualties { get; set; }
        public int Completions { get; set; }
        public int Interceptions { get; set; }
        public int MVP { get; set; }
        public int SPP { get; set; }
        public bool MissNextGame { get; set; }
        public virtual ICollection<AgilitySkill> AgilitySkills { get; set; }
        public virtual ICollection<StrengthSkill> StrengthSkills { get; set; }
        public virtual ICollection<GeneralSkill> GeneralSkills { get; set; }
        public virtual ICollection<PassSkill> PassingSkills { get; set; }
        public virtual ICollection<Mutation> Mutations { get; set; }
        public virtual ICollection<SpecialSkill> SpecialSkills { get; set; }

        public int MovementValue { get; set; }
        public int StrengthValue { get; set; }
        public int AgilityValue { get; set; }
        public int ArmourValue { get; set; }
       // public ICollection<Injuries> Injuries { get; set; }
        public int PlayedGames { get; set; }

    }
}