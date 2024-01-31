using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace SportsPro.Models
{
    public class Technicians
    {
        [Key]
        public int TechnicianId { get; set; }

        [Required(ErrorMessage = "Please enter a Name")]
        [StringLength(50, ErrorMessage = "Name must be 50 characters or less")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter an Email")]
        [StringLength(50, ErrorMessage = "Email must be 50 characters or less")]
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a Phone Number")]
        [StringLength(12, ErrorMessage = "Phone number must be 10 characters", MinimumLength = 0)]
        [Phone(ErrorMessage = "Please enter a valid phone number")]
        public string Phone { get; set; } = string.Empty;

        //Read-only property for the slug
        public string Slug => Name?.Replace(' ', '-').ToLower() + '-' + TechnicianId.ToString();
    }
}
