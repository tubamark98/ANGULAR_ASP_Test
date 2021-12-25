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

            if(query == null)   //Check if it exists in the repo
            {
                try
                {
                    await entityRepo.Add(entity);
                    entity.Active = true;
                    return entity;
                }
                catch 
                {
                    entity.Active = false;
                    return entity;
                }
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
            return await entityRepo.GetOne(id);
        }

        public async Task<IQueryable<Entity>> Query(Expression<Func<Entity, bool>> predicate) //wasnt certain what to do with the predicate
        {
            return this.entityRepo.GetAll().AsQueryable(); //not async yet
        }

        public async Task<Entity> UpdateAsync(Entity entity)
        {
            if (await entityRepo.GetOne(entity.Id) != null)
            {
                await entityRepo.Update(entity.Id, entity);
                return entity;
            }
            else
            {
                throw new NotFoundException(WorkerErrorMessages.WorkerNotFound);
            }
        }
    }
}
