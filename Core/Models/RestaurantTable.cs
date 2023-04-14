using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Core.Models
{
    public class RestaurantTable : EntityObject
    {
        [Range(1, int.MaxValue)]
        public int SeatPlaces { get; set; }
        [ForeignKey(nameof(Restaurant))]
        public int RestaurantId { get; set; }
        [JsonIgnore]
        public Restaurant? Restaurant { get; set; }
    }
}
