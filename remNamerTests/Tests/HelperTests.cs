using remNamer.Class;

namespace remNamerTests.Tests
{
    [TestClass]
    public class HelperTests
    {
        private string testDirectoryPath;

        [TestInitialize]
        public void Setup()
        {
            // Crear un directorio de prueba con algunos archivos
            testDirectoryPath = Path.Combine(Path.GetTempPath(), "testDirectory");
            Directory.CreateDirectory(testDirectoryPath);

            File.WriteAllText(Path.Combine(testDirectoryPath, "file1.txt"), "Contenido de prueba 1");
            File.WriteAllText(Path.Combine(testDirectoryPath, "file2.log"), "Contenido de prueba 2");
            File.WriteAllText(Path.Combine(testDirectoryPath, "file3.txt"), "Contenido de prueba 3");
        }

        [TestCleanup]
        public void Cleanup()
        {
            // Eliminar el directorio de prueba
            if (Directory.Exists(testDirectoryPath))
            {
                Directory.Delete(testDirectoryPath, true);
            }
        }

        [TestMethod]
        public void GetFiles_ShouldReturnAllFiles_WhenRecursiveSearchIsFalse()
        {
            // Arrange
            string[] filters = { "*.txt", "*.log" };

            // Act
            List<string> files = Helper.GetFiles(testDirectoryPath, false, filters);

            // Assert
            Assert.AreEqual(3, files.Count);
            CollectionAssert.Contains(files, Path.Combine(testDirectoryPath, "file1.txt"));
            CollectionAssert.Contains(files, Path.Combine(testDirectoryPath, "file2.log"));
            CollectionAssert.Contains(files, Path.Combine(testDirectoryPath, "file3.txt"));
        }

        [TestMethod]
        public void GetFiles_ShouldReturnAllFiles_WhenRecursiveSearchIsTrue()
        {
            // Arrange
            string subDirectoryPath = Path.Combine(testDirectoryPath, "subDirectory");
            Directory.CreateDirectory(subDirectoryPath);
            File.WriteAllText(Path.Combine(subDirectoryPath, "file4.txt"), "Contenido de prueba 4");

            string[] filters = { "*.txt", "*.log" };

            // Act
            List<string> files = Helper.GetFiles(testDirectoryPath, true, filters);

            // Assert
            Assert.AreEqual(4, files.Count);
            CollectionAssert.Contains(files, Path.Combine(testDirectoryPath, "file1.txt"));
            CollectionAssert.Contains(files, Path.Combine(testDirectoryPath, "file2.log"));
            CollectionAssert.Contains(files, Path.Combine(testDirectoryPath, "file3.txt"));
            CollectionAssert.Contains(files, Path.Combine(subDirectoryPath, "file4.txt"));
        }

        [TestMethod]
        public void GetFilesUsingFilters_ShouldReturnFilteredFiles()
        {
            // Arrange
            string[] filters = { "*.txt" };

            // Act
            List<string> files = Helper.GetFilesUsingFilters(testDirectoryPath, filters);

            // Assert
            Assert.AreEqual(2, files.Count);
            CollectionAssert.Contains(files, Path.Combine(testDirectoryPath, "file1.txt"));
            CollectionAssert.Contains(files, Path.Combine(testDirectoryPath, "file3.txt"));
        }
    }
}
