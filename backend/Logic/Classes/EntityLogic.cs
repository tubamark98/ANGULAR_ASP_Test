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
    public class EntityLogic : ILogicService<Entity>
    {
        IRepoBase<Entity,long> entityRepo;

        public EntityLogic(IRepoBase<Entity, long> enityRepo)
        {
            this.entityRepo = enityRepo;
        }

        public async Task<Entity> AddAsync(Entity entity)
        {
            var query = (from x in entityRepo.GetAll()
                          where x.Id == entity.Id
                          select x).FirstOrDefault();

            if(query == null)
            {
                await entityRepo.Add(entity);
                entity.Active = true;
                return entity;
            }
            else
            {
                throw new NotFoundException(WorkerErrorMessages.WorkerExists);
            }
        }

        public async Task DeleteAsync(Entity entity)
        {
            if (await entityRepo.GetOne(entity.Id) != null)
            {
                await entityRepo.Delete(entity.Id);
            }
            else
            {
                throw new NotFoundException(WorkerErrorMessages.WorkerNotFound);
            }
        }

        public async Task<Entity> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<Entity>> Query(Expression<Func<Entity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<Entity> UpdateAsync(Entity entity)
        {
            throw new NotImplementedException();
        }
    }
}
