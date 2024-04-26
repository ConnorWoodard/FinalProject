using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace SportsPro.Models.DomainModels
{
    public class Technicians
    {
        [Key]
        public int TechnicianId { get; set; }

        [Required(ErrorMessage = "Please enter a Name")]
        [StringLength(50, ErrorMessage = "Name must be 50 characters or less")]
        public string Name { get; set; } = null!;

        [ValidateNever]
        public string? Email { get; set; } = null!;

        [ValidateNever]
        [StringLength(12, ErrorMessage = "Phone number must be 10 characters", MinimumLength = 0)]
        public string? Phone { get; set; } = string.Empty;

        // Read-only property for the slug
        public string? Slug => Name?.Replace(' ', '-').ToLower();
    }
}
