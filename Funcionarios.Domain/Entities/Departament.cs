using Funcionarios.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funcionarios.Domain.Entities
{
    public class Departament : Entity
    {
        public string Name { get; set; }
        public string Sigla { get; set; }
        //Navigation prop
        public ICollection<Worker> Workers { get; set; }


    }
}
