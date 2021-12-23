using Data.DB_Models;
using Logic.Interfaces;
using Repository.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Logic.Classes
{
    public class WorkerLogic : IWorkerLogic
    {
        IWorkerRepo workerRepo;

        public WorkerLogic(IWorkerRepo workerRepo)
        {
            this.workerRepo = workerRepo;
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
