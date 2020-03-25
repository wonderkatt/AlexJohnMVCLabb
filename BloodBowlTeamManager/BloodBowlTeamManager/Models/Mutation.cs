using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BloodBowlTeamManager
{
    public class Mutation
    {
        [Column("id")]
        public virtual string Id { get; set; }
        public virtual MutationsEnum MutationSkill { get; set; }
        public virtual Player Player { get; set; }
    }
}
