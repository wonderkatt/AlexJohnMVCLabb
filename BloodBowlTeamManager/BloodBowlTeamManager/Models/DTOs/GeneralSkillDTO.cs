namespace BloodBowlTeamManager
{
    public class GeneralSkillDTO
    {
        public string Id { get; set; }
        public GeneralSkillsEnum GenSkill { get; set; }
        public  PlayerDTO Player { get; set; }
    }
}
