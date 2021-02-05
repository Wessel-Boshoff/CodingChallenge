using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Moore_Proccess_Controls.Test.InternalTesting.DataAccess.CalculationResult
{
    [TestClass]
    public class InsertTests : CalculationResultBase
    {
        [TestMethod]
        public void Valid()
        {
            //Act
            var result = da.Insert(CalculationResult);

            //Assert    
            Assert.IsTrue(result);

        }
    }
}
