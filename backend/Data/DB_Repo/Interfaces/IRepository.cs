using Microsoft.EntityFrameworkCore;

namespace Data
{
    public interface IRepository<TEntity>
        where TEntity : class //CS0452 error otherwise
    {
        DbSet<TEntity> DbSet { get; } 
    }

}
