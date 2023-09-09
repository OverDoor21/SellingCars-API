using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Description
    {
        public int Id{get;set;}
        public string DescriptionText{get;set;}

        public Lot Lot {get;set;}
    }
}