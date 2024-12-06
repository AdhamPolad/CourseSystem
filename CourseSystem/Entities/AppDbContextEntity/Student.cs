using CourseSystem.Entities.Common;

namespace CourseSystem.Entities.AppDbContextEntity
{
    public class Student : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Group? Group { get; set; }
        public int? GroupId { get; set; }
        public bool IsDeleted { get; set; }

    }
}
