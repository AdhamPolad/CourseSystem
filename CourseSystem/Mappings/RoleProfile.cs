using AutoMapper;
using CourseSystem.Dtos.Role;
using CourseSystem.Dtos.UserRoles;
using CourseSystem.Entities.AppDbContextEntity;

namespace CourseSystem.Mappings
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, GetRoleDto>().ReverseMap();
            CreateMap<Role, PostRoleDto>().ReverseMap(); 
            CreateMap<Role, UpdateRoleDto>().ReverseMap();
            CreateMap<UserRole, GetUserRoleDto>().ReverseMap();

        }
    }
}
