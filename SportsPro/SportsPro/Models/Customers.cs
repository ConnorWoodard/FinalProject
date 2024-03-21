using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace SportsPro.Models
{
    public class Customers
    {
        [Key]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Please enter a First Name")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "First Name must be 50 characters or less")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a Last Name")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Last Name must be 50 characters or less")]
        public string LastName { get; set; } = string.Empty;
        [Display(Name = "Full Name")]

        public string FullName => $"{FirstName} {LastName}";

        [Required(ErrorMessage = "Please enter an Address")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Address must be 100 characters or less")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a City")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "City must be 50 characters or less")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a State")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "State must be between 1 and 50 characters")]
        public string State { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a Country")]
        [Range(1, double.MaxValue, ErrorMessage = "Please select a country")]
        [Remote(action: "ValidateCountry", controller: "Validation")]
        public int CountryId { get; set; }

        [ValidateNever]
        public Country Country { get; set; } = null!; //Navigation property

        [Required(ErrorMessage = "Please enter a Postal Code")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Postal Code must be between 1 and 20 characters")]
        public string PostalCode { get; set; } = string.Empty;

        [ValidateNever]
        [DataType(DataType.EmailAddress)]
        [Remote(action: "VerifyEmail", controller: "Validation", AdditionalFields = nameof(CustomerId))]
        [StringLength(50, ErrorMessage = "Email must be 50 characters or less")]
        public string? Email { get; set; } = null!;

        [ValidateNever]
        //regular expression it must have at least 1 and less than 21 characters and be in the “(999) 999-9999” format.
        [RegularExpression(@"^\(?\d{3}\)?-? *\d{3}-? *-?\d{4}$", ErrorMessage = "Phone number must be in the format (999) 999-9999")]
        [StringLength(13, ErrorMessage = "Phone number must be 10 characters", MinimumLength = 0)]
        public string? Phone { get; set; } = null!;

        //Read-only property for the slug
        public string? Slug => FirstName?.Replace(' ', '-').ToLower() + '_' + LastName?.Replace(' ', '-').ToLower();     
    }
}
