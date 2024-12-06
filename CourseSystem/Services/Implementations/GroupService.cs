using AutoMapper;
using CourseSystem.Dtos.Group;
using CourseSystem.Entities.AppDbContextEntity;
using CourseSystem.RepositoriesV2.Interfaces;
using CourseSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CourseSystem.Services.Implementations
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;

        public GroupService(IGroupRepository groupRepository, IMapper mapper)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
        }

        public async Task<ObjectResult> AddGroupAsync(PostGroupDto group)
        {
            Group mainGroup = _mapper.Map<Group>(group);

            bool rowEffected = await _groupRepository.AddGroupAsync(mainGroup);
            if(rowEffected)
            {
                return new ObjectResult(group)
                {
                    StatusCode = 200
                };
            }
            else
            {
                return new ObjectResult("Can't add")
                {
                    StatusCode = 400
                };
            }

        }

        public async Task<ObjectResult> DeleteGroupAsync(int id)
        {
            if(id <= 0)
            {
                return new ObjectResult("invalid id")
                {
                    StatusCode = 400
                };
            }

            bool rowEffected = await _groupRepository.DeleteGroupAsync(id);
            if(rowEffected)
            {
                return new ObjectResult($"Deleted group which id is {id}")
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

        public async Task<ObjectResult> GetGroupByPaginate(int number, int size)
        {
            if(number <= 0 || size <= 0)
            {
                return new ObjectResult("Invalid parametr")
                {
                    StatusCode = 400
                };
            }

            var data = await _groupRepository.GetGroupByPaginate(number, size);
            var groups = _mapper.Map<List<GetGroupDto>>(data);

            if (data.Any())
            {
                return new ObjectResult(groups)
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

        public async Task<ObjectResult> GetGroupsAsync()
        {
            var data = await _groupRepository.GetGroupsAsync();
            var groups = _mapper.Map<List<GetGroupDto>>(data);
            if (data.Any())
            {
                return new ObjectResult(groups)
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

        public async Task<ObjectResult> UdpdateGroupAsync(int id, UpdateGroupdto group)
        {
            if (id <= 0)
            {
                return new ObjectResult("invalid id")
                {
                    StatusCode = 400
                };
            }

            Group mainGroup = _mapper.Map<Group>(group);
            bool rowEffected = await _groupRepository.UpdateGroupAsync(id, mainGroup);
            if(rowEffected)
            {
                return new ObjectResult(group)
                {
                    StatusCode = 200
                };
            }
            else
            {
                return new ObjectResult("Invalid operation")
                {
                    StatusCode = 400
                };
            }

        }
    }
}
