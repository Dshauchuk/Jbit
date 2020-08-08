using AutoMapper;
using Jbit.API.Models.ViewModels;
using Jbit.Common.Models;

namespace Jbit.API.AutoMapper
{
    public class TaskValueProfile : Profile
    {
        public TaskValueProfile()
        {
            CreateMap<TaskValue, TaskValueModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value));
        }
    }
}
