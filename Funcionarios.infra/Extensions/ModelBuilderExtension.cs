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


    }
}

