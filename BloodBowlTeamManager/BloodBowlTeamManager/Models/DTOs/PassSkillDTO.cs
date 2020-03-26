namespace BloodBowlTeamManager
{
    public class PassSkillDTO
    {
        public string Id { get; set; }
        public PassingSkillsEnum pasSkill { get; set; }
        public PlayerDTO Player { get; set; }
    }
}
