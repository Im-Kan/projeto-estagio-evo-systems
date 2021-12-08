using Funcionarios.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funcionarios.Application.Viewmodel
{
    public class WorkerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RG { get; set; }
        //Navigation prop
        public int DepartamentId { get; set; }  
    }
}
