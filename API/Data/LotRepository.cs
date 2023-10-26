using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class LotRepository : ILotRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;


        public LotRepository(DataContext context, IMapper mapper){
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<Lot>> GetLotsAsync(){
            return await context.Lots
            .Include(c => c.Car)
            .Include(k => k.CategoryCar)
            .Include(r => r.Region)
            .Include(t => t.TechnicalCondition)
            .Include(d => d.Description)
            .ToListAsync();
        }

        public async Task<Lot> GetLotByLotnameAsync(string Lotname){
            return await context.Lots
            .Include(c => c.Car)
            .Include(d => d.Description)
            .SingleOrDefaultAsync(l => l.NameLot == Lotname);
        }

        public async Task<IEnumerable<UserlotDTO>> GetUsersLotsAscync(){
            return await context.Lots
            .ProjectTo<UserlotDTO>(mapper.ConfigurationProvider)
            .ToListAsync();
        }
        public async Task<UserlotDTO> GetUserslotbyNameAscync(string NameLot)
        {
            return await context.Lots
            .ProjectTo<UserlotDTO>(mapper.ConfigurationProvider)
            .SingleOrDefaultAsync(l => l.NameLot == NameLot);
            
        }
    }
}