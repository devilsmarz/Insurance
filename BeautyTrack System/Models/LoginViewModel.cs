using System.ComponentModel.DataAnnotations;

namespace BeautyTrack_System.Models
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(255, ErrorMessage = "Your email is too large")]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }

        [Required]
        [StringLength(255)]
        [DataType(DataType.Password)]
        public String Password { get; set; }
    }
}
