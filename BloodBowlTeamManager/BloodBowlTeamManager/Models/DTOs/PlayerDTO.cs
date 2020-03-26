using System.Collections.Generic;

namespace BloodBowlTeamManager
{
    public class PlayerDTO
    {
        public string Id { get; set; }
        public string Position { get; set; }
        public bool isAvailable { get; set; }
        public RaceDTO Race { get; set; }
        public TeamDTO Team { get; set; }
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
        public ICollection<AgilitySkillDTO> AgilitySkills { get; set; }
        public ICollection<StrengthSkillDTO> StrengthSkills { get; set; }
        public ICollection<GeneralSkillDTO> GeneralSkills { get; set; }
        public ICollection<PassSkillDTO> PassingSkills { get; set; }
        public ICollection<MutationDTO> Mutations { get; set; }
        public ICollection<SpecialSkillDTO> SpecialSkills { get; set; }

        public int MovementValue { get; set; }
        public int StrengthValue { get; set; }
        public int AgilityValue { get; set; }
        public int ArmourValue { get; set; }
        // public ICollection<Injuries> Injuries { get; set; }
        public int PlayedGames { get; set; }

    }
}