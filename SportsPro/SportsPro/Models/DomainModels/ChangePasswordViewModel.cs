using System.ComponentModel.DataAnnotations;

namespace SportsPro.Models
{
    public class ChangePasswordViewModel
    {
        public string Username { get; set; } = null!;

        [Required(ErrorMessage = "Please enter your current password")]
        public string CurrentPassword { get; set; } = null!;

        [Required(ErrorMessage = "Please enter a new password")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword")]
        public string NewPassword { get; set; } = null!;

        [Required(ErrorMessage = "Please confirm your new password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm New Password")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
