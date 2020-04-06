using System.Collections.Generic;

namespace BloodBowlTeamManager
{
    public class Result
    {
        public bool Success { get; set; }
        public List<string> Errors  { get; set; }
        public Result()
        {
            Errors = new List<string>();
        }
       
    }
}