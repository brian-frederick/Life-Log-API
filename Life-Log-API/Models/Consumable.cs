using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Life_Log_API.Models
{
    public class Consumable
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public int ImmediateRating { get; set; }
        public int PostRating { get; set; }
    }
}
