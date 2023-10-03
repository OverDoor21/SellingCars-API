using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class CreateLotDto
    {
        public string NameLot {get;set;}
        public string CurrentUser{get;set;}
        public string User{get;set;}
        public string Mark   {get;set;}
        public int Year {get;set;}
        public int Price{get;set;}
        public int VoluemeofTank{get;set;}
        public string Color{get;set;}
        public string EnginePower{get;set;}
        public int Mileage{get;set;}
        public string Category {get;set;}
        public string Description {get;set;}
        public string Region {get;set;}
        public string TechnicalCond {get;set;}
    }
}