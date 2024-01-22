using System.ComponentModel.DataAnnotations;

namespace CH2Labs.Models
{
    public class TipCalculationModel
    {
        [Required(ErrorMessage = "Please enter the cost of the meal")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a number greater than 0")]
        public decimal? MealCost { get; set; }

        public decimal? SmallTipPercentage { get; } = 0.15m;
        public decimal? MediumTipPercentage { get; } = 0.20m;
        public decimal? LargeTipPercentage { get; } = 0.25m;

        public decimal? SmallTipAmount { get; private set; }
        public decimal? MediumTipAmount { get; private set; }
        public decimal? LargeTipAmount { get; private set; }

        public void CalculateTipAmount()
        {
            if (MealCost.HasValue)
            {
                SmallTipAmount = MealCost.Value * SmallTipPercentage;
                MediumTipAmount = MealCost.Value * MediumTipPercentage;
                LargeTipAmount = MealCost.Value * LargeTipPercentage;
            }
            else
            {
                SmallTipAmount = MediumTipAmount = LargeTipAmount = 0;
            }
        }
    }
}
