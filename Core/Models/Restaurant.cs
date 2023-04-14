using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [ForeignKey(nameof(ZipCode))]
        public int ZipCodeId { get; set; }
        public ZipCode? ZipCode { get; set; } 
     

        public string Address { get; set; } = string.Empty;
        public string StreetNr { get; set; } = string.Empty;

        public List<RestaurantTable> Tables { get; set; } = new List<RestaurantTable>();
        public List<Category> Categories { get; set; } = new List<Category>();
    }
}
