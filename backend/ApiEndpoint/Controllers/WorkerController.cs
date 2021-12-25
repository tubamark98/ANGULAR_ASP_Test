using Logic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEndpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        IWorkerLogic logicService;

        public WorkerController(IWorkerLogic logicService)//Dependency Injection
        {
            this.logicService = logicService;
        }
    }
}
