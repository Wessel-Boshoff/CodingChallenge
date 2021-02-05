using System;
using System.Collections.Generic;

namespace Moore_Proccess_Controls.Core.Models
{
    public class TagLine
    {
        public DateTime TS { get; set; } = new DateTime();
        public IEnumerable<decimal> Tags { get; set; } = new List<decimal>();
    }
}
