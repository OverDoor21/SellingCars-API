using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using API.Extensions;
using Microsoft.Extensions.Logging.Abstractions;

namespace API.Entities
{
    public class User
    {
        public int Id { get; set; }
        public int? Age { get; set; }

        public string UserName { get; set; }
        
        public byte[] PasswordHash {get;set;}
        public byte[] PasswordSalt {get;set;}

        public DateOnly DateofBirth {get;set;}
        public DateTime Created {get;set;} = DateTime.UtcNow;

        public DateTime LastActive {get;set; } = DateTime.UtcNow;

        public string City {get;set;}
        public string Country {get;set;} 
        public Photo Photo {get;set;}
        public List<Lot> Lots = new ();

        public int GetAge(){
            return DateofBirth.CalculateAge();
        }

    }
}   