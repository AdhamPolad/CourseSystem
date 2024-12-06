using AutoMapper;
using CourseSystem.Dtos.Lesson;
using CourseSystem.RepositoriesV2.Interfaces;
using CourseSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CourseSystem.Services.Implementations
{
    public class LessonService : ILessonService
    {
        private readonly ILessonRepository _lessonRepository;
        private readonly IMapper _mapper;
        public LessonService(ILessonRepository lessonRepository, IMapper mapper)
        {
            _lessonRepository = lessonRepository;
            _mapper = mapper;
        }

        public async Task<ObjectResult> GetLessonsAsync()
        {
            var data = await _lessonRepository.GetLessonsAsync(); 
            var lessons = _mapper.Map<List<GetLessonDto>>(data);

            if( data.Any() )
            {
                return new ObjectResult(lessons)
                {
                    StatusCode = 200,
                };
            }
            else
            {
                return new ObjectResult("invalid data")
                {
                    StatusCode = 404
                };
            }
        }

    }
}
