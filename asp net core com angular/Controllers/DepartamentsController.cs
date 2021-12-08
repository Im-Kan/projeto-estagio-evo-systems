using Funcionarios.Application.Interface;
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
    public class DepartamentsController : ControllerBase
    {
        private readonly IDepartamentService departamentService;

        public DepartamentsController(IDepartamentService departamentService)
        {
            this.departamentService = departamentService;
        }

        [HttpGet]
        public IActionResult Get()
        {

            return Ok(this.departamentService.Get());
        }

        [HttpPost]
        public IActionResult Post(Departament departament)
        {
            return NewMethod(departament);
        }

        private IActionResult NewMethod(Departament departament)
        {
            return Ok(this.departamentService.Post(departament));
        }
        [HttpPut]
        public IActionResult Put(Departament departament)
        {
            return Ok(this.departamentService.Put(departament));
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            return Ok(this.departamentService.Delete(id));
        }
    }
}
