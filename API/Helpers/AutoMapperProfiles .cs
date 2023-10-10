using API.DTOs;
using API.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles ()
        {
            CreateMap<User, MemberDTO>();
            CreateMap<Photo, PhotoDTO>();
            CreateMap<Lot,UserlotDTO>();
            CreateMap<Car,UserlotDTO>();
            CreateMap<Description,UserlotDTO>();
        }
    }
}