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
        private Data.workerDbContext db;

        public WorkerRepo(Data.workerDbContext db)
        {
            this.db = db;
        }

        public async Task Add(Worker element)
        {
            await this.db.AddAsync(element);
            await this.SaveDatabase();
        }

        public async Task Delete(long element)
        {
            var entity = await GetOne(element);
            this.db.Remove(entity);
            await this.SaveDatabase();
        }

        public IQueryable<Worker> GetAll()
        {
            return this.db.Workers;
        }

        public async Task<Worker> GetOne(long key)
        {
            var entity = await(from x in db.Workers
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
            var oldWorker = await GetOne(oldKey);
            oldWorker.Active = element.Active;
            oldWorker.Department = element.Department;
            oldWorker.Name = element.Name;
            oldWorker.Password = element.Password;
            oldWorker.PhoneNumber = element.PhoneNumber;
            oldWorker.Supervisor = element.Supervisor;
            oldWorker.UserName = element.UserName;
            oldWorker.DepartmentId = element.DepartmentId;
            await this.SaveDatabase();
        }
    }
}
