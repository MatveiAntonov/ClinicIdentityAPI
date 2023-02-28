using AutoMapper;
using IdentityServer.Server.Entities;
using IdentityServer.Server.Entities.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Server
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegistrationModel, User>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));
        }
    }

}
