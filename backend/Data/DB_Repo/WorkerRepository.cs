using Data.DB_Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class WorkerRepository : IRepository<Worker>
    {
        public virtual DbSet<Worker> DbSet { get; set; }
    }
}
