using Moore_Proccess_Controls.Core.Values;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Moore_Proccess_Controls.Data.CSV
{
    public static class Saving
    {
        public static bool Save(List<string> headers, List<List<string>> data)
        {
            List<string> dataString = new List<string>
            {
                Concat(headers)
            };
            dataString.AddRange(data.Select(c => Concat(c)));
            string dir = AppDomain.CurrentDomain.BaseDirectory;
            string path = Path.Combine(dir, string.Format("{0}.csv", DateTime.Now.Ticks));
            File.WriteAllLines(path, dataString);
            return true;
        }

        private static string Concat(List<string> values) => values == default ? string.Empty: string.Join(CONSTS.Separator.ToString(), values);
        
    }
}
