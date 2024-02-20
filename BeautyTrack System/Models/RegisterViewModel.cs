using System.ComponentModel.DataAnnotations;

namespace BeautyTrack_System.API.Models
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(255, ErrorMessage = "Your email is too large")]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }

        [Required]
        [StringLength(255)]
        [DataType(DataType.Password)]
        public String Password { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Your phone is too large")]
        public String Phone { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "Your name is too large")]
        public String Name { get; set; }
    }
}
