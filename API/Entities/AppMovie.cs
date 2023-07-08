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

        [StringLength(50)]
        public string Director { get; set; }

        [DisplayName("Date Released")]
        [Required]
        public string DateReleased { get; set; }
    }
}