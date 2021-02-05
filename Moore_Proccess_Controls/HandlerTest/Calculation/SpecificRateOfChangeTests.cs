using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moore_Proccess_Controls.Core.Calculation;
using System;
using System.Collections.Generic;

namespace Moore_Proccess_Controls.Test.InternalTesting.Calculation
{
    [TestClass]
    public class SpecificRateOfChangeTests : CulculationBase
    {
        [TestMethod]
        public void Valid()
        {
            //Arrange
            List<Tuple<DateTime, decimal>> values = new List<Tuple<DateTime, decimal>>()
            {
                new Tuple<DateTime, decimal>(DateTime.Now.AddSeconds(-1), 32.9658m),
                new Tuple<DateTime, decimal>(DateTime.Now.AddMilliseconds(-800), 33m),
                new Tuple<DateTime, decimal>(DateTime.Now.AddMilliseconds(-740), 31.9658m),
            };

            //Act
            var result = SpecificRateOfChange.Calculate(values);

            //Assert    
          //  Assert.AreEqual(0m, result);

        }
    }
}
