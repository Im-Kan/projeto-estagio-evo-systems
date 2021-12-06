using Funcionarios.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funcionarios.Application.Interface
{
    public interface IWorkerService
    {
        List<Worker> Get();
    }
}
