using CourseSystem.Dtos.Lesson;
using CourseSystem.Entities.AppDbContextEntity;

namespace CourseSystem.RepositoriesV2.Interfaces
{
    public interface ILessonRepository
    {
        Task<IEnumerable<Lesson>> GetLessonsAsync();
    }
}
