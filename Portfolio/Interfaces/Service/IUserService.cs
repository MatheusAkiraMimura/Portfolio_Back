using Portfolio.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Portfolio.Interfaces
{
    public interface IUserService
    {
        Task<User> RegisterUser(User user);
        Task<User> GetUserById(int id);
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> UpdateUser(User user);
        Task DeleteUser(int id);
        // Você pode adicionar outros métodos conforme necessário

        Task<User> Authenticate(string email, string senha);
    }
}
