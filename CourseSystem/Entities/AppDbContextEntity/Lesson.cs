using CourseSystem.Entities.Common;

namespace CourseSystem.Entities.AppDbContextEntity
{
    public class Lesson : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Group> Groups { get; set; }
        public bool IsDeleted { get; set; }

    }
}
