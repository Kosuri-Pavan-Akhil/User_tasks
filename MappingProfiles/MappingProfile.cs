using AutoMapper;
using Tasks.Dtos.Task;
using Tasks.Dtos.User;
using Tasks.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Tasks.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // User mappings
            CreateMap<User, UserReadDto>();
            CreateMap<RegisterDto, User>();

            // Task mappings
            CreateMap<TaskItem, TaskReadDto>();
            CreateMap<TaskCreateDto, TaskItem>();
            CreateMap<TaskUpdateDto, TaskItem>();
        }
    }
}
