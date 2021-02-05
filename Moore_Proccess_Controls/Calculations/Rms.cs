using System;
using System.Collections.Generic;
using System.Linq;

namespace Moore_Proccess_Controls.Core.Calculation
{
    public static class Rms
    {
        /// <summary>
        /// TODO find out how to calculate this
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static decimal Calculate(IEnumerable<decimal> v)
        {
            IEnumerable<double> valuesSqr = v.Select(c => Math.Sqrt((double)c));
            double result = valuesSqr.Sum() / valuesSqr.Count();
            return double.IsNaN(result) ? default : (decimal)result;
        }
    }
}
