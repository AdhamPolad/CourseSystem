using CourseSystem.Data;
using CourseSystem.Dtos.Role;
using CourseSystem.Dtos.User;
using CourseSystem.Dtos.UserRoles;
using CourseSystem.Entities.AppDbContextEntity;
using CourseSystem.Enum;
using CourseSystem.RepositoriesV2.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace CourseSystem.RepositoriesV2.Implementations
{
    public class RoleRepository : IRoleRepository
    {
        private readonly CourseSystemDbContext _courseSystemDbContext;
        public RoleRepository(CourseSystemDbContext courseSystemDbContext)
        {
            _courseSystemDbContext = courseSystemDbContext;
        }
        public async Task<bool> AddRoleAsync(Role role)
        {
            await _courseSystemDbContext.Roles.AddAsync(role);
            int effectedRow = await _courseSystemDbContext.SaveChangesAsync();
            return effectedRow > 0;
        }

        public async Task<bool> DeleteRoleAsync(int id)
        {
            var role = await _courseSystemDbContext.Roles.FirstOrDefaultAsync(r => r.Id == id);
            role.IsDeleted = true;
            int effectedRow = await _courseSystemDbContext.SaveChangesAsync();
            return effectedRow > 0;

        }

        public async Task<IEnumerable<Role>> GetRolesAsync()
        {
            return await _courseSystemDbContext.Roles
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<bool> UpdateRoleAsync(int id, Role role)
        {
            var mainRole = await _courseSystemDbContext.Roles.FirstOrDefaultAsync(x => x.Id == id);
            mainRole.Name = role.Name;
            int effectedRow = await _courseSystemDbContext.SaveChangesAsync();
            return effectedRow > 0;
        }


        public async Task<List<UserRole>> GetUserByRoleId(int roleId)
        {
            var data = await _courseSystemDbContext.UserRoles.Include(ur => ur.User)
                        .Include(ur => ur.Role)
                        .Where(ur => ur.RoleId == roleId)
                        .ToListAsync();


            return data;

        }

    }
}
