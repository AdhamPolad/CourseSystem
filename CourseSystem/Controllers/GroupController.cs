using CourseSystem.Dtos.Group;
using CourseSystem.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private IGroupService _groupService;
        private ILogger<GroupController> _logger;

        public GroupController(IGroupService groupService, ILogger<GroupController> logger)
        {
            _groupService = groupService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetGroupDto>>> All()
        {
            _logger.LogInformation("begin..");
            return await _groupService.GetGroupsAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Add(PostGroupDto group)
        {
            return await _groupService.AddGroupAsync(group);
        }

        [HttpGet]
        public async Task<IActionResult> FetchGroupsByPage(int number, int size)
        {
            return await _groupService.GetGroupByPaginate(number, size);

        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, UpdateGroupdto group)
        {
            return await _groupService.UdpdateGroupAsync(id, group);   
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return await _groupService.DeleteGroupAsync(id);
        }
    }
}
