using CourseSystem.Dtos.Role;
using CourseSystem.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            return await _roleService.GetAllAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Add(PostRoleDto role)
        {
            return await _roleService.AddAsync(role);
        }

        [HttpGet]
        public async Task<IActionResult> GetUserByRoleId(int roleId)
        {
            return await _roleService.GetUserByRoleId(roleId);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return await _roleService.DeleteRoleAsync(id);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, UpdateRoleDto updateRole)
        {
            return await _roleService.UpdateRoleAsync(id, updateRole);
        }

    }
}
