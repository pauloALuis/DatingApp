using System.ComponentModel.DataAnnotations;
namespace API.Entities
{
    public class AppUser
    {

     [Key]
     [Display (Name = "Nº User")]
     public int Id { get; set; }    
     [Required (ErrorMessage = "Campo mandatorio")]
     [Display (Name = "Name User", Description ="Name for your user")]
     [StringLength (15, MinimumLength=2)]
     public string UserName { get; set; }   

     
    }
}