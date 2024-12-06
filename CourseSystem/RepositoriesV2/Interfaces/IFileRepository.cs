using CourseSystem.Entities.AppDbContextEntity;

namespace CourseSystem.RepositoriesV2.Interfaces
{
    public interface IFileRepository
    {
        Task<User> GetUser(int userId);
        Task AddFileDetails(FileDetails fileDetails);
    }
}
