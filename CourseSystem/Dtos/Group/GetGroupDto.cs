using CourseSystem.Dtos.Lesson;
using CourseSystem.Dtos.Student;

namespace CourseSystem.Dtos.Group
{
    public class GetGroupDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? LessonId { get; set; }
        public GetLessonDto? Lesson { get; set; }
        public ICollection<GetStudentDto> Students { get; set; }
    }
}
