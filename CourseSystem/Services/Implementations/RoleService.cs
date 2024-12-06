using AutoMapper;
using CourseSystem.Dtos.Role;
using CourseSystem.Dtos.UserRoles;
using CourseSystem.Entities.AppDbContextEntity;
using CourseSystem.RepositoriesV2.Interfaces;
using CourseSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CourseSystem.Services.Implementations
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;
        public RoleService(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }
        public async Task<ObjectResult> AddAsync(PostRoleDto role)
        {
            Role mainRole = _mapper.Map<Role>(role);
            bool isEffected = await _roleRepository.AddRoleAsync(mainRole);
            if (isEffected)
            {
                return new ObjectResult(role)
                {
                    StatusCode = 200,
                };
            }
            else
            {
                return new ObjectResult("invalid data")
                {
                    StatusCode = 400
                };
            }
        }

        public async Task<ObjectResult> DeleteRoleAsync(int id)
        {
            bool isEffected = await _roleRepository.DeleteRoleAsync(id);
            if (isEffected)
            {
                return new ObjectResult("Deleted")
                {
                    StatusCode = 200,
                };
            }
            else
            {
                return new ObjectResult("invalid data")
                {
                    StatusCode = 400
                };
            }
        }

        public async Task<ObjectResult> GetAllAsync()
        {
            var roles = await _roleRepository.GetRolesAsync();
            var rolesDto = _mapper.Map<List<GetRoleDto>>(roles);

            if (roles.Any())
            {
                return new ObjectResult(rolesDto)
                {
                    StatusCode = 200,
                };
            }
            else
            {
                return new ObjectResult("Object wasn't find")
                {
                    StatusCode = 404
                };
            }
        }

        public async Task<ObjectResult> GetUserByRoleId(int roleId)
        {
            var data = await _roleRepository.GetUserByRoleId(roleId);
            var users = _mapper.Map<List<GetUserRoleDto>>(data);
            if (data.Any())
            {
                return new ObjectResult(users)
                {
                    StatusCode = 200
                };
            }
            else
            {
                return new ObjectResult("Data wasn't find")
                {
                    StatusCode = 404
                };
            }
        }

        public async Task<ObjectResult> UpdateRoleAsync(int id, UpdateRoleDto role)
        {
            Role mainRole = _mapper.Map<Role>(role);
            bool isEffected = await _roleRepository.UpdateRoleAsync(id, mainRole);
            if (isEffected)
            {
                return new ObjectResult(role)
                {
                    StatusCode = 200,
                };
            }
            else
            {
                return new ObjectResult("invalid data")
                {
                    StatusCode = 400
                };
            }
        }

    }
}
