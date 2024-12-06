using CourseSystem.Data;
using CourseSystem.Dtos.Group;
using CourseSystem.Dtos.Student;
using CourseSystem.RepositoriesV2.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using Group = CourseSystem.Entities.AppDbContextEntity.Group;

namespace CourseSystem.RepositoriesV2.Implementations
{
    public class GroupRepositoryV2 : IGroupRepository
    {
        private readonly CourseSystemDbContext _courseSystemDbContext;

        public GroupRepositoryV2(CourseSystemDbContext courseSystemDbContext)
        {
            _courseSystemDbContext = courseSystemDbContext;
        }

        public async Task<bool> AddGroupAsync(Group group)
        {
            await _courseSystemDbContext.Groups.AddAsync(group);
            int effectedRow = await _courseSystemDbContext.SaveChangesAsync();
            return effectedRow > 0;
        }

        public async Task<bool> DeleteGroupAsync(int id)
        {
            Group group = await _courseSystemDbContext.Groups.FirstOrDefaultAsync(g => g.Id == id);

            group.IsDeleted = true;

            int effectedRow = await _courseSystemDbContext.SaveChangesAsync();
            return effectedRow > 0;

        }

        public async Task<IEnumerable<Group>> GetGroupByPaginate(int number, int size)
        {
            var groups = await _courseSystemDbContext.Groups.Include(x => x.Lesson)
                     .Include(x => x.Students)
                     .OrderBy(x => x.Id) // Ensure sorting by Id
                     .Skip((number - 1) * size) // Skip items of previous pages
                     .Take(size) // Take the specified number of items for the current page
                     .ToListAsync();

            return groups;
        }

        public async Task<IEnumerable<Group>> GetGroupsAsync()
        {
            var data = await _courseSystemDbContext.Groups.Include(x => x.Lesson)
                    .Include(x => x.Students)
                    .AsNoTracking()
                    .ToListAsync();

            return data;
        }

        public async Task<bool> UpdateGroupAsync(int id, Group group)
        {
            Group mainGroup = await _courseSystemDbContext.Groups.FirstOrDefaultAsync(x => x.Id == id);

            mainGroup.Name = group.Name;
            mainGroup.LessonId = group.LessonId;

            int effectedRow = await _courseSystemDbContext.SaveChangesAsync();
            return effectedRow > 0;
        }
    }
}
