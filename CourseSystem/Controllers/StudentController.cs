using CourseSystem.Dtos.Student;
using CourseSystem.Services.Implementations;
using CourseSystem.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, UpdateStudentDto updateStudentDto)
        {
            return await _studentService.UpdateStudentAsync(id, updateStudentDto);

        }


        [HttpGet("{groupId}")]
        public async Task<IActionResult> GetByGroupId(int groupId)
        {
            return await _studentService.GetByGroupId(groupId);
        }



        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return await _studentService.DeleteStudentAsync(id);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return await _studentService.GetAllAsync();
        }


        [HttpPost]
        public async Task<IActionResult> Add(PostStudentDto student)
        {
            return await _studentService.AddAsync(student);

        }

    }
}
