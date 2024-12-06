using CourseSystem.Dtos.Student;
using Microsoft.AspNetCore.Mvc;

namespace CourseSystem.Services.Interfaces
{
    public interface IStudentService
    {
        Task<ObjectResult> UpdateStudentAsync(int id, UpdateStudentDto student);
        Task<ObjectResult> GetByGroupId(int groupId);
        Task<ObjectResult> DeleteStudentAsync(int id);
        Task<ObjectResult> GetAllAsync();
        Task<ObjectResult> AddAsync(PostStudentDto student);

    }
}
