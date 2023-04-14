using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public class RestaurantOpeningTime : EntityObject
    {
        //Montag: 0, Sontag: 6
        public int Day { get; set; }
        [DataType(DataType.Time)]
        public DateTime OpeningTime { get; set; }
        [DataType(DataType.Time)]
        public DateTime ClosingTime { get; set; }
        [ForeignKey(nameof(Restaurant))]
        public int RestaurantId { get; set; }
        public Restaurant? Restaurant { get; set; }
    }
}
