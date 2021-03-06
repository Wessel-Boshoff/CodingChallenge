﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moore_Proccess_Controls.Core.Models
{
    public class CalculationResult
    {
        public int Id { get; set; } = 0;
        public StaticItem Tag { get; set; } = new StaticItem();
        public StaticItem CalculationType { get; set; } = new StaticItem();
        public List<decimal> Value { get; set; } = new List<decimal>();
        public DateTime Date { get; set; } = new DateTime();
    }
}
