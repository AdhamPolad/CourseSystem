using CourseSystem.Dtos.File;
using CourseSystem.Dtos.Role;
using CourseSystem.Entities;
using CourseSystem.Entities.AppDbContextEntity;
using System.ComponentModel.DataAnnotations;

namespace CourseSystem.Dtos.User
{
    public class GetUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<GetFileDto> FileDetails { get; set; }
    }
}
