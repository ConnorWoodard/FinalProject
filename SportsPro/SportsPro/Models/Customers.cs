using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace SportsPro.Models
{
    public class Customers
    {
        [Key]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Please enter a First Name")]
        [StringLength(50, ErrorMessage = "First Name must be 50 characters or less")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a Last Name")]
        [StringLength(50, ErrorMessage = "Last Name must be 50 characters or less")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter an Address")]
        [StringLength(100, ErrorMessage = "Address must be 100 characters or less")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a City")]
        [StringLength(50, ErrorMessage = "City must be 50 characters or less")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a State")]
        [StringLength(50, ErrorMessage = "State must be 50 characters or less")]
        public string State { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a Country")]
        [Range(1, double.MaxValue, ErrorMessage = "Please select a country")]
        public int? CountryId { get; set; }

        [ValidateNever]
        public Country Country { get; set; } = null!; //Navigation property

        [Required(ErrorMessage = "Please enter a Postal Code")]
        [StringLength(50, ErrorMessage = "Postal Code must be at least 50 characters")]
        public string PostalCode { get; set; } = string.Empty;

        [ValidateNever]
        [StringLength(50, ErrorMessage = "Email must be 50 characters or less")]
        public string? Email { get; set; } = null!;

        [ValidateNever]
        [StringLength(12, ErrorMessage = "Phone number must be 10 characters", MinimumLength = 0)]
        public string? Phone { get; set; } = null!;

        //Read-only property for the slug
        public string? Slug => FirstName?.Replace(' ', '-').ToLower() + '_' + LastName?.Replace(' ', '-').ToLower();     
    }
}
