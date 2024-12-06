using System.ComponentModel;

namespace CourseSystem.Enum
{
    public enum RoleType
    {
        [Description("Admin")]
        Admin = 1,
        [Description("Adminstrator")]
        Adminstrator = 2,
        [Description("User")]
        User = 3,
        [Description("Manager")]
        Manager = 4
    }
}
