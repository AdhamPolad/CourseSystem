using CourseSystem.Dtos.Lesson;
using Microsoft.AspNetCore.Mvc;

namespace CourseSystem.Services.Interfaces
{
    public interface ILessonService
    {
        Task<ObjectResult> GetLessonsAsync();
    }
}
