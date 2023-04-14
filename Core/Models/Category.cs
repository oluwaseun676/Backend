using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Category : EntityObject
    {
        public string Name { get; set; } = string.Empty;

        [JsonIgnore]
        public List<Restaurant> Restaurants { get; set; } = new List<Restaurant>();
    }
}
