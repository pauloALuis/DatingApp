using System.ComponentModel.DataAnnotations;
namespace API.Entities
{
    public class AppUser
    {
        private const string mandatoryMessage = "Mandatory field";

        [Key]
        [Display(Name = "Nº User")]
        public int Id { get; set; }
        [Required(ErrorMessage = mandatoryMessage)]
        [Display(Name = "User Name", Description = "Name for your user")]
        [StringLength(15, MinimumLength = 2)]
        public string UserName { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = mandatoryMessage)]
        public byte[] PasswordHash { get; set; }
        [Required(ErrorMessage = mandatoryMessage)]
        public required byte[] PasswordSalt { get; set; }

    }
}