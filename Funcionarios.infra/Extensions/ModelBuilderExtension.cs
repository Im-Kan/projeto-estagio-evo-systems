using Funcionarios.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata;
using Funcionarios.Domain.Models;

namespace Funcionarios.data.Extensions
{
    public static class ModelBuilderExtension
    {

        public static ModelBuilder ApplyGlobalConfig(this ModelBuilder builder)
        {
            foreach (IMutableEntityType entityType in builder.Model.GetEntityTypes())
            {
                foreach (IMutableProperty property in entityType.GetProperties())
                {
                    switch (property.Name)
                    {
                        case nameof(Entity.Id):
                            property.IsKey();
                            break;

                        case nameof(Entity.DateUpdated):
                            property.IsNullable = true;
                            break;

                        case nameof(Entity.DateCreated):
                            property.IsNullable = false;
                            property.SetDefaultValue(DateTime.Now);
                            break;

                        case nameof(Entity.IsDeleted):
                            property.IsNullable = false;
                            property.SetDefaultValue(false);
                            break;

                        default:
                            break;
                    }
                }
            }

            return builder;
        }

        public static ModelBuilder SeedData(this ModelBuilder builder)
        {
            builder.Entity<Departament>()
                .HasData(
                    new Departament { Id = Guid.Parse("9519d358-a8d7-4350-8999-927c425b9e07"), Name = "Default", Sigla = "DF" , DateCreated = new DateTime(2021,12,3), IsDeleted = false , DateUpdated = null}
                );
            return builder;
        }

    }
}

