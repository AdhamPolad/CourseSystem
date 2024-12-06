using CourseSystem.Dtos.File;
using CourseSystem.Dtos.Student;
using CourseSystem.Dtos.User;
using CourseSystem.Dtos.UserRoles;
using CourseSystem.Filter;
using CourseSystem.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IFileService _fileService;
        public UserController(IUserService userService, IFileService fileService)
        {
            _userService = userService;
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserFile(int userId)
        {
            FileResponceDto fileResponceDto = await _fileService.Download(userId);

            return File(fileResponceDto.Data, "application/octet-stream", fileResponceDto.FileName);
        }

        [HttpPost]
        public async Task<IActionResult> AddUserAndFile(IFormFile formFile, [FromForm] PostUserDto postUserDto)
        {
            return await _userService.AddUserAndFile(formFile, postUserDto);
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            return await _userService.GetAllAsync();
        }

        [HttpPost]
        [TypeFilter(typeof(ModelStateHandler))]
        public async Task<IActionResult> Add(PostUserAndUserRoleDto UserAndUserRole)
        {
            return await _userService.AddAsync(UserAndUserRole);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return await _userService.DeleteAsync(id);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, UpdateUserDto user)
        {
            return await _userService.UpdateUserAsync(id, user);
        }


    }
}
