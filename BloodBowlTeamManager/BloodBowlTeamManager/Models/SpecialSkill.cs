using System.ComponentModel.DataAnnotations.Schema;

namespace BloodBowlTeamManager
{
    public class SpecialSkill
    {
        [Column("id")]
        public virtual string Id { get; set; }
        public virtual SpecialSkillsEnum SpecSkill { get; set; }
        public virtual Player Player { get; set; }
    }
}