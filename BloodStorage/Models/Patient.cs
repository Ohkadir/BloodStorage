using System.ComponentModel.DataAnnotations;

namespace BloodStorage.Models
{
    public class Patient
    {

        [Key]
        public int NHSId { get; set; }

        //[Forgein "{NHSId}"]
        public int DocId { get; set; }

        // [Required(ErrorMessage = "Description is required")]
        public String Name { get; set; } = string.Empty;
       // [Required(ErrorMessage = "Status is required")]
        public string? Age { get; set; }

        // [Required(ErrorMessage = "Description is required")]
        [MaxLength(10, ErrorMessage = "Length of description cannot be greater than 10 characters")]
        [MinLength(1, ErrorMessage = "Length of description cannot be less than 1 characters")]
        public string? PostCode { get; set; }

        [MaxLength(64, ErrorMessage = "Length of description cannot be greater than 64 characters")]
        [MinLength(2, ErrorMessage = "Length of description cannot be less than 2 characters")]
        public string? Address { get; set; }


    }
}
