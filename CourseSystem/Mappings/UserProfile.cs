using AutoMapper;
using CourseSystem.Dtos.User;
using CourseSystem.Dtos.UserRoles;
using CourseSystem.Entities.AppDbContextEntity;

namespace CourseSystem.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, GetUserDto>().ReverseMap();
            CreateMap<User, PostUserDto>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();
            CreateMap<UserRole, PostUserRoleDto>().ReverseMap();
        }
    }
}
