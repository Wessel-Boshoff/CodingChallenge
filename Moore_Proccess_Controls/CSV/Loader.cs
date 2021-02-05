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

                tagFile.Lines.Add(new TagLine() { TS = DateTime.Parse(values.First(), CultureInfo.CurrentCulture), Tags = values.Skip(1).Select(c => decimal.Parse(c,CultureInfo.CurrentCulture))});
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
