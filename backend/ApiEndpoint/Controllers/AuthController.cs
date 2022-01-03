using Logic.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiEndpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private DBSeed dBSeed;
        public AuthController(DBSeed dBSeed)
        {
            this.dBSeed = dBSeed;
        }

        /// <summary>
        /// Used only for development purposes, ONLY USE ONCE to populate database with example data
        /// </summary>
        /// <returns>200</returns>
        [HttpGet]
        [Route("db")]
        public async Task<ActionResult> PopulateDB()
        {
            dBSeed.PopulateDB();
            return Ok();
        }
    }
}
