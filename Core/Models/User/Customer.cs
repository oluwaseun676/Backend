using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models.User
{
    [Index(nameof(CustomerNumber), IsUnique = true)]
    public class Customer : Person
    {     
        public string CustomerNumber { get; set; } = string.Empty;

    }
}
