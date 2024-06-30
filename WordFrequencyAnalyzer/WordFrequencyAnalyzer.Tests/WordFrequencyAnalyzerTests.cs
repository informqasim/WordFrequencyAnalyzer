using WordFrequencyAnalyzer.Implementations;
using WordFrequencyAnalyzer.Interfaces;
using Xunit;

namespace WordFrequencyAnalyzer.Tests
{
    public class WordFrequencyAnalyzerTests
    {
        private readonly IWordFrequencyAnalyzer _analyzer;

        public WordFrequencyAnalyzerTests()
        {
            _analyzer = new WordFrequencyAnalyzerImpl();
        }

        [Theory]
        [InlineData("The sun shines over the lake", 2)]
        [InlineData("This is a test. This test is simple.", 2)]
        [InlineData("Hello world! Hello everyone.", 2)]
        public void CalculateHighestFrequency_ShouldReturnHighestFrequency(string text, int expected)
        {
            // Act
            var result = _analyzer.CalculateHighestFrequency(text);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("The sun shines over the lake", "the", 2)]
        [InlineData("This is a test. This test is simple.", "test", 2)]
        [InlineData("Hello world! Hello everyone.", "hello", 2)]
        [InlineData("Unique words are here", "unique", 1)]
        public void CalculateFrequencyForWord_ShouldReturnFrequencyForWord(string text, string word, int expected)
        {
            // Act
            var result = _analyzer.CalculateFrequencyForWord(text, word);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CalculateMostFrequentWords_ShouldReturnMostFrequentWords()
        {
            // Arrange
            string text = "The sun shines over the lake. The lake is clear.";
            int number = 3;

            // Act
            var result = _analyzer.CalculateMostFrequentWords(text, number);

            // Assert
            Assert.Equal(3, result.Count);
            Assert.Equal("the", result[0].Word);
            Assert.Equal(2, result[0].Frequency);
            Assert.Equal("lake", result[1].Word);
            Assert.Equal(2, result[1].Frequency);
            Assert.Equal("clear", result[2].Word);
            Assert.Equal(1, result[2].Frequency);
        }

        [Fact]
        public void CalculateMostFrequentWords_ShouldThrowExceptionForInvalidCharacters()
        {
            // Arrange
            string text = "This text has invalid characters: 12345!";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _analyzer.CalculateMostFrequentWords(text, 3));
        }
    }
}
