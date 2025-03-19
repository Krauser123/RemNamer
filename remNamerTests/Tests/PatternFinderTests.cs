using remNamer.Class;
using remNamer;

namespace remNamerTests.Tests
{
    [TestClass]
    public class PatternFinderTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SearchPatterns_ShouldThrowArgumentException_WhenFilesIsNull()
        {
            // Arrange
            var patternFinder = new PatternFinder();

            // Act
            patternFinder.SearchPatterns(null);

            // Assert is handled by ExpectedException
        }

        [TestMethod]
        public void SearchPatterns_ShouldReturnPatterns_WhenFilesAreValid()
        {
            // Arrange
            var patternFinder = new PatternFinder();
            var files = new List<FileToRename>
            {
                new FileToRename("C:\\temp\\file1_test.txt"),
                new FileToRename("C:\\temp\\file2_test.txt"),
                new FileToRename("C:\\temp\\file3_test.txt")
            };

            // Act
            var patterns = patternFinder.SearchPatterns(files);

            // Assert
            Assert.IsNotNull(patterns);
            Assert.IsTrue(patterns.Count > 0);
            Assert.IsTrue(patterns.ContainsKey("file1"));
            Assert.IsTrue(patterns.ContainsKey("file2"));
            Assert.IsTrue(patterns.ContainsKey("file3"));
        }

        [TestMethod]
        public void CountPatterns_ShouldReturnCorrectPatternCount()
        {
            // Arrange
            var patternFinder = new PatternFinder();
            string text = "file1 file2 file3 file1 file2 file1";

            // Act
            var patterns = patternFinder.CountPatterns(text);

            // Assert
            Assert.AreEqual(3, patterns["file1"]);
            Assert.AreEqual(2, patterns["file2"]);
            Assert.AreEqual(1, patterns["file3"]);
        }

        [TestMethod]
        public void GetRandomItemsAsExample_ShouldReturnCorrectNumberOfItems()
        {
            // Arrange
            var patternFinder = new PatternFinder();
            var files = new List<FileToRename>();
            for (int i = 0; i < 100; i++)
            {
                files.Add(new FileToRename($"C:\\temp\\file{i}.txt"));
            }

            // Act
            var exampleItems = patternFinder.GetRandomItemsAsExample(files);

            // Assert
            Assert.IsTrue(exampleItems.Count > 0);
            Assert.IsTrue(exampleItems.Count <= 20); // Based on the logic in GetRandomItemsAsExample
        }
    }
}
