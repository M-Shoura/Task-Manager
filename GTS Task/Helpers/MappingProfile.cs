using AutoMapper;
using GTS_Task.Data.Models;
using GTS_Task.DTOs;

namespace GTS_Task.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TodoTaskDTO, TodoTask>().ForMember(dest => dest.Id, opt => opt.Ignore()).ReverseMap();
            CreateMap<GetAllTasksDTO, TodoTask>().ReverseMap();
        }
    }
}
