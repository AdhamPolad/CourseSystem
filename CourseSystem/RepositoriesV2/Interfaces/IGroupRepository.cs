using CourseSystem.Dtos.Group;
using CourseSystem.Entities.AppDbContextEntity;

namespace CourseSystem.RepositoriesV2.Interfaces
{
    public interface IGroupRepository
    {
        Task<bool> AddGroupAsync(Group group);
        Task<bool> DeleteGroupAsync(int id);
        Task<IEnumerable<Group>> GetGroupByPaginate(int number, int size);
        Task<IEnumerable<Group>> GetGroupsAsync();
        Task<bool> UpdateGroupAsync(int id, Group group);


    }
}
