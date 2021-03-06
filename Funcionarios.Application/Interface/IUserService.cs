using Funcionarios.Application.Viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funcionarios.Application.Interface
{
    public interface IUserService
    {
        List<userViewModel> Get();
        bool Post(userViewModel userViewModel);
        userViewModel GetById(string id);
        bool Put(userViewModel userViewModel);
        bool Delete(string id);
    }
}
