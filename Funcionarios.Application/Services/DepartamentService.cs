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
using Departament = Funcionarios.Domain.Entities.Departament;

namespace Funcionarios.Application.Services
{
    public class DepartamentService: IDepartamentService
    {
        private readonly IDepartamentRepository departamentRepository;
        private readonly IMapper mapper;

        public DepartamentService(IDepartamentRepository departamentRepository, IMapper mapper)
        {
            this.departamentRepository = departamentRepository;
            this.mapper = mapper;
        }

        public List<Departament> Get()
        {
            List<Departament> _departamentViewModels = new List<Departament>();

            IEnumerable<Departament> _departament = this.departamentRepository.GetAll();

            _departamentViewModels = mapper.Map<List<Departament>>(_departament);



            return _departamentViewModels;
        }
        public bool Post(Departament departament)
        {


            this.departamentRepository.Create(departament);

            return true;
        }
        public bool Put(Departament departamentViewModel)
        {
            Departament _departament = this.departamentRepository.Find(x => x.Id == departamentViewModel.Id && !x.IsDeleted);
            if (_departament == null)
                throw new Exception("User not found to be updated");
            _departament = mapper.Map<Departament>(departamentViewModel);
            this.departamentRepository.Update(_departament);
            return true;
        }

        public bool Delete(string id)
        {
            if (!int.TryParse(id, out int departamentId))
                throw new Exception("User ID is not valid");
            Departament _departament = this.departamentRepository.Find(x => x.Id == departamentId && !x.IsDeleted);
            if (_departament == null)
                throw new Exception("User not found");
            return this.departamentRepository.Delete(_departament);
        }

        public Departament GetById(string id)
        {
            if (!int.TryParse(id, out int depId))
                throw new Exception("User ID is not valid");
            Departament _dep = this.departamentRepository.Find(x => x.Id == depId && !x.IsDeleted);
            if (_dep == null)
                throw new Exception("User not found");
            return mapper.Map<Departament>(_dep);
        }
    }
}
