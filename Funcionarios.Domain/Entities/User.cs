using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Funcionarios.Domain.Entities;
using Funcionarios.Domain.Models;

namespace Funcionarios.Domain.Entities
{
    public class User: Entity
    {
        public string Name { get; set; }

        public string Email { get; set; }

        private string password { get; set; }
    }
}
