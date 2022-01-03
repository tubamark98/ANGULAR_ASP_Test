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
    public class DepartmentController : ControllerBase
    {
        IDepartmentLogic logicService;

        public DepartmentController(IDepartmentLogic logicService) //Dependency Injection
        {
            this.logicService = logicService;
        }

        [HttpPost("/CreateDepartment")]
        public async Task<ActionResult> CreateDepartment([FromBody] Department department)
        {
            await logicService.AddAsync(department);
            return Ok();
        }

        [HttpGet("/GetAllDepartments")]
        public async Task<ActionResult<Department>> GetAllDepartments()
        {
            Expression<Func<Department, bool>> expression = x => x is Department;
            return Ok(await logicService.Query(expression));
        }

        [HttpGet("/GetAllActiveDepartments")]
        public async Task<ActionResult<Department>> GetAllActiveDepartments()
        {
            Expression<Func<Department, bool>> expression = x => x.Active == true;
            return Ok(await logicService.Query(expression));
        }

        [HttpPut("/UpdateDepartment")]
        public async Task<ActionResult> UpdateDepartment([FromBody] Department department)
        {
            await logicService.UpdateAsync(department);
            return Ok();
        }

        [HttpDelete("/DeleteDepartment/{Id}")]
        public async Task<ActionResult> DeleteDepartment(long Id)
        {
            await logicService.DeleteAsync(await logicService.GetByIdAsync(Id)); //not every pretty
            return Ok();
        }

        [HttpGet("/GetDepartment/{Id}")]
        public async Task<ActionResult<Department>> GetDepartment(long Id)
        {
            return Ok(await logicService.GetByIdAsync(Id));
        }

        [HttpGet("/AssignWorker/{Id}")]
        public async Task<ActionResult> AssignWorkerToDepartment([FromBody] Worker worker, long Id)
        {
            await logicService.AssignWorkerToDepartment(worker, Id);
            return Ok();
        }
    }
}
