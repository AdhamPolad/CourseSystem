using CourseSystem.Data;
using CourseSystem.Dtos.Group;
using CourseSystem.Dtos.Lesson;
using CourseSystem.Entities.AppDbContextEntity;
using CourseSystem.RepositoriesV2.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CourseSystem.RepositoriesV2.Implementations
{
    public class LessonRepositoryV2 : ILessonRepository
    {
        private readonly CourseSystemDbContext _courseSystemDbContext;

        public LessonRepositoryV2(CourseSystemDbContext courseSystemDbContext)
        {
            _courseSystemDbContext = courseSystemDbContext;
        }
        public async Task<IEnumerable<Lesson>> GetLessonsAsync()
        {
            var data = await _courseSystemDbContext.Lessons.Include(x => x.Groups)
                .AsNoTracking()
                       .ToListAsync();

            return data;
        }
    }
}
