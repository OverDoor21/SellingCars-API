using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Extensions;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class LotControll : BaseApiController
    {
        private readonly DataContext context;
        private readonly ILotRepository lotrep;    
        public readonly IMapper Mapper; 

        public LotControll(DataContext context, ILotRepository lotrep, IMapper mapper){
            this.Mapper = mapper;
            this.lotrep = lotrep;
            this.context = context;
        }

        [HttpGet("regions")]
        public async Task<ActionResult<Region>> GetRegions(){
            var regions = await context.Regions.ToListAsync();
            return Ok(regions);
        }

        [HttpGet("technicalcond")]
        public async Task<ActionResult<Region>> GetTechnicalCond(){
            var technicalcond = await context.TechnicalConditions.ToListAsync();
            return Ok(technicalcond);
        }

         [HttpGet("categories")]
        public async Task<ActionResult<Region>> GetCategories(){
            var categ = await context.Categories.ToListAsync();
            return Ok(categ);
        }

        [HttpGet("Lots")]
        public async Task<ActionResult<IEnumerable<Lot>>> GetLots(){
            var lots = await lotrep.GetLotsAsync();
            var lotstoReturn = Mapper.Map<IEnumerable<UserlotDTO>>(lots);
            return Ok(lotstoReturn);
        }


        [HttpPost("createlot")]
        public async Task<ActionResult<Lot>> CreateLot(CreateLotDto createLot){
        var categoryid = await context.Categories.FirstAsync(c => c.Category == createLot.Category);
        var regionId = await context.Regions.FirstAsync(r => r.RagionState == createLot.Region);
        var techcond = await context.TechnicalConditions.FirstAsync(r => r.TechnicalCond == createLot.TechnicalCond);
        var currentuser = await context.Users.FirstAsync(a => a.UserName == createLot.CurrentUser);

    var car = new Car
    {
        Mark = createLot.Mark,
        Year = createLot.Year,
        Color = createLot.Color,
        Price = createLot.Price,
        VoluemeofTank = createLot.VoluemeofTank,
        EnginePower = createLot.EnginePower,
        Mileage = createLot.Mileage, 
    };
    await context.Cars.AddAsync(car);
    await context.SaveChangesAsync();

    var description = new Description
    {
        DescriptionText = createLot.Description
    };
    await context.Descriptions.AddAsync(description);
    await context.SaveChangesAsync();

    Lot lot = new()
    {
        NameLot = createLot.NameLot,
        UserId = currentuser.Id,
        CarId = car.Id,
        CategoryId = categoryid.Id,
        RegionId = regionId.Id,
        TechnicalConditionId = techcond.Id,
        DescriptionId = description.Id
    };

    await context.AddAsync(lot);
    await context.SaveChangesAsync();

    return Ok();
}

        
    }
    }


