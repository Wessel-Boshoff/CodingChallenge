using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moore_Proccess_Controls.Core.Models.Request;
using Moore_Proccess_Controls.Core.Models.Enums;
using System.Linq;

namespace Moore_Proccess_Controls.Test.InternalTesting.Handler.CalculationResult
{
    [TestClass]
    public class InsertCalculationResultTests : CalculationResultBase
    {
        [TestMethod]
        public void ValidDB()
        {
            //Arrange
            InsertCalculationResultRequest request = new InsertCalculationResultRequest()
            { 
                CalculationResult = CalculationResult,
                Endpoint = DataEndpoint.DB
            };

            //Act
            var response = handler.Insert(request);

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(ResponseCodes.Success, response.ResponseCode);
            Assert.IsFalse(response.Errors.Any());

        }

        [TestMethod]
        public void ValidCSV()
        {
            //Arrange
            InsertCalculationResultRequest request = new InsertCalculationResultRequest()
            {
                CalculationResult = CalculationResult,
                Endpoint = DataEndpoint.CSV
            };

            //Act
            var response = handler.Insert(request);

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(ResponseCodes.Success, response.ResponseCode);
            Assert.IsFalse(response.Errors.Any());

        }
    }
}
