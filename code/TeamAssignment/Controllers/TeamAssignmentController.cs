using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TeamAssignment.Models;

namespace TeamAssignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamAssignmentController : ControllerBase
    {
        public TeamAssignmentController(IOptions<AppSettings> options)
        {
            Configuration = options.Value;
        }
        private AppSettings Configuration;

        [HttpPost("Assign")]
        public async Task<ActionResult<Team>> Post([FromBody] string name)
        {
            var teamName = await new HttpClient().GetStringAsync($"{Configuration.TeamGeneratorServiceURL}/teamgenerator/team");
            var luckyNumber = await new HttpClient().GetStringAsync($"{Configuration.LuckNumberServiceURL}");
            return Ok(new Team()
            {
                Name = name,
                TeamName = teamName,
                LuckyNumber = int.Parse(luckyNumber)
            });

        }
        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<Team>> GetAll()
        {
            throw new NotImplementedException();
        }

    }
}

