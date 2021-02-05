using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moore_Proccess_Controls.Core.Calculation;
using System.Collections.Generic;

namespace Moore_Proccess_Controls.Test.InternalTesting.Calculation
{
    [TestClass]
    public class StandardDeviationTests : CulculationBase
    {
        [TestMethod]
        public void Valid()
        {
            //Arrange
            IEnumerable<decimal> values = new List<decimal>()
            {
                1,
                2,
                3,
                4,
            };


            //Act
            var result = StandardDeviation.Calculate(values);

            //Assert    
            Assert.AreEqual(2.5m, result);

        }
    }
}
