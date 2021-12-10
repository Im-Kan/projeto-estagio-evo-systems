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

            IEnumerable<Worker> _workers = this.workerRepository.GetAll();

            _workerViewModels = mapper.Map<List<Worker>>(_workers);



            return _workerViewModels;

        }
        public List<Worker> GetByDI(int departamentId)
        {
            List<Worker> _workerViewModels = new List<Worker>();

            IEnumerable<Worker> _workers = this.workerRepository.GetAll();
            foreach (Worker worker in _workers)
            {
                if (worker.DepartamentId == departamentId)
                    _workerViewModels.Add(worker);

            }

            return _workerViewModels;
        }
        public Worker GetById(string id)
        {
            if (!int.TryParse(id, out int workerId))
                throw new Exception("User ID is not valid");
            Worker _worker = this.workerRepository.Find(x => x.Id == workerId && !x.IsDeleted);
            if (_worker == null)
                throw new Exception("User not found");
            return _worker;
        }

        public bool Post(Worker worker)
        {


            this.workerRepository.Create(worker);

            return true;

        }
        public bool Put(Worker workerViewModel)
        {
            Worker _worker = this.workerRepository.Find(x => x.Id == workerViewModel.Id && !x.IsDeleted);
            if (_worker == null)
                throw new Exception("User not found to be updated");
            _worker = mapper.Map<Worker>(workerViewModel);
            this.workerRepository.Update(_worker);
            return true;
        }

        public bool Delete(string id)
        {
            if (!int.TryParse(id, out int workerId))
                throw new Exception("User ID is not valid");
            Worker _worker = this.workerRepository.Find(x => x.Id == workerId && !x.IsDeleted);
            if (_worker == null)
                throw new Exception("User not found");
            return this.workerRepository.Delete(_worker);
        }



    }
}

