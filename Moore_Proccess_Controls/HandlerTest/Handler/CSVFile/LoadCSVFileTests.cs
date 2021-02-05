using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moore_Proccess_Controls.Core.Models.Request;
using Moore_Proccess_Controls.Core.Models.Enums;
using System.Linq;

namespace Moore_Proccess_Controls.Test.InternalTesting.Handler.CSVFile
{
    [TestClass]
    public class LoadCSVFileTests : CSVFileBase
    {
        [TestMethod]
        public void Valid()
        {
            //Arrange
            LoadCSVFileRequest request = new LoadCSVFileRequest()
            { 
                Path = CSVPath
            };

            //Act
            var response = handler.Load(request);

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(ResponseCodes.Success, response.ResponseCode);
            Assert.IsFalse(response.Errors.Any());
            Assert.IsNotNull(response.FileData);
            Assert.IsTrue(response.FileData.Headers.Any());
            Assert.IsTrue(response.FileData.Lines.Any());

        }

        [TestMethod]
        public void InvalidPath()
        {
            //Arrange
            LoadCSVFileRequest request = new LoadCSVFileRequest()
            {
                Path = @"Zzz:\Random\Path\To\File\TestFile.csv"
            };

            //Act
            var response = handler.Load(request);

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(ResponseCodes.Validation ,response.ResponseCode);
            Assert.IsTrue(response.Errors.Any());
            Assert.IsNotNull(response.FileData);
            Assert.IsFalse(response.FileData.Headers.Any());
            Assert.IsFalse(response.FileData.Lines.Any());

        }

        [TestMethod]
        public void MissingPathValue()
        {
            //Arrange
            LoadCSVFileRequest request = new LoadCSVFileRequest()
            {
                Path = string.Empty
            };

            //Act
            var response = handler.Load(request);

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(ResponseCodes.Validation, response.ResponseCode);
            Assert.IsTrue(response.Errors.Any());
            Assert.IsNotNull(response.FileData);
            Assert.IsFalse(response.FileData.Headers.Any());
            Assert.IsFalse(response.FileData.Lines.Any());

        }
    }
}
