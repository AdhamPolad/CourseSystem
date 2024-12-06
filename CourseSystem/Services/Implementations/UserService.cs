using AutoMapper;
using CourseSystem.Dtos.Student;
using CourseSystem.Dtos.User;
using CourseSystem.Dtos.UserRoles;
using CourseSystem.Entities.AppDbContextEntity;
using CourseSystem.RepositoriesV2.Interfaces;
using CourseSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CourseSystem.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        public UserService(IUserRepository userRepository, IMapper mapper, IFileService fileService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _fileService = fileService;
        }
        public async Task<ObjectResult> AddAsync(PostUserAndUserRoleDto postUserAndUserRole)
        {
            PostUserDto postUserDto = postUserAndUserRole.User;
            User user = _mapper.Map<User>(postUserDto);
            PostUserRoleDto postUserRole = postUserAndUserRole.UserRole;
            UserRole userRole = _mapper.Map<UserRole>(postUserRole);

            bool isEffected = await _userRepository.AddUserAsync(user, userRole);
            if (isEffected)
            {
                return new ObjectResult(postUserRole)
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


        public async Task<ObjectResult> AddUserAndFile(IFormFile formFile, PostUserDto postUserDto)
        {
            User user = _mapper.Map<User>(postUserDto);
            await _userRepository.AddUserAndFile(user);
            await _fileService.Upload(formFile, user.Id);

            return new ObjectResult(postUserDto)
            {
                StatusCode = 200
            };

        }

        public async Task<ObjectResult> DeleteAsync(int id)
        {
            if (id <= 0)
            {
                return new ObjectResult("Invalid id")
                {
                    StatusCode = 404
                };
            }
            bool isEffected = await _userRepository.DeleteUserAsync(id);
            if (isEffected)
            {
                return new ObjectResult("Deleted")
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
            var data = await _userRepository.GetUsersAsync();
            var users = _mapper.Map<List<GetUserDto>>(data);
            
            if (data.Any())
            {
                return new ObjectResult(users)
                {
                    StatusCode = 200
                };
            }
            else
            {
                return new ObjectResult("Object doesnt find")
                {
                    StatusCode = 404
                };
            }

        }


        public async Task<ObjectResult> UpdateUserAsync(int id, UpdateUserDto user)
        {
            if (id <= 0)
            {
                return new ObjectResult("Invalid id")
                {
                    StatusCode = 404
                };
            }

            User mainUser = _mapper.Map<User>(user);
            bool isEffected = await _userRepository.UpdateUserAsync(id, mainUser);
            if (isEffected)
            {
                return new ObjectResult(user)
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
    }
}
