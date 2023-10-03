using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class CategoryCar
    {
       [Key]
        public int Id {get;set;}
        public string Category {get;set;}

       public List<Lot> Lots { get; set; } = new List<Lot>(); 
       

    }
}