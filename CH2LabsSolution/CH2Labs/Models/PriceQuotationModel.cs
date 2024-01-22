using System.ComponentModel.DataAnnotations;

namespace CH2Labs.Models
{
    public class PriceQuotationModel
    {
        [Required(ErrorMessage = "Please enter the SubTotal")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a number greater than 0")]
        public decimal? SubTotal { get; set; }

        [Required(ErrorMessage = "Please enter the Discount Percentage")]
        [Range(0, 100, ErrorMessage = "Please enter a number between 0 and 100")]
        public decimal? DiscountPercentage { get; set; }

        public decimal? DiscountAmount { get; private set; }
        public decimal? Total { get; private set; }

        public void CalculateTotal()
        {
            if (SubTotal.HasValue && DiscountPercentage.HasValue)
            {
                DiscountAmount = SubTotal.Value * (DiscountPercentage.Value / 100);
                Total = SubTotal.Value - DiscountAmount;
            }
            else
            {
                DiscountAmount = Total = 0;
            }
        }
    }
}
