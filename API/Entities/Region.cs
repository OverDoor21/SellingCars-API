using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Region
    {
        public int Id {get;set;}

        public string RagionState{get;set;}

        public List<Lot> Lots = new();
    }
}