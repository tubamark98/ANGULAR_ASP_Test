using Data.DB_Models;
using Logic.Helpers;
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
            var query = (from x in workerRepo.GetAll()
                          where x.Id == entity.Id
                          select x).FirstOrDefault();

            if(query == null)
            {
                await workerRepo.Add(entity);
            }
            else
            {
                throw new NotFoundException(WorkerErrorMessages.WorkerExists);
            }
        }

        public async Task DeleteAsync(Worker entity)
        {
            if (await workerRepo.GetOne(entity.Id) != null)
            {
                await workerRepo.Delete(entity.Id);
            }
            else
            {
                throw new NotFoundException(WorkerErrorMessages.WorkerNotFound);
            }
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
