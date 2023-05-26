using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class OpeningTimeDto
    {
        public int Day { get; set; }
        public string OpenFrom { get; set; } = string.Empty;
        public string OpenTo { get; set; } = string.Empty;
    }
}
