using System.ComponentModel.DataAnnotations;

namespace BloodStorage.Models
{
    public class Doctor
    {

        [Key]
        public int DocId { get; set; }

        // [Required(ErrorMessage = "Description is required")]
        public string Name { get; set; } = string.Empty;
        // [Required(ErrorMessage = "Status is required")]
      

        // [Required(ErrorMessage = "Description is required")]
        [MaxLength(64, ErrorMessage = "Length of description cannot be greater than 64 characters")]
        [MinLength(5, ErrorMessage = "Length of description cannot be less than 2 characters")]
        public string? GPAddress { get; set; }
    }
}
