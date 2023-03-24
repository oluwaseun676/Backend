using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models.User
{
    public class Employee : Person
    {
        public bool IsAdmin { get; set; }

        [ForeignKey(nameof(RestaurantId))]
        public Restaurant? Restaurant { get; set; }
        public int RestaurantId { get; set; }
    }
}
