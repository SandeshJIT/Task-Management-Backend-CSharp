using AutoMapper;
using Todo.API.Model;

namespace Todo.API.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            CreateMap<TaskRequest, TaskEntity>();
            CreateMap<TaskEntity, TaskResponse>();
        }
    }
}
