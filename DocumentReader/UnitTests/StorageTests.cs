using DocumentReader;
using DocumentReader.Service;

namespace UnitTests
{
    public class StorageTests
    {
        [Fact]
        public void GetStorage_Returns_FileSystemDocumentReader_For_FileSource()
        {
            // Arrange
            string sourceFileName = "test.txt";

            // Act
            IDocumentReader reader = Helper.GetStorage(sourceFileName);

            // Assert
            Assert.IsType<FileSystemDocumentReader>(reader);
        }

        [Fact]
        public void GetStorage_Returns_Null_For_HttpSource()
        {
            // Arrange
            string sourceFileName = "http://test.com";

            // Act
            IDocumentReader reader = Helper.GetStorage(sourceFileName);

            // Assert
            Assert.IsType<HttpDocumentReader>(reader);
        }
    }
}
