using Logic.DTO_Models;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IAuthLogic
    {
        Task<TokenModel> LoginUser(LoginDTO login);
    }
}
