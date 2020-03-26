using AutoMapper;
using BloodBowlTeamManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBowlTeamManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly BBContext context;
        private readonly ILogger<TeamController> logger;
        private readonly IMapper mapper;

        public TeamController(BBContext context, ILogger<TeamController> logger, IMapper mapper)
        {
            this.context = context;
            this.logger = logger;
            this.mapper = mapper;
        }
        [Route("overview")]
        [HttpGet]
        public IEnumerable<object> Get()
        {
            List<Team> rawTeams = context.Teams.ToList();

            return rawTeams.Select((team) => mapper.Map<TeamOverviewResponse>(team));

            //List<object> serializedTeams = new List<object>();

            //for (int i = 0; i < rawTeams.Count; i++)
            //{
            //    serializedTeams.Add(new
            //    {
            //        id = rawTeams[i].Id,
            //        teamName = rawTeams[i].TeamName,
            //        coach = rawTeams[i].Coach.Id,
            //        race = rawTeams[i].Race.RaceName,
            //        reRolls = rawTeams[i].NumberOfReRolls,
            //        teamValue = rawTeams[i].Teamvalue,
            //        players = GetPlayers(rawTeams[i])
            //    });
            //}
            //return serializedTeams;

        }
        [Route("players")]
        [HttpGet]
        public IEnumerable<object> GetPlayers()
        {
            var rawPlayers = context.Players.Where(p=>p.isAvailable == false).ToList();

            return rawPlayers.Select((player) => mapper.Map<TeamPlayerDetailsResponse>(player));


        }

        private void GetTeam()
        {
            context.Teams.Select(
                (team) => new
                    {
                        Id = team.Id,
                        teamName = team.TeamName,
                        players = team.Players.Select((player) => new
                        {

                        })

                    } 
                ); 
        }

        //private object GetPlayers(Team team)
        //{
        //    List<Player> rawPlayers = team.Players.ToList();

        //    List<object> serializedPlayers = new List<object>();

        //    for (int i = 0; i < rawPlayers.Count; i++)
        //    {
        //        serializedPlayers.Add(new 
        //        {
        //            Id = rawPlayers[i].Id,
        //            Number = rawPlayers[i].Number, 
        //            Name = rawPlayers[i].PlayerName,
        //            Position = rawPlayers[i].Position,
        //            Movement = rawPlayers[i].MovementValue,
        //            Strength = rawPlayers[i].StrengthValue,
        //            Agility = rawPlayers[i].AgilityValue,
        //            ArmourValue = rawPlayers[i].ArmourValue,
        //            Skills = rawPlayers[i].


        //        });
        //    }
        //}
    }
}
