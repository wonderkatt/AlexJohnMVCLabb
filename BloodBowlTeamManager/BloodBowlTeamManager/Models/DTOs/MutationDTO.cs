namespace BloodBowlTeamManager
{
    public class MutationDTO
    {
        public string Id { get; set; }
        public MutationsEnum MutationSkill { get; set; }
        public PlayerDTO Player { get; set; }
    }
}
