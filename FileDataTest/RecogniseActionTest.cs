using System;
using FileData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;

namespace FileDataTest
{
    [TestClass]
    public class RecogniseActionTest
    {
        public static String[] testSizeArray = { "-s", "--s", "/s", "--size" };
        public static String[] testVersionArray = { "-v", "–v", "--v", "/v", "--version" };

        [TestMethod] 
        public void CanItRecogniseVersion()
        {
            // Arrange
            
            String[] arr = { "-v", "fileSiz.txt" };
            Mock<IFileDataService> fileDataMock = new Mock<IFileDataService>();
            bool returnValue = false;

            fileDataMock.Setup(x => x.IsVersonTask(arr[0])).Callback<string>(x =>
            {
                returnValue = !string.IsNullOrEmpty(x) && testVersionArray.ToList().Contains(x);
            });

            // Act
            var result = fileDataMock.Object.IsVersonTask(arr[0]);

            // Assert
            Assert.IsTrue(returnValue);

        }


        [TestMethod]
        public void CanItRecogniseInvalidVersion()
        {
            // Arrange

            String[] arr = { "-u", "fileSiz.txt" };
            Mock<IFileDataService> fileDataMock = new Mock<IFileDataService>();
            bool returnValue = false;

            fileDataMock.Setup(x => x.IsVersonTask(arr[0])).Callback<string>(x =>
            {
                returnValue = !string.IsNullOrEmpty(x) && testVersionArray.ToList().Contains(x);
            });

            // Act
            var result = fileDataMock.Object.IsVersonTask(arr[0]);

            // Assert
            Assert.IsFalse(returnValue);

        }

        [TestMethod]
        public void CanItRecogniseSize()
        {
            // Arrange

            String[] arr = { "-s", "fileSiz.txt" };
            Mock<IFileDataService> fileDataMock = new Mock<IFileDataService>();
            bool returnValue = false;

            fileDataMock.Setup(x => x.IsSizeTask(arr[0])).Callback<string>(x =>
            {
                returnValue = !string.IsNullOrEmpty(x) && testSizeArray.ToList().Contains(x);
            });

            // Act
            var result = fileDataMock.Object.IsSizeTask(arr[0]);

            // Assert
            Assert.IsTrue(returnValue);

        }


        [TestMethod]
        public void CanItRecogniseInvalidSize()
        {
            // Arrange

            String[] arr = { "-v", "fileSiz.txt" };
            Mock<IFileDataService> fileDataMock = new Mock<IFileDataService>();
            bool returnValue = false;

            fileDataMock.Setup(x => x.IsSizeTask(arr[0])).Callback<string>(x =>
            {
                returnValue = !string.IsNullOrEmpty(x) && testSizeArray.ToList().Contains(x);
            });

            // Act
            var result = fileDataMock.Object.IsSizeTask(arr[0]);

            // Assert
            Assert.IsFalse(returnValue);

        }
    }
}
