using DocumentReader.Model;
using DocumentReader.Service;

namespace UnitTests
{
    public class DocumentConverterTests
    {
        [Fact]
        public void Deserialize_ReturnsDocument()
        {
            // Arrange
            string input = @"<document>
                                 <title>title</title>
                                 <text>text</text>
                             </document>";

            IDocumentConverter converter = new XmlDocumentConverter();

            // Act
            Document result = converter.Deserialize(input);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("title", result.Title);
            Assert.Equal("text", result.Text);
        }
    }
}
