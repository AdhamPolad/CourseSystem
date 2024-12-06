using CourseSystem.Dtos.Role;
using CourseSystem.Dtos.Student;
using CourseSystem.Dtos.UserRoles;
using Microsoft.AspNetCore.Mvc;

namespace CourseSystem.Services.Interfaces
{
    public interface IRoleService
    {
        Task<ObjectResult> UpdateRoleAsync(int id, UpdateRoleDto role);
        Task<ObjectResult> DeleteRoleAsync(int id);
        Task<ObjectResult> GetAllAsync();
        Task<ObjectResult> AddAsync(PostRoleDto role);
        Task<ObjectResult> GetUserByRoleId(int roleId);

    }
}
