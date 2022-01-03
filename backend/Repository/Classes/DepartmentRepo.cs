using Data.DB_Models;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Classes
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private Data.workerDbContext db;

        public DepartmentRepo(Data.workerDbContext db)
        {
            this.db = db;
        }

        public async Task Add(Department element)
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

        public IQueryable<Department> GetAll()
        {
            return this.db.Departments;
        }

        public async Task<Department> GetOne(long key)
        {
            var entity = await (from x in db.Departments
                                where x.Id == key
                                select x).FirstOrDefaultAsync();
            return entity;
        }

        public async Task SaveDatabase()
        {
            await this.db.SaveChangesAsync();
        }

        public async Task Update(long oldKey, Department element)
        {
            var oldDepartment = await GetOne(oldKey);
            oldDepartment.Active = element.Active;
            oldDepartment.Name = element.Name;
            oldDepartment.Abreviation = element.Abreviation;

            await this.SaveDatabase();
        }
    }
}
