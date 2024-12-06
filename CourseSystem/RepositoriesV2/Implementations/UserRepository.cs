using CourseSystem.Data;
using CourseSystem.Dtos.Group;
using CourseSystem.Dtos.Role;
using CourseSystem.Dtos.User;
using CourseSystem.Dtos.UserRoles;
using CourseSystem.Entities.AppDbContextEntity;
using CourseSystem.RepositoriesV2.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseSystem.RepositoriesV2.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly CourseSystemDbContext _courseSystemDbContext;

        public UserRepository(CourseSystemDbContext courseSystemDbContext)
        {
            _courseSystemDbContext = courseSystemDbContext;
        }

        public async Task AddUserAndFile(User user)
        {
            await _courseSystemDbContext.Users.AddAsync(user);
            await _courseSystemDbContext.SaveChangesAsync();
        }


        public async Task<bool> AddUserAsync(User user, UserRole userRole)
        {
            using var transaction = await _courseSystemDbContext.Database.BeginTransactionAsync();
            try
            {

                await _courseSystemDbContext.Users.AddAsync(user);

                await _courseSystemDbContext.UserRoles.AddAsync(userRole);
                int effectedRow = await _courseSystemDbContext.SaveChangesAsync();

                await transaction.CommitAsync();
                return effectedRow > 0;
            }
            catch (Exception exp)
            {
                await transaction.RollbackAsync();
                return false;
            }
            

        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _courseSystemDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            user.IsDeleted = true;
            int effectedRow = await _courseSystemDbContext.SaveChangesAsync();
            return effectedRow > 0;

        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _courseSystemDbContext.Users
                               .Include(u=>u.FileDetails)
                               .Include(u => u.UserRoles)
                               .ThenInclude(ur => ur.Role)
                               .AsNoTracking()
                               .ToListAsync();
        }

        public async Task<bool> UpdateUserAsync(int id, User user)
        {
            var mainUser = await _courseSystemDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            mainUser.Name = user.Name;
            mainUser.Password = user.Password;
            mainUser.Email = user.Email;

            int effectedRow = await _courseSystemDbContext.SaveChangesAsync();
            return effectedRow > 0;

        }

    

    }
}
