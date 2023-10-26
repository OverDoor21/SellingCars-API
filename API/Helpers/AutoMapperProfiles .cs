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
            //Automapping for all stuff connected to Lot
            CreateMap<Lot,UserlotDTO>();
            CreateMap<Car, UserlotDTO>();
            // CreateMap<Description,UserlotDTO>();
            // CreateMap<CategoryCar,UserlotDTO>();
            // CreateMap<Photo, UserlotDTO>();
        }
    }
}