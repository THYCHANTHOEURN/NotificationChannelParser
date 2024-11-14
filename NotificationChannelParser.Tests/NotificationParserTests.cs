using NotificationChannelParser.Services;
using Xunit;

namespace NotificationChannelParser.Tests
{
    public class NotificationParserTests
    {
        private readonly INotificationParser _parser;

        public NotificationParserTests()
        {
            _parser = new NotificationParser();
        }

        [Theory]
        [InlineData("[BE][FE][Urgent] there is error", "Receive channels: BE, FE, URGENT")]
        [InlineData("[BE][QA][HAHA][Urgent] there is error", "Receive channels: BE, QA, URGENT")]
        [InlineData("[INVALID][TEST] some text", "No valid channels found")]
        [InlineData("", "No channels found")]
        public void Parse_ShouldReturnExpectedResult(string input, string expected)
        {
            // Act
            var result = _parser.Parse(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Parse_WithMultipleValidTags_ReturnsCorrectChannels()
        {
            // Arrange
            var input = "[BE][FE][Urgent] there is error";

            // Act
            var result = _parser.Parse(input);

            // Assert
            Assert.Equal("Receive channels: BE, FE, URGENT", result);
        }

        [Fact]
        public void Parse_WithInvalidTags_IgnoresInvalidTags()
        {
            // Arrange
            var input = "[BE][QA][HAHA][Urgent] there is error";

            // Act
            var result = _parser.Parse(input);

            // Assert
            Assert.Equal("Receive channels: BE, QA, URGENT", result);
        }
    }
}