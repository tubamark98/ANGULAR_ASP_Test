using Data;
using Data.DB_Models;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Classes
{
    public class WorkerRepo : IWorkerRepo
    {
        private Data.DbContext db;

        public WorkerRepo(Data.DbContext db)
        {
            this.db = db;
        }

        public async Task Add(Worker element)
        {
            await this.db.AddAsync(element);
            await this.db.SaveChangesAsync();
        }

        public async Task Delete(long element)
        {
            var entity = await GetOne(element);
            this.db.Remove(entity);
            await this.db.SaveChangesAsync();
        }

        public IQueryable<Worker> GetAll()
        {
            return this.db.Workers.DbSet;
        }

        public async Task<Worker> GetOne(long key)
        {
            var entity = await(from x in db.Workers.DbSet
                               where x.Id == key
                               select x).FirstOrDefaultAsync();
            return entity;
        }

        public async Task SaveDatabase()
        {
            await this.db.SaveChangesAsync();
        }

        public async Task Update(long oldKey, Worker element)
        {
            throw new System.NotImplementedException(); //not gonna do this yet, cause I might change the properties of Worker and I didnt wanna use reflections
        }
    }
}
