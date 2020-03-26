namespace BloodBowlTeamManager
{
    public class StrengthSkillDTO
    {
        public string Id { get; set; }
        public StrengthSkillsEnum StrSkill { get; set; }
        public PlayerDTO Player { get; set; }
    }
}
