using CourseSystem.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace CourseSystem.Entities.AppDbContextEntity
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<FileDetails> FileDetails { get; set; }   

    }
}
