using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moore_Proccess_Controls.Core.Calculation
{
    public static class SpecificRateOfChange
    {
        /// <summary>
        /// TODO find out how to calculate this
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static List<decimal> Calculate(List<Tuple<DateTime, decimal>> rows)
        {
            List<decimal> values = new List<decimal>();

            for (int i = 0; i < rows.Count; i++)
            {
                if (i == 0)
                {
                    values.Add(0);
                    continue;
                }

                TimeSpan ts = rows[i].Item1 - rows[i - 1].Item1;
                var diff = rows[i].Item2 - rows[i - 1].Item2;

                values.Add((decimal)((double)diff / ts.TotalMilliseconds));
            }

            return values;
        }
    }
}
