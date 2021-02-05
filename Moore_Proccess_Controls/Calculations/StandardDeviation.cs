using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moore_Proccess_Controls.Core.Calculation
{
    public static class StandardDeviation
    {
        public static decimal Calculate(IEnumerable<decimal> v) => v.Sum() / v.Count();
    }
}
