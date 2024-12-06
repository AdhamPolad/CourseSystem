using CourseSystem.Entities.Common;
using CourseSystem.Enum;
using System.Text.Json.Serialization;

namespace CourseSystem.Entities.AppDbContextEntity
{
    public class Role : BaseEntity
    {
        public RoleType Name { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public bool IsDeleted { get; set; }
    }
}
