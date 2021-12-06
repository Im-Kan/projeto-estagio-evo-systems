using Funcionarios.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funcionarios.Domain.Interface
{
    public interface IDepartamentRepository : IRepository<Departament>
    {
        IEnumerable<Departament> GetAll();
    }
}
