using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Funcionarios.Domain.Entities;

namespace Funcionarios.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Names { get; set; }

        public string Email { get; set; }
    }
}
