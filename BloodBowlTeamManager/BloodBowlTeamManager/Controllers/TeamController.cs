﻿using AutoMapper;
using BloodBowlTeamManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        private readonly IHttpContextAccessor httpContextAccessor;

        public TeamController(BBContext context, ILogger<TeamController> logger, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            this.logger = logger;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
        }
        //[Authorize]
        [Route("overview")]
        [HttpGet]
        public IEnumerable<object> Get()
        {
            string coachId = "";
            if (httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier) != null)
            {
                coachId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            }
            return context.Teams.ToList()
                .Where(t => t.Coach.Id == coachId)
                .Select((team) => mapper.Map<TeamOverviewResponse>(team))
                .ToList();
        }

        [Route("players")]
        [HttpGet]
        public IEnumerable<object> GetPlayers([FromQuery(Name = "teamid")]string teamid)
        {

            return context.Players.ToList()
            .Where(p => p.isAvailable == false && p.Team.Id == teamid)
            .Select((player) => mapper.Map<TeamPlayersOverviewResponse>(player))
            .ToList();
        }

        [Route("races")]
        [HttpGet]
        public IEnumerable<object> GetRaces()
        {
            return context.Races.ToList()
            .Select((race) => mapper.Map<GetRacesResponse>(race))
            .ToList();
        }
        [Route("players/positions")]
        [HttpGet]
        public IEnumerable<object> GetPositionals([FromQuery(Name = "teamid")]string teamid)
        {
            Team team = context.Teams
                .Where(t => t.Id == teamid)
                .FirstOrDefault();

            if (team == null)
            {
                return new List<Player>();
            }
            Race race = context.Races
                .Where(r => r.Id == team.Race.Id)
                .First();

            return context.Players.ToList()
            .Where(p => p.isAvailable == true && race.Id == p.Race.Id)
            .Select((player) => mapper.Map<TeamPlayersOverviewResponse>(player))
            .ToList();
        }

        [Route("create")]
        [HttpPost]
        public async ValueTask<Result> CreateTeam([FromBody]CreateTeamModel model)
        {
            string coachId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Result httpResponse = new Result();
            
            Coach coach;

            if (context.Coaches.ToList()
                .Where(coach => coach.Id == coachId)
                .Any())
            {
                coach = context.Coaches
                    .Where(c => c.Id == coachId)
                    .First();
            }
            else
            {
                httpResponse.Success = false;
                httpResponse.Errors.Add("No coach with that id could be found.");

                return httpResponse;
            }
            Race race = context.Races
                .Where(r => r.RaceName == model.Race)
                .First();

            context.Teams.Add(new Team
            {
                Coach = coach,
                Id = Guid.NewGuid().ToString(),
                Race = race,
                Players = new List<Player>(),
                TeamName = model.TeamName,
                Teamvalue = 0,
                NumberOfReRolls = 0
            });
            context.SaveChanges();
            httpResponse.Success = true;
            return httpResponse;
            
        }
        
        
        [Route("players/create")]
        [HttpPost]
        public async ValueTask<Result> CreatePlayer([FromBody]BuyPlayerModel formData)
        {
            Result httpResponse = new Result();
            Team team;

            if (context.Teams.ToList()
                .Where(team => team.Id == formData.TeamId)
                .Any())
            {
                team = context.Teams
                    .Where(t => t.Id == formData.TeamId)
                    .First();
            }
            else
            {
                httpResponse.Success = false;
                httpResponse.Errors.Add("No team with that id could be found.");

                return httpResponse;
            }
            Race race = context.Races
                .Where(r => r.Id == team.Race.Id)
                .First();

            Player modelPlayer = context.Players
                .Where(p => p.Position == formData.PlayerPosition && p.isAvailable == true && p.Race.Id == race.Id)
                .First();

            int number = context.Players.Where(p => p.Team.Id == formData.TeamId).Count()+1;
           

            Player newPlayer = new Player
            {
                Id = Guid.NewGuid().ToString(),
                AgilitySkills = modelPlayer.AgilitySkills,
                StrengthSkills = modelPlayer.StrengthSkills,
                GeneralSkills = modelPlayer.GeneralSkills,
                PassingSkills = modelPlayer.PassingSkills,
                SpecialSkills = modelPlayer.SpecialSkills,
                Mutations = modelPlayer.Mutations,
                Race = race,
                MovementValue = modelPlayer.MovementValue,
                StrengthValue = modelPlayer.StrengthValue,
                AgilityValue = modelPlayer.AgilityValue,
                ArmourValue = modelPlayer.ArmourValue,
                isAvailable = false,
                Team = team,
                PlayerName = formData.PlayerName,
                Position = modelPlayer.Position,
                Cost = modelPlayer.Cost,
                Number = number
            };

            context.Players.Add(newPlayer);
            context.SaveChanges();
            httpResponse.Success = true;
            return httpResponse;

        }
    } 
}
