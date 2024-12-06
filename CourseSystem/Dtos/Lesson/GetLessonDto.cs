using CourseSystem.Dtos.Group;

namespace CourseSystem.Dtos.Lesson
{
    public class GetLessonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<GroupDtoForGetLesson> Groups { get; set; }
    }
}
