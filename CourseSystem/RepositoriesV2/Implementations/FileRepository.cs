using CourseSystem.Data;
using CourseSystem.Entities.AppDbContextEntity;
using CourseSystem.RepositoriesV2.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CourseSystem.RepositoriesV2.Implementations
{
    public class FileRepository : IFileRepository
    {
        private readonly CourseSystemDbContext _courseSystemDbContext;

        public FileRepository(CourseSystemDbContext courseSystemDbContext)
        {
            _courseSystemDbContext = courseSystemDbContext;
        }
        

        public async Task<User> GetUser(int userId)
        {
            User? user = await _courseSystemDbContext.Users.Where(x => x.Id == userId)
                                                                .Include(x => x.FileDetails)
                                                                .FirstOrDefaultAsync();
            return user;

        }

        public async Task AddFileDetails(FileDetails fileDetails)
        {
            await _courseSystemDbContext.FileDetails.AddAsync(fileDetails);
            await _courseSystemDbContext.SaveChangesAsync();
        }



    }
}
