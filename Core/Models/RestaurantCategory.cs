using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class RestaurantCategory
    {
        [Key]
        public string Category { get; set; } = string.Empty;
    }
}
