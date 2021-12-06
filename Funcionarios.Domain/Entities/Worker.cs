using Funcionarios.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funcionarios.Domain.Entities
{
    public class Worker: Entity
    {
        public string Name { get; set; }
        public string RG { get; set; }
        //Navigation prop
        public Departament Departament { get; set; }


    }
}
