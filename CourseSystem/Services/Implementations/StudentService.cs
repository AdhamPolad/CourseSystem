using AutoMapper;
using CourseSystem.Dtos.Student;
using CourseSystem.Entities.AppDbContextEntity;
using CourseSystem.RepositoriesV2.Interfaces;
using CourseSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CourseSystem.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<ObjectResult> UpdateStudentAsync(int id, UpdateStudentDto student)
        {
            if (id <= 0)
            {
                return new ObjectResult("invalid id")
                {
                    StatusCode = 400
                };
            }
            Student mainStudent = _mapper.Map<Student>(student);
            bool effectedRow = await _studentRepository.UpdateStudentAsync(id, mainStudent);
            if (effectedRow)
            {
                return new ObjectResult(student)
                {
                    StatusCode = 200
                };
            }
            else
            {
                return new ObjectResult("Invalid Operation")
                {
                    StatusCode = 400
                };
            }

        }

        public async Task<ObjectResult> GetByGroupId(int groupId)
        {
            var data = await _studentRepository.GetStudentsByGroupId(groupId);
            var students = _mapper.Map<List<GetStudentDto>>(data);
            if (groupId <= 0)
            {
                return new ObjectResult("invalid groupId")
                {
                    StatusCode = 400
                };
            }


            if (data.Any())
            {
                return new ObjectResult(students)
                {
                    StatusCode = 200
                };
            }
            else
            {
                return new ObjectResult("Invalid data")
                {
                    StatusCode = 404
                };
            }

        }

        public async Task<ObjectResult> DeleteStudentAsync(int id)
        {
            if (id <= 0)
            {
                return new ObjectResult("Invalid id")
                {
                    StatusCode = 400
                };
            }
            bool effectedRow = await _studentRepository.DeleteStudentAsync(id);

            if (effectedRow)
            {
                return new ObjectResult($"Deleted student who id is {id}")
                {
                    StatusCode = 200
                };
            }
            else
            {
                return new ObjectResult("Invalid data")
                {
                    StatusCode = 400
                };
            }

        }

        public async Task<ObjectResult> GetAllAsync()
        {
            var data = await _studentRepository.GetStudentsAsync();
            var students = _mapper.Map<List<GetStudentDto>>(data);
            if (data.Any())
            {
                return new ObjectResult(students)
                {
                    StatusCode = 200
                };
            }
            else
            {
                return new ObjectResult("Invalid data")
                {
                    StatusCode = 404
                };
            }

        }

        public async Task<ObjectResult> AddAsync(PostStudentDto student)
        {
            Student mainStudent = _mapper.Map<Student>(student);
            bool rowEffected = await _studentRepository.AddStudentAsync(mainStudent);

            if (rowEffected)
            {
                return new ObjectResult(student)
                {
                    StatusCode = 200
                };
            }
            else
            {
                return new ObjectResult("Invalid Operation")
                {
                    StatusCode = 400
                };
            }
        }

    }
}
