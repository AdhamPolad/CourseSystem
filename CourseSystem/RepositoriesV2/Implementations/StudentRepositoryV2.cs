using CourseSystem.Data;
using CourseSystem.Dtos.Student;
using CourseSystem.Entities.AppDbContextEntity;
using CourseSystem.RepositoriesV2.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CourseSystem.RepositoriesV2.Implementations
{
    public class StudentRepositoryV2 : IStudentRepository
    {
        private readonly CourseSystemDbContext _courseSystemDbContext;

        public StudentRepositoryV2(CourseSystemDbContext courseSystemDbContext)
        {
            _courseSystemDbContext = courseSystemDbContext;
        }

        public async Task<bool> AddStudentAsync(Student student)
        {
            await _courseSystemDbContext.Students.AddAsync(student);

            int rowEffected = await _courseSystemDbContext.SaveChangesAsync();
            return rowEffected > 0;
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            Student student = await _courseSystemDbContext.Students.FirstOrDefaultAsync(x => x.Id == id);

            student.IsDeleted = true;
            int effectedRow = await _courseSystemDbContext.SaveChangesAsync();
            return effectedRow > 0;

        }

        public async Task<IEnumerable<Student>> GetStudentsAsync()
        {
            var students = await _courseSystemDbContext.Students.Include(x => x.Group)
                    .AsNoTracking()
                    .ToListAsync();

            return students;
        }

        public async Task<IEnumerable<Student>> GetStudentsByGroupId(int groupId)
        {
            var student = await _courseSystemDbContext.Students.Where(x => x.GroupId == groupId)
                                        .Include(x => x.Group)
                                        .ToListAsync();

            return student;

        }

        public async Task<bool> UpdateStudentAsync(int id, Student student)
        {
            Student mainStudent = await _courseSystemDbContext.Students.FirstOrDefaultAsync(x => x.Id == id);

            mainStudent.Name = student.Name;
            mainStudent.Surname = student.Surname;
            mainStudent.GroupId = student.GroupId;
            int effectedRow = await _courseSystemDbContext.SaveChangesAsync();

            return effectedRow > 0;
        }
    }
}
