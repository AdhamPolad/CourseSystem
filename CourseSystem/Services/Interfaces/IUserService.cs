using CourseSystem.Dtos.Student;
using CourseSystem.Dtos.User;
using CourseSystem.Dtos.UserRoles;
using Microsoft.AspNetCore.Mvc;

namespace CourseSystem.Services.Interfaces
{
    public interface IUserService
    {
        Task<ObjectResult> UpdateUserAsync(int id, UpdateUserDto user);
        Task<ObjectResult> DeleteAsync(int id);
        Task<ObjectResult> GetAllAsync();
        Task<ObjectResult> AddAsync(PostUserAndUserRoleDto UserAndUSerRole);
        Task<ObjectResult> AddUserAndFile(IFormFile formFile, PostUserDto postUserDto);
    }
}
