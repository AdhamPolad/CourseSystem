using CourseSystem.Entities.Common;

namespace CourseSystem.Entities.AppDbContextEntity
{
    public class Group : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; }
        public Lesson? Lesson { get; set; }
        public int? LessonId { get; set; }
        public bool IsDeleted { get; set; }

    }
}
