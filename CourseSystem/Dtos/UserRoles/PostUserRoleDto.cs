using CourseSystem.Dtos.User;
using CourseSystem.Entities.AppDbContextEntity;

namespace CourseSystem.Dtos.UserRoles
{
    public class PostUserRoleDto
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
