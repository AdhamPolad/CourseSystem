using AutoMapper;
using CourseSystem.Dtos.Student;
using CourseSystem.Entities.AppDbContextEntity;

namespace CourseSystem.Mappings
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, GetStudentDto>().ForMember(x => x.StudentName, opt =>
            {
                opt.MapFrom(x => x.Name);
            }).ReverseMap();
            CreateMap<Student, PostStudentDto>().ReverseMap();
            CreateMap<Student, UpdateStudentDto>().ReverseMap();
        }
    }
}
