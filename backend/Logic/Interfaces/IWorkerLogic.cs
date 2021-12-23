using Logic.DTO_Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IWorkerLogic
    {
        Task CreateWorker(CreateWorkerDTO worker);

        Task<List<ListWorkersDTO>> GetAllWorkers();
        
        Task UpdateWorker(long Id, CreateWorkerDTO newWorker);

        Task DeleteWorker(long Id);
    }
}
