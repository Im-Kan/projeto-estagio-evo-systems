using Funcionarios.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funcionarios.data.Extensions
{
    public static class ModelBuilderExtension
    {
        public static ModelBuilder SeedData(this ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasData(
                    new User { Id = Guid.Parse("e28234c7-e309-418e-9367-f6c456469cf1"), Names = "User Default", Email = "userdefault@funcionarios.com" }
                );
            return builder;
        }
    }
}

