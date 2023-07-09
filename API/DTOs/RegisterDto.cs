using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class RegisterDto
    {
        [Required]
        [StringLength(15, MinimumLength = 2)]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Campo mandatorio")]
        [StringLength(12, MinimumLength = 2)]
        public string Password { get; set; }

    }
}