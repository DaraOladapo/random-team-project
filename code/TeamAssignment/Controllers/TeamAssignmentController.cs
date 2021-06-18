using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TeamAssignment.Interfaces;
using TeamAssignment.Models;

namespace TeamAssignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamAssignmentController : ControllerBase
    {
        public TeamAssignmentController(IOptions<AppSettings> options, IRepositoryWrapper repositoryWrapper)
        {
            Configuration = options.Value;
            Repository = repositoryWrapper;
        }
        private AppSettings Configuration;
        private IRepositoryWrapper Repository;

        [HttpPost("Assign")]
        public async Task<ActionResult<Team>> Post([FromBody] string name)
        {
            var teamName = await new HttpClient().GetStringAsync($"{Configuration.TeamGeneratorServiceURL}/teamgenerator/team");
            var luckyNumber = await new HttpClient().GetStringAsync($"{Configuration.LuckyNumberServiceURL}");
            var createdTeam = Repository.Teams.Create(new Team()
            {
                Name = name,
                TeamName = teamName,
                LuckyNumber = int.Parse(luckyNumber)
            });
            Repository.Save();
            return Ok(createdTeam);

        }
        [HttpGet("Get-All")]
        public ActionResult<IEnumerable<Team>> GetAll()
        {
            return Repository.Teams.FindAll().ToList();;
        }

    }
}

