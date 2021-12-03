using Funcionarios.Application.Interface;
using Funcionarios.Application.Services;
using Funcionarios.data.Repositories;
using Funcionarios.Domain.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Funcionarios.IoC
{
    public static class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region Services

            services.AddScoped<IUserService, UserService>();

            #endregion

            #region Repositories

            services.AddScoped<IUserRepository, UserRepository>();

            #endregion
        }
    }
}
