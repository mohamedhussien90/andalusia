using AutoMapper;
using DataBaseTesting.Models;
using DataBaseTestingV2.DTOs;

namespace DataBaseTestingV2.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TaskItem, TaskItemDto>();

            CreateMap<CreateTaskRequest, TaskItem>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<UpdateTaskRequest, TaskItem>();
        }
    }
}
