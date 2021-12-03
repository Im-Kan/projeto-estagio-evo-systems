using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Funcionarios.Domain.Entities;
using Funcionarios.data.Context;
using Funcionarios.Application.Interface;

namespace asp_net_core_com_angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userServices;

        public UsersController(IUserService userService)
        {
            this.userServices = userService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            
            return Ok(this.userServices.Get());
        }
    }
}
