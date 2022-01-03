using Logic.DTO_Models;
using Logic.Helpers;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiEndpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IAuthLogic authLogic;
        private DBSeed dBSeed;
        public AuthController(IAuthLogic authLogic, DBSeed dBSeed)
        {
            this.dBSeed = dBSeed;
            this.authLogic = authLogic;
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

        /// <summary>
        /// Not implemented properly
        /// </summary>
        [HttpPut]
        [Route("login")]

        public async Task<ActionResult> Login([FromBody] LoginDTO login)
        {
            return Ok(await authLogic.LoginUser(login));
        }
    }
}
