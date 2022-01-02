using Data.DB_Models;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IDepartmentLogic : ILogicService<Department>
    {
        Task AssignWorkerToDepartment(Worker worker, long Id);
    }
}
