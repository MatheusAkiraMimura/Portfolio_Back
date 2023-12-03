using Portfolio.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Portfolio.Interfaces.Repository
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> AddAsync(User user);
        Task<User> UpdateAsync(User user);
        Task DeleteAsync(int id);

        Task<bool> IsEmailUniqueAsync(string email);

        Task<User> GetByEmailAsync(string email);
    }
}
