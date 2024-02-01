using System.ComponentModel.DataAnnotations;

namespace SportsPro.Models
{
    public class Country
    {
        //Primary Key
        [Key]
        public int? CountryId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
