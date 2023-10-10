using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.DTOs
{
    public class UserlotDTO
    {
        public string NameLot {get;set;}
        public string Sellet{get;set;}
        public string Mark {get;set;}
        public int Year { get; set; }
        public int Price{get;set;}
        public int VoluemeofTank{get;set;}
        public string Color{get;set;}
        public string EnginePower{get;set;}
        public int Mileage{get;set;}
        public string TechnicalCond {get;set;}
        public string DescriptionText{get;set;}
        public string Category {get;set;}
        public string RagionState{get;set;}
        public Photo photo{get;set;}
        
        

    }
}