using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBowlTeamManager
{
    public class User : IdentityUser
    {
        public string CoachName { get; set; }
        
    }
}
