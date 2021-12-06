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
    public class WorkerRepository : Repository<Worker>, IWorkerRepository
    {
        public WorkerRepository(FuncionariosContext context)
            : base(context) { }

        public IEnumerable<Worker> GetAll()
        {
            return Query(x => !x.IsDeleted);
        }
    }
}
