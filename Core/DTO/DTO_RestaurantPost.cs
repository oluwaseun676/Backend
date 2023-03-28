using Core.Models;
using Core.Models.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class DTO_RestaurantPost
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public ZipCode? ZipCode { get; set; }
        public string Address { get; set; } = string.Empty;
        public string StreetNr { get; set; } = string.Empty;

        public RestaurantCategory[]? Categories { get; set; }
        public DTO_OpeningTime[]? Openings { get; set; }

        public Employee? Employee { get; set; }
    }
}
