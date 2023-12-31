using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class RegisterDTO
    {
        [Required]
        public string UserName{get;set;}

        [Required]
        [StringLength(12, MinimumLength = 6)]
        public string Password{get;set;}
    }
}