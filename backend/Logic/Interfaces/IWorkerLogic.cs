using Data.DB_Models;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IWorkerLogic : ILogicService<Worker>
    {
        Task<Worker> FindByNameAsync(string username);
    }
}
