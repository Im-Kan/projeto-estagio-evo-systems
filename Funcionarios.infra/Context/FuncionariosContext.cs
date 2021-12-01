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

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());

            modelBuilder.SeedData();

            base.OnModelCreating(modelBuilder);
        }

    }
}
