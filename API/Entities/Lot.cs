using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Lot
    {
        public int LotId{get;set;}
        public string NameLot{get;set;}
        public int UserId{get;set;}
        public Car Car{get;set;}
        public CategoryCar CategoryCar {get;set;}
        public Description Description {get;set;}
        public List<Photo> Photos {get;set;} = new List<Photo>();
        public User User {get;set;}
        public Region Region {get;set;}

        public TechnicalCondition TechnicalCondition {get;set;}

        
    }
}