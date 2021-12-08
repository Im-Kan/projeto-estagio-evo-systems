using Funcionarios.Application.Interface;
using Funcionarios.Application.Viewmodel;
using Funcionarios.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_net_core_com_angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkersController : ControllerBase
    {
        private readonly IWorkerService workerService;

        public WorkersController(IWorkerService workerService)
        {
            this.workerService = workerService;
        }

        [HttpGet]
        public IActionResult Get()
        {

            return Ok(this.workerService.Get());
        }
        [HttpGet("{departamentId}")]
        public IActionResult GetByDI(int departamentId)
        {
            return Ok(this.workerService.GetByDI(departamentId));
        }

        [HttpPost]
        public IActionResult Post(Worker worker)
        {
            return NewMethod(worker);
        }

        private IActionResult NewMethod(Worker worker)
        {
            return Ok(this.workerService.Post(worker));
        }
        [HttpPut]
        public IActionResult Put(Worker worker)
        {
            return Ok(this.workerService.Put(worker));
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            return Ok(this.workerService.Delete(id));
        }
    }
}
