using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class AppMovie
    {
        [Key]
        [DisplayName("Nº User")]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        [Required]
        [StringLength(5)]
        public string Director { get; set; }

        [DisplayName("Date Released")]
        [Required]
        public int DateReleased { get; set; }
    }
}