using Assignment_8.DTOs;
using Assignment_8.Models;
using AutoMapper;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Assignment_8.Mapping
{
    public class TaskMappingProfile : Profile
    {
        public TaskMappingProfile()
        {
            CreateMap<CreateTaskRequest, TaskItem>();

            CreateMap<UpdateTaskRequest, TaskItem>();

            CreateMap<TaskItem, TaskResponseDto>();
        }
    }
}
