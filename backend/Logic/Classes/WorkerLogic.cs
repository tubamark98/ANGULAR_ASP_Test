using AutoMapper;
using Logic.DTO_Models;
using Logic.Interfaces;
using Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logic.Classes
{
    public class WorkerLogic : IWorkerLogic
    {
        IWorkerRepo workerRepo;
        IMapper mapper;

        public WorkerLogic(IWorkerRepo workerRepo, IMapper mapper)
        {
            this.workerRepo = workerRepo;
            this.mapper = mapper;
        }

        public Task CreateWorker(CreateWorkerDTO worker)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteWorker(long Id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<ListWorkersDTO>> GetAllWorkers()
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateWorker(long Id, CreateWorkerDTO newWorker)
        {
            throw new System.NotImplementedException();
        }
    }
}
