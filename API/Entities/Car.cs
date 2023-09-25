using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Car
    {
        public int CarId {get;set;}
        public string Mark {get;set;}
        public int Year {get;set;}
        public int Price{get;set;}
        public int VoluemeofTank{get;set;}
        public string Color{get;set;}
        public string EnginePower{get;set;}
        public int Mileage{get;set;}

        public Lot Lot{get;set;}
        public int LotId { get;set; }
    }
}