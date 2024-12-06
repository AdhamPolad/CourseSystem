using CourseSystem.Entities;
using CourseSystem.Enum;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Text.Json.Serialization;

namespace CourseSystem.Dtos.Role
{
    public class GetRoleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
