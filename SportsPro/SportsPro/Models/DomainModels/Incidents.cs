using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using SportsPro.Models.DomainModels;
using System.ComponentModel.DataAnnotations;

namespace SportsPro.Models.DomainModels
{
    public class Incidents
    {
        [Key]
        public int IncidentId { get; set; }

        [Required(ErrorMessage = "Please select a Customer")]
        [Range(1, double.MaxValue, ErrorMessage = "Please select a customer")]
        public int? CustomerId { get; set; }

        [ValidateNever]
        public Customers Customer { get; set; } = null!; //Navigation property

        [Required(ErrorMessage = "Please select a Product")]
        [Range(1, double.MaxValue, ErrorMessage = "Please select a product")]
        public int? ProductId { get; set; }

        [ValidateNever]
        public Products Product { get; set; } = null!; //Navigation property

        [Required(ErrorMessage = "Please enter a Title")]
        [StringLength(50, ErrorMessage = "Title must be 50 characters or less")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "Please enter a Description")]
        [StringLength(500, ErrorMessage = "Description must be 500 characters or less")]
        public string Description { get; set; } = null!;

        public int TechnicianId { get; set; } = -1;

        [ValidateNever]
        public Technicians Technician { get; set; } = null!; //Navigation property

        [DataType(DataType.DateTime)]
        public DateTime DateOpened { get; set; } = DateTime.Now;

        [DataType(DataType.DateTime)]
        public DateTime? DateClosed { get; set; }

        //Read-only property for the slug
        public string? Slug => Title?.Replace(' ', '-').ToLower();
    }
}
