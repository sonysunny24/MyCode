using aspnetcore_n_tier.DTO.DTOs;
using aspnetcore_n_tier.Entity.Entities;
using AutoMapper;

namespace aspnetcore_n_tier.Utility.Utilities
{
    public static class AutoMapperProfiles
    {
        public class AutoMapperProfile : Profile
        {
            public AutoMapperProfile()
            {
                CreateMap<User, UserDTO>().ReverseMap();
                CreateMap<User, UserToAddDTO>().ReverseMap();
            }
        }
    }
}
