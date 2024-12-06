using CourseSystem.Entities.Common;

namespace CourseSystem.Entities.AppDbContextEntity
{
    public class FileDetails : BaseEntity
    {
        public string FileName { get; set; }
        public string Extension { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }


    }
}
