using CourseSystem.Data;
using CourseSystem.Entities.AppDbContextEntity;

namespace CourseSystem.Seeds
{
    public class DataSeeder
    {
        private readonly CourseSystemDbContext _courseSystemDbContext;

        public DataSeeder(CourseSystemDbContext courseSystemDbContext)
        {
            _courseSystemDbContext = courseSystemDbContext;
        }


        public void Seed()
        {
            List<Role> roles = new List<Role>()
            {
                new Role()
                {
                    Name = Enum.RoleType.Admin
                },
                new Role()
                {
                    Name = Enum.RoleType.Adminstrator
                },
                new Role()
                {
                    Name = Enum.RoleType.User
                },
                new Role()
                {
                    Name = Enum.RoleType.Manager
                }

            };

            if (!_courseSystemDbContext.Roles.Any())
            {
                 _courseSystemDbContext.Roles.AddRange(roles);
                _courseSystemDbContext.SaveChanges();
            }

        }
    }
}
