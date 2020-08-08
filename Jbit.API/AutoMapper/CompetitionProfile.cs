using AutoMapper;
using Jbit.API.Models.ViewModels;
using Jbit.Common.Models;
using System.Linq;

namespace Jbit.API.AutoMapper
{
    public class CompetitionProfile : Profile
    {
        public CompetitionProfile()
        {
            CreateMap<Competition, CompetitionViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.ExpressionId, opt => opt.MapFrom(src => src.ExpressionId))
                .ForMember(dest => dest.ExpresionName, opt => opt.MapFrom(src => src.Expression.Name))
                .ForMember(dest => dest.ExpressionDescription, opt => opt.MapFrom(src => src.Expression.Description))
                .ForMember(dest => dest.Persons, opt => opt.MapFrom(src => src.PersonLinks.Select(l => l.Person)));

            CreateMap<Competition, ExtendedCompetitionViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.ExpressionId, opt => opt.MapFrom(src => src.ExpressionId))
                .ForMember(dest => dest.ExpresionName, opt => opt.MapFrom(src => src.Expression.Name))
                .ForMember(dest => dest.ExpressionDescription, opt => opt.MapFrom(src => src.Expression.Description))
                .ForMember(dest => dest.Persons, opt => opt.MapFrom(src => src.PersonLinks.Select(l => l.Person)));
        }
    }
}
