using AutoMapper;
using CourseSystem.Dtos.Group;
using CourseSystem.Entities.AppDbContextEntity;

namespace CourseSystem.Mappings
{
    public class GroupProfile : Profile
    {
        public GroupProfile()
        {
            CreateMap<Group, GetGroupDto>().ReverseMap();
            CreateMap<Group, UpdateGroupdto>().ReverseMap();
            CreateMap<Group, PostGroupDto>().ReverseMap();
            CreateMap<Group, GroupDtoForGetLesson>().ReverseMap();

        }
    }
}
