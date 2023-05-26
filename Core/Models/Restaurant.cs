using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Core.Models
{
    public class Restaurant : EntityObject
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [ForeignKey(nameof(ZipCode))]
        public int ZipCodeId { get; set; }
        [JsonIgnore]
        public ZipCode? ZipCode { get; set; }
     

        public string Address { get; set; } = string.Empty;
        public string StreetNr { get; set; } = string.Empty;

        [JsonIgnore]
        public List<RestaurantTable> Tables { get; set; } = new List<RestaurantTable>();
        [JsonIgnore]
        public List<Category> Categories { get; set; } = new List<Category>();
    }
}
