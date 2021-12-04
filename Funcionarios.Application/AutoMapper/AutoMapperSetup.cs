using AutoMapper;
using Funcionarios.Application.Viewmodel;
using Funcionarios.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funcionarios.Application.AutoMapper
{
    public class AutoMapperSetup: Profile
    {
        public AutoMapperSetup()
        {
            #region ViewModelToDomain

            CreateMap<UserViewModel, User>();

            #endregion


            #region DomainToViewModel

            CreateMap<User, UserViewModel>();

            #endregion
        }
    }
}
