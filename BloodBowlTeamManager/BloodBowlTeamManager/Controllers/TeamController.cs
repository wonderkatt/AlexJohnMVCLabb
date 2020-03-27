using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

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
        public IEnumerable<object> Get() => context.Teams.ToList()
            .Select((team) => mapper.Map<TeamOverviewResponse>(team))
            .ToList();

        [Route("players")]
        [HttpGet]
        public IEnumerable<object> GetPlayers() => context.Players.ToList()
            .Where(p=>p.isAvailable == false)
            .Select((player) => mapper.Map<TeamPlayerDetailsResponse>(player))
            .ToList();

    } 
}
