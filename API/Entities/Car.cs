using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Car
    {
        public string Mark {get;set;}
        public int Year {get;set;}
        public int Price{get;set;}
        public double VoluemeofTank{get;set;}
        public string Color{get;set;}
        public string EnginePower{get;set;}
        public double Mileage{get;set;}

        public Lot Lot{get;set;}
    }
}