using Data.DB_Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class DbContext : IdentityDbContext<IdentityUser>, IRepository<Worker>, IRepository<Department>
    {
        public DbContext()
        {
            this.Database.EnsureCreated();
        }

        public DbContext(DbContextOptions<DbContext> opt) : base(opt)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=workerdb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Worker> Workers { get; set; }
        public virtual DbSet<Department> Departments{ get; set; }

        DbSet<Worker> IRepository<Worker>.DbSet { get { return Workers; } }
        DbSet<Department> IRepository<Department>.DbSet { get { return Departments; } }
    }
}
