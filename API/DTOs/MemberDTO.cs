using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class MemberDTO
    {
        public int Id { get; set; }
        public int? Age { get; set; }

        public string UserName { get; set; }

        public DateTime Created {get;set;} = DateTime.UtcNow;

        public DateTime LastActive {get;set; } = DateTime.UtcNow;

        public string City {get;set;}
        public string Country {get;set;} 
        public PhotoDTO Photo {get;set;}

    }
}