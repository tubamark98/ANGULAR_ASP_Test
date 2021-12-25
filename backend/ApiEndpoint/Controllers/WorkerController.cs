using Data.DB_Models;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ApiEndpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        IWorkerLogic logicService;

        public WorkerController(IWorkerLogic logicService) //Dependency Injection
        {
            this.logicService = logicService;
        }

        [HttpPost("/CreateWorker")]
        public async Task<ActionResult> CreateWorker([FromBody] Worker worker)
        {
            await logicService.AddAsync(worker);
            return Ok();
        }

        [HttpGet("/GetAllWorker")]
        public async Task<ActionResult<Worker>> GetAllWorker()
        {
            Expression<Func<Worker, bool>> expression = null;
            return Ok(await logicService.Query(expression));
        }

        [HttpPut("/UpdateWorker")]
        public async Task<ActionResult> UpdateWorker([FromBody] Worker worker)
        {
            await logicService.UpdateAsync(worker);
            return Ok();
        }

        [HttpDelete("/DeleteWorker")]
        public async Task<ActionResult> DeleteWorker([FromBody] Worker worker)
        {
            await logicService.DeleteAsync(worker);
            return Ok();
        }

        [HttpGet("/GetWorker/{Id}")]
        public async Task<ActionResult<Worker>> GetWorker(long Id)
        {
            return Ok(await logicService.GetByIdAsync(Id));
        }
    }
}
