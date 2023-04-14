using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Category : EntityObject
    {
        public string Name { get; set; } = string.Empty;

        public List<Restaurant> Restaurants { get; set; } = new List<Restaurant>();
    }
}
