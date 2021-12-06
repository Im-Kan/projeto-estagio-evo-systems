using AutoMapper;
using Funcionarios.Application.Interface;
using Funcionarios.Application.Viewmodel;
using Funcionarios.Domain.Entities;
using Funcionarios.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funcionarios.Application.Services
{
    public class UserService: IUserService
    {

        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }
        public List<UserViewModel> Get()
        {
            List<UserViewModel> _userViewModels = new List<UserViewModel>();

            IEnumerable<User> _users = this.userRepository.GetAll();

            _userViewModels = mapper.Map<List<UserViewModel>>(_users);

            

            return _userViewModels;

        }

        public bool Post(UserViewModel userViewModel)
        {

            User _user = mapper.Map<User>(userViewModel);

            this.userRepository.Create(_user);
            
            return true;
        }

        public UserViewModel GetById(string id)
        {
            if (!Guid.TryParse(id, out Guid userId))
                throw new Exception("User ID is not valid");
            User _user = this.userRepository.Find(x => x.Id == userId && !x.IsDeleted);
            if (_user == null)
                throw new Exception("User not found");
            return mapper.Map<UserViewModel>(_user);
        }

        public bool Put(UserViewModel userViewModel)
        {
            User _user = this.userRepository.Query(x => x.Id == userViewModel.Id && !x.IsDeleted).FirstOrDefault();
            if (_user == null)
                throw new Exception("User not found to be updated");
            _user = mapper.Map<User>(userViewModel);
            this.userRepository.Update(_user);
            return true;
        }

        public bool Delete(string id)
        {
            if (!Guid.TryParse(id, out Guid userId))
                throw new Exception("User ID is not valid");
            User _user = this.userRepository.Find(x => x.Id == userId && !x.IsDeleted);
            if (_user == null)
                throw new Exception("User not found");
            return this.userRepository.Delete(_user);
        }
    }
}
