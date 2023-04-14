using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Core.Models.User
{
    public class Employee : Person
    {
        public bool IsAdmin { get; set; }

        [ForeignKey(nameof(RestaurantId))]
        [JsonIgnore]
        public Restaurant? Restaurant { get; set; }
        public int RestaurantId { get; set; }
    }
}
