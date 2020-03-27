﻿using AutoMapper;
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

        }
        [Route("players")]
        [HttpGet]
        public IEnumerable<object> GetPlayers()
        {
            var rawPlayers = context.Players.Where(p=>p.isAvailable == false).ToList();

            return rawPlayers.Select((player) => mapper.Map<TeamPlayerDetailsResponse>(player));

        }
    }
}
