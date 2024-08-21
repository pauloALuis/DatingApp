using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class LoginDto
    {
        [Required]
        [StringLength(15, MinimumLength = 2)]
        public string Username { get; set; }
        [StringLength(12, MinimumLength = 4)]
        public string Password { get; set; }
    }
}