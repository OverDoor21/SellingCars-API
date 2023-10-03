using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class Lot
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id{get;set;}
        public string NameLot{get;set;}
        public int UserId{get;set;}
        public int CategoryId{get;set;}

        public int RegionId{get;set;}
       
        public int TechnicalConditionId{get;set;}
        public int CarId{get;set;}
        public int DescriptionId{get;set;}


        public Car Car{get;set;}
        public CategoryCar CategoryCar {get;set;}

        public List<Photo> Photos {get;set;} = new List<Photo>();
        public User User {get;set;}
        public Region Region {get;set;}

        public TechnicalCondition TechnicalCondition {get;set;}
        public Description Description {get;set;}
        
    }
}