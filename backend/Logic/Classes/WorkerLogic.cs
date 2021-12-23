using AutoMapper;
using Data.DB_Models;
using Logic.DTO_Models;
using Logic.Interfaces;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public async Task<Worker> AddAsync(Worker entity)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Worker entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Worker> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<Worker>> Query(Expression<Func<Worker, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<Worker> UpdateAsync(Worker entity)
        {
            throw new NotImplementedException();
        }
    }
}
