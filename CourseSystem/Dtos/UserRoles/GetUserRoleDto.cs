using CourseSystem.Dtos.Role;
using CourseSystem.Dtos.User;
using CourseSystem.Entities;

namespace CourseSystem.Dtos.UserRoles
{
    public class GetUserRoleDto
    {
        public GetUserDto User { get; set; }
        public GetRoleDto Role { get; set; }
    }
}
