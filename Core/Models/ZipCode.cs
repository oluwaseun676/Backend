using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public class ZipCode : EntityObject
    { 
        [Required]
        public string ZipCodeNr { get; set; } = string.Empty;

        [Required]
        public string Location { get; set; } = string.Empty;

        [Required]
        public string District { get; set; } = string.Empty; 
    }
}
