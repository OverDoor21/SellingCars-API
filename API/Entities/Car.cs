using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Entities
{
    public class Car
    {   
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get;set;}
        public string Mark {get;set;}
        public int Year {get;set;}
        public int Price{get;set;}
        public int VoluemeofTank{get;set;}
        public string Color{get;set;}
        public string EnginePower{get;set;}
        public int Mileage{get;set;}

        [JsonIgnore]   
        public Lot Lot{get;set;}
        public int LotId { get;set; }
    }
}