using AutoMapper;
using Jbit.API.Models.ViewModels;
using Jbit.Common.Models;

namespace Jbit.API.AutoMapper
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<JbitTask, TaskViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.AssignedTo, opt => opt.MapFrom(src => src.AssignedTo))
                .ForMember(dest => dest.AssignedPersonFirstName, opt => opt.MapFrom(src => src.Person.FirstName))
                .ForMember(dest => dest.AssignedPersonLastName, opt => opt.MapFrom(src => src.Person.LastName))
                .ForMember(dest => dest.Link, opt => opt.MapFrom(src => src.Link))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.CompetitionId, opt => opt.MapFrom(src => src.CompetitionId))
                .ForMember(dest => dest.CompetitionId, opt => opt.MapFrom(src => src.Competition.Name))
                .ForMember(dest => dest.Values, opt => opt.MapFrom(src => src.Values));
        }
    }
}
