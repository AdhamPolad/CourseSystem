using CourseSystem.Dtos.User;
using CourseSystem.Entities.AppDbContextEntity;
using Microsoft.AspNetCore.Mvc;

namespace CourseSystem.RepositoriesV2.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> AddUserAsync(User user, UserRole userRole);
        Task<bool> DeleteUserAsync(int id);
        Task<IEnumerable<User>> GetUsersAsync();
        Task<bool> UpdateUserAsync(int id, User user);
        Task AddUserAndFile(User user);
    }
}
