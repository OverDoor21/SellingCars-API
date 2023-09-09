using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Photos")]
    public class Photo
    {
        public int PhotoId {get;set;}
        public string Url{get;set;}

        public bool IsMain{get;set;}
        public string PublicId {get;set;}

        public int? UserId{get;set;}
        public int? LotId{get;set;}
        public User User {get;set;}
        public Lot Lot {get;set;}

    }
}