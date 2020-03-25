using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BloodBowlTeamManager
{
    public class PassSkill
    {
        [Column("id")]
        public virtual string Id { get; set; }
        public virtual PassingSkillsEnum pasSkill { get; set; }
        public virtual Player Player { get; set; }
    }
}
