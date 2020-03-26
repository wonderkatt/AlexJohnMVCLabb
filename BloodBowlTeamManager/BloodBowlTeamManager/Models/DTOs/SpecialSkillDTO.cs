namespace BloodBowlTeamManager
{
    public class SpecialSkillDTO
    {
        public string Id { get; set; }
        public SpecialSkillsEnum SpecSkill { get; set; }
        public PlayerDTO Player { get; set; }
    }
}