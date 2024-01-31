using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace SportsPro.Models
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Please enter a Product Code")]
        [StringLength(10)]
        public string ProductCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a Product Name")]
        [StringLength(50, ErrorMessage = "Product Name must be 50 characters or less")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a Yearly Price")]
        [Range(0.01, 9999999999999999.99, ErrorMessage = "Yearly Price must be greater than 0")]
        public decimal? YearlyPrice { get; set; } = 0.00M;

        //The release date is a prefilled box that reads the current date and time, and is not required to be filled out by the user
        [DataType(DataType.DateTime)]
        public DateTime ReleaseDate { get; set; } = DateTime.Now;

        //Read-only property for the slug
        public string Slug => Name?.Replace(' ', '-').ToLower() + '-' + ProductId.ToString();
    }
}
