using AutoMapper;
using Jbit.API.Models.ViewModels;
using Jbit.Common.Models;

namespace Jbit.API.AutoMapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.RegistrationTimestamp, opt => opt.MapFrom(src => src.RegistrationTimestamp));
        }

    }
}
