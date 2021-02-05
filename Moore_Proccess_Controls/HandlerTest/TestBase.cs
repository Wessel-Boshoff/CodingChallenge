using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moore_Proccess_Controls.Test.InternalTesting
{
    public class TestBase
    {
        public string CSVPath { get; set; } = @"C:\Users\Wessel\Desktop\TestFile\TestFile.csv";

        public Core.Models.CalculationResult CalculationResult { get; set; }
        public Core.Models.StaticItem CalculationType { get; set; } = new Core.Models.StaticItem()
        {
            Id = 1,
            Value = "Standard Deviation"
        };
        public Core.Models.StaticItem Tag { get; set; } = new Core.Models.StaticItem()
        {
            Id = 1,
            Value = "TAG1"
        };
        public TestBase()
        {
            CalculationResult = new Core.Models.CalculationResult()
            {
                CalculationType = CalculationType,
                Tag = Tag,
                Date = DateTime.Now,
                Value = new List<decimal>() { 123 },
                Id = 1
            };
        }
    }
}
