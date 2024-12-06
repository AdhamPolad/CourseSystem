using AutoMapper;
using CourseSystem.Dtos.Lesson;
using CourseSystem.Entities.AppDbContextEntity;

namespace CourseSystem.Mappings
{
    public class LessonProfile : Profile
    {
        public LessonProfile()
        {
            CreateMap<Lesson, GetLessonDto>().ReverseMap();
        }
    }
}
