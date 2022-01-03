using System.Linq;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IRepoBase<TReturnType, TKeyType> // Base for crud methods on repos
    {
        Task<TReturnType> GetOne(TKeyType key);

        IQueryable<TReturnType> GetAll();

        Task Add(TReturnType element);

        Task Delete(TKeyType element);

        Task Update(TKeyType oldKey, TReturnType element);

        Task SaveDatabase();
    }
}
