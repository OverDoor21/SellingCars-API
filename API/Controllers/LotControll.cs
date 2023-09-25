using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class LotControll : BaseApiController
    {
        private readonly DataContext context;
        

        public LotControll(DataContext context){
            this.context = context;
        }

        [HttpGet("test")]

        public Task<string> test(){
            string hello = "hello world!";
            return Task.FromResult(hello);
        }


        // [HttpPost("CreateLot")]
        // public async Task<ActionResult<Lot>> Testing(CreateLotDto createLot){
        //     Lot lot = new(){
        //         NameLot = createLot.NameLot,
        //         LotId = createLot.LotId,
        //         UserId = createLot.UserId
        //     };
        //     context.Add(lot);
        //     context.SaveChanges();
        //     return  lot;
        // }


        [HttpPost("TestCreate")]
        public async Task<ActionResult<Lot>> CreateLot(CreateLotDto createLot){
    Lot lot = new()
    {
        NameLot = createLot.NameLot,
        LotId = IdExtension.GenerateUniqueIntId(),
        UserId = createLot.UserId
    };

    context.Add(lot);

    var car = new Car
    {
        CarId = IdExtension.GenerateUniqueIntId(),
        Mark = createLot.Mark,
        Year = createLot.Year,
        Color = createLot.Color,
        Price = createLot.Price,
        VoluemeofTank = createLot.VoluemeofTank,
        EnginePower = createLot.EnginePower,
        Mileage = createLot.Mileage,
        LotId = lot.LotId,
    };

    var category = new CategoryCar
    {
        Category = createLot.Category,
    };

    var description = new Description
    {
        LotId = lot.LotId,
        DescriptionText = createLot.Description
    };

    var region = new Region
    {
        RagionState = createLot.Region
    };

    var technicalCond = new TechnicalCondition
    {
        TechnicalCond = createLot.TechnicalCond
    };

    lot.Car = car;
    lot.CategoryCar = category;
    lot.Description = description;
    lot.Region = region;
    lot.TechnicalCondition = technicalCond;

    await context.SaveChangesAsync();

    return lot;
}

        
    }
    }


