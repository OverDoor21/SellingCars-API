using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class TechnicalCondition
    {
        public int Id {get;set;}

        public string TechnicalCond {get;set;}
        public List<Lot> Lots = new List<Lot>();
    }
}