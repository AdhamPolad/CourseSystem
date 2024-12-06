using CourseSystem.Dtos.UserRoles;

namespace CourseSystem.Dtos.User
{
    public class PostUserAndUserRoleDto
    {
        public PostUserDto User { get; set; }
        public PostUserRoleDto UserRole { get; set; }
    }
}
