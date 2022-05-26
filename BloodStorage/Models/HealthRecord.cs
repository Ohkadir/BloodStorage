using System.ComponentModel.DataAnnotations;

namespace BloodStorage.Models
{
    public class HealthRecord
    {


        [Key]
        public int Id { get; set; }

        public int NHSId { get; set; }

        // [Required(ErrorMessage = "Description is required")]
        public String BloodType { get; set; } = String.Empty;
        // [Required(ErrorMessage = "Status is required")]


        // [Required(ErrorMessage = "Description is required")]
        [MaxLength(64, ErrorMessage = "Length of description cannot be greater than 64 characters")]
        [MinLength(1, ErrorMessage = "Length of description cannot be less than 1 characters")]
        public string? LastVaccinated { get; set; }

    }
}
