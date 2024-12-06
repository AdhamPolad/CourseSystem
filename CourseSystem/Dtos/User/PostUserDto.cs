using CourseSystem.Entities;
using System.ComponentModel.DataAnnotations;

namespace CourseSystem.Dtos.User
{
    public class PostUserDto
    {
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
} 
