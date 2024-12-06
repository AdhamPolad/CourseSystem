using AutoMapper;
using CourseSystem.Dtos.File;
using CourseSystem.Entities.AppDbContextEntity;

namespace CourseSystem.Mappings
{
    public class FileProfile : Profile
    {

        public FileProfile()
        {
            CreateMap<FileDetails,GetFileDto>().ReverseMap();
        }
    }
}
