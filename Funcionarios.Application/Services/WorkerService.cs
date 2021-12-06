using AutoMapper;
using Funcionarios.Application.Interface;
using Funcionarios.Domain.Entities;
using Funcionarios.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funcionarios.Application.Services
{ 
    public class WorkerService : IWorkerService
    {
        private readonly IWorkerRepository workerRepository;
        private readonly IMapper mapper;

        public WorkerService(IWorkerRepository workerRepository, IMapper mapper)
        {
            this.workerRepository = workerRepository;
            this.mapper = mapper;
        }

        public List<Worker> Get()
        {
            List<Worker> _workerViewModels = new List<Worker>();

            IEnumerable<Worker> _worker = this.workerRepository.GetAll();

            _workerViewModels = mapper.Map<List<Worker>>(_worker);



            return _workerViewModels;
        }
    }
}
