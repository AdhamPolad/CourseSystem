using CourseSystem.Entities.AppDbContextEntity;

namespace CourseSystem.RepositoriesV2.Interfaces
{
    public interface IRoleRepository
    {
        Task<bool> AddRoleAsync(Role role);
        Task<bool> DeleteRoleAsync(int id);
        Task<IEnumerable<Role>> GetRolesAsync();
        Task<bool> UpdateRoleAsync(int id, Role role);
        Task<List<UserRole>> GetUserByRoleId(int roleId);

    }
}
