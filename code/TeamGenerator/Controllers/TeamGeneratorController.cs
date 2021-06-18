using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TeamGenerator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamGeneratorController : ControllerBase
    {
        private static readonly string[] Teams = new[]
        {
            "Alpha", "Bravo", "Charlie", "Delta", "Echo", "Foxtrot", "Gornimo", "Himalaya", "Indiana", "Julia"
        };

        [HttpGet("Team")]
        public ActionResult<string> Get()
        {
            var rnd = new Random();
            var teamIndex = rnd.Next(1, 10);
            return $"Team {Teams[teamIndex]}";
        }
    }
}
