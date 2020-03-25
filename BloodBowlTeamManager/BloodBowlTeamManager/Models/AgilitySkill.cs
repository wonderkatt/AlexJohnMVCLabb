using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BloodBowlTeamManager
{
    public class AgilitySkill
    {
        [Column("id")]
        public virtual string Id { get; set; }
        public virtual Player Player { get; set; }
        public virtual AgilitySkillsEnum AgiSkill { get; set; }
    }
}
