using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Moore_Proccess_Controls.Test.InternalTesting.DataAccess.Log
{
    [TestClass]
    public class InsertTests : LogBase
    {
        [TestMethod]
        public void Valid()
        {
            //Arrange
            Core.Models.Log model = new Core.Models.Log()
            { 
                LogLevel = Core.Models.Enums.LogLevels.Debug,
                Message = "Unit test message saying hello."
            };

            //Act
            var result = da.Insert(model);

            //Assert    
            Assert.IsTrue(result);

        }
    }
}
