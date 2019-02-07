using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileData;
using Moq;
using ThirdPartyTools;

namespace FileDataTest
{
    /// <summary>
    /// Summary description for GetAppropriateActionTest
    /// </summary>
    [TestClass]
    public class GetAppropriateActionTest
    {
        public GetAppropriateActionTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void GetAppropriateActionTestVersion()
        {
            // Arrange
            Mock<FileDetails> fileDetailsMock = new Mock<FileDetails>();
            IFileDataService service = new FileDataService(fileDetailsMock.Object);
            String[] arr = { "-v", "fileSiz.txt" };
          
            Mock<IFileDataService> fileDataMock = new Mock<IFileDataService>();

            string returnValue = "";

            Assert.IsTrue(arr.Length == 2);
            fileDataMock.Setup(x => x.GetAppropriateAction(arr[0], arr[1])).Callback<string, string>((x, y) =>
            {
                if (service.IsSizeTask(x))
                {
                    returnValue = "GetSize";
                  // fileDetailsMock.Object.Size(y);
                } else if (service.IsVersonTask(x))
                {
                    returnValue = "GetVersion";
                    //fileDetailsMock.Setup(a => a.Version(y)).Returns("");
                    fileDetailsMock.Object.Version(y);
                }
            });

            // Act
            fileDataMock.Object.GetAppropriateAction(arr[0], arr[1]);

            // Assert
            Assert.IsTrue(returnValue == "GetVersion");
            Assert.IsFalse(returnValue == "GetSize");
        }

        [TestMethod]
        public void GetAppropriateActionTestSize()
        {
            // Arrange
            Mock<FileDetails> fileDetailsMock = new Mock<FileDetails>();
            IFileDataService service = new FileDataService(fileDetailsMock.Object);
            String[] arr = { "-s", "fileSiz.txt" };
            
            Mock<IFileDataService> fileDataMock = new Mock<IFileDataService>();

            string returnValue = "";

            Assert.IsTrue(arr.Length == 2);
            fileDataMock.Setup(x => x.GetAppropriateAction(arr[0], arr[1])).Callback<string, string>((x, y) =>
            {
                if (service.IsSizeTask(x))
                {
                    returnValue = "GetSize";
                    // fileDetailsMock.Object.Size(y);
                }
                else if (service.IsVersonTask(x))
                {
                    returnValue = "GetVersion";
                    //fileDetailsMock.Setup(a => a.Version(y)).Returns("");
                    fileDetailsMock.Object.Version(y);
                }
            });

            // Act
            fileDataMock.Object.GetAppropriateAction(arr[0], arr[1]);

            // Assert
            Assert.IsTrue(returnValue == "GetSize");
            Assert.IsFalse(returnValue == "GetVersion");
            //fileDetailsMock.Verify(mock => mock.Version(It.IsAny<string>()), Times.Once());
            //fileDetailsMock.Verify(mock => mock.Size(It.IsAny<string>()), Times.Never());
        }


        [TestMethod]
        public void GetAppropriateActionVerifySize()
        {
            // Arrange
            Mock<FileDetails> fileDetailsMock = new Mock<FileDetails>();
            IFileDataService service = new FileDataService(fileDetailsMock.Object);
            String[] arr = { "-s", "fileSiz.txt" };

            string returnValue = "";
            Assert.IsTrue(arr.Length == 2);

            // Act
            var result = service.GetAppropriateAction(arr[0], arr[1]);
            int outint;
            // Assert
            Assert.IsTrue(int.TryParse(result, out outint));
           // Assert.IsFalse(int.TryParse(result, out outint));
        }


        [TestMethod]
        public void GetAppropriateActionVerifyVersion()
        {
            // Arrange
            Mock<FileDetails> fileDetailsMock = new Mock<FileDetails>();
            IFileDataService service = new FileDataService(fileDetailsMock.Object);
            String[] arr = { "-v", "fileSiz.txt" };

            string returnValue = "";
            Assert.IsTrue(arr.Length == 2);

            // Act
            var result = service.GetAppropriateAction(arr[0], arr[1]);
            int outint;
            // Assert
            Assert.IsFalse(int.TryParse(result, out outint));
            // Assert.IsFalse(int.TryParse(result, out outint));
        }
    }
}
