using System;
using System.Globalization;
using System.IO;
using System.Linq;
using Moore_Proccess_Controls.Core.Models;
using Moore_Proccess_Controls.Core.Values;

namespace Moore_Proccess_Controls.Data.CSV
{
    public static class Loader
    {
        /// <summary>
        /// Loads the tag CSV file
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static TagFile LoadFile(string path)
        {
            TagFile tagFile = new TagFile();
            bool first = true;
            var lines = File.ReadAllLines(path);
            foreach (var line in lines)
            {

                //Handle headers
                if (first)
                {
                    tagFile.Headers.AddRange(Split(line));
                    first = false;
                    continue;
                }


                //Handle data
                var values = Split(line);
                if (!values.Any())
                {
                    continue;
                }

                if (!DateTime.TryParse(values.First(), out DateTime ts))
                {
                    continue;
                }

                var dataToParse = values.Skip(1);
                List<decimal> dataParsed = new List<decimal>();
                foreach (var lineItem in dataToParse)
                {
                    try
                    {
                        decimal value = Convert.ToDecimal(lineItem, CultureInfo.InvariantCulture);
                        dataParsed.Add(value);
                    }
                    catch (Exception ex)
                    {
                    }


                }

                tagFile.Lines.Add(new TagLine() { TS = ts, Tags = dataParsed});

            }

            return tagFile;
        }

        /// <summary>
        /// Wrapper to handle separators in CSV file
        /// </summary>
        /// <param name="valueString"></param>
        /// <returns></returns>
        private static string[] Split(string valueString) => string.IsNullOrEmpty(valueString) ? new string[0] : valueString.Split(CONSTS.Separator);
    }
}
