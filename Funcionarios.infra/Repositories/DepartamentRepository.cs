using Funcionarios.data.Context;
using Funcionarios.Data.Repositories;
using Funcionarios.Domain.Entities;
using Funcionarios.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funcionarios.data.Repositories
{
    public class DepartamentRepository : Repository<Departament>, IDepartamentRepository
    {
        public DepartamentRepository(FuncionariosContext context)
            : base(context) { }

        public IEnumerable<Departament> GetAll()
        {
            return Query(x => !x.IsDeleted);
        }
    }
}
