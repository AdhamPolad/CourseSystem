using CourseSystem.Dtos.Group;
using Microsoft.AspNetCore.Mvc;

namespace CourseSystem.Services.Interfaces
{
    public interface IGroupService
    {
        Task<ObjectResult> UdpdateGroupAsync(int id, UpdateGroupdto group);
        Task<ObjectResult> DeleteGroupAsync(int id);
        Task<ObjectResult> AddGroupAsync(PostGroupDto group);
        Task<ObjectResult> GetGroupByPaginate(int number, int size);
        Task<ObjectResult> GetGroupsAsync();
    }
}
