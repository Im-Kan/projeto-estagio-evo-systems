using Funcionarios.data.Extensions;
using Funcionarios.data.Mappings;
using Funcionarios.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace Funcionarios.data.Context
{
    public class FuncionariosContext: DbContext
    {
        public FuncionariosContext(DbContextOptions<FuncionariosContext>option)
            : base(option) { }
        #region "DbSets"

        public DbSet<User> Users { get; set; }
        public DbSet<Departament> Departament { get; set; }
        public DbSet<Worker> Worker { get; set; }

        #endregion



    }
}
