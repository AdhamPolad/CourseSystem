using CourseSystem.Entities.AppDbContextEntity;

namespace CourseSystem.RepositoriesV2.Interfaces
{
    public interface IStudentRepository
    {
        Task<bool> AddStudentAsync(Student student);
        Task<bool> DeleteStudentAsync(int id);
        Task<IEnumerable<Student>> GetStudentsAsync();
        Task<IEnumerable<Student>> GetStudentsByGroupId(int groupId);
        Task<bool> UpdateStudentAsync(int id, Student student);

    }
}
