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
    }
}
