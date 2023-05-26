using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class RestaurantViewDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public ZipCode? ZipCode { get; set; }
        public string Address { get; set; } = string.Empty;
        public string StreetNr { get; set; } = string.Empty;

        public Category[]? Categories { get; set; }
        public OpeningTimeDto[]? Openings { get; set; }
    }
}
