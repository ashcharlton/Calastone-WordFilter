using Calastone_WordFilter_Main;
using Calastone_WordFilter_Main.Filters.Implementations;
using Calastone_WordFilter_Main.Filters.Interfaces;

namespace Calastone_WordFilter.Integration.Tests
{
    public class TextFilterAppTests : IDisposable
    {
        private readonly string _testDirPath;
        private readonly List<ITextFilter> _realFilters;

        public TextFilterAppTests()
        {
            _testDirPath = Path.Combine(Path.GetTempPath(), "TestData");
            Directory.CreateDirectory(_testDirPath);

            _realFilters = new List<ITextFilter>
            {
                new TextLengthFilter(3),      
                new TextContainsLetterFilter('t', true),
                new MiddleVowelFilter(true)
            };
        }

        [Fact]
        public async Task ProcessFile_WithRealFilters_ProducesCorrectOutput()
        {
            // Arrange
            var filePath = Path.Combine(_testDirPath, "input.txt");
            await File.WriteAllTextAsync(filePath, "can't The quick brown fox jumps over the bad dog.");

            var app = new TextFilterApp(_realFilters);
            var sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            await app.RunAsync(filePath);

            // Assert
            var output = sw.ToString().Trim();
            Assert.Equal("jumps", output);
        }

        [Fact]
        public async Task ProcessFile_WithSpecialCharacters_FiltersCorrectWords()
        {
            // Arrange
            var filePath = Path.Combine(_testDirPath, "input.txt");
            await File.WriteAllTextAsync(filePath, "Hello, world! This-is a test.");

            var app = new TextFilterApp(_realFilters);
            var sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            await app.RunAsync(filePath);

            // Assert
            var output = sw.ToString().Trim();
            Assert.Contains("Hello world", output);
        }

        public void Dispose()
        {
            if (Directory.Exists(_testDirPath))
            {
                Directory.Delete(_testDirPath, true);
            }

            var standardOutput = new StreamWriter(Console.OpenStandardOutput());
            standardOutput.AutoFlush = true;
            Console.SetOut(standardOutput);
        }
    }
}