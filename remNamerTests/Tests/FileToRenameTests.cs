using remNamer;

namespace remNamerTests.Tests
{
    [TestClass]
    public class FileToRenameTests
    {
        private string testFilePath;

        [TestInitialize]
        public void Setup()
        {
            // Crear un archivo de prueba
            testFilePath = Path.Combine(Path.GetTempPath(), "testFile.txt");
            File.WriteAllText(testFilePath, "Contenido de prueba");
        }

        [TestCleanup]
        public void Cleanup()
        {
            // Eliminar el archivo de prueba
            if (File.Exists(testFilePath))
            {
                File.Delete(testFilePath);
            }
        }

        [TestMethod]
        public void Constructor_ShouldInitializeProperties()
        {
            // Arrange & Act
            var fileToRename = new FileToRename(testFilePath);

            // Assert
            Assert.AreEqual("testFile", fileToRename.NameWithoutExtension);
            Assert.AreEqual("testFile.txt", fileToRename.Name);
            Assert.AreEqual(".txt", fileToRename.FileExtension);
            Assert.AreEqual(File.GetCreationTime(testFilePath).ToShortDateString(), fileToRename.Created);
            Assert.AreEqual(File.GetLastWriteTime(testFilePath).ToShortDateString(), fileToRename.Modified);
            Assert.AreEqual("Contenido de prueba".Length + " B", fileToRename.FileSize);
        }

        [TestMethod]
        public void SetNameAfterChanges_ShouldUpdateNameAfterChanges()
        {
            // Arrange
            var fileToRename = new FileToRename(testFilePath);
            string newName = "newTestFile";

            // Act
            fileToRename.SetNameAfterChanges(newName);

            // Assert
            Assert.AreEqual("newTestFile.txt", fileToRename.NameAfterChanges);
        }

        [TestMethod]
        public void RenameFile_ShouldRenameFile()
        {
            // Arrange
            var fileToRename = new FileToRename(testFilePath);
            string newName = "renamedTestFile.txt";
            fileToRename.SetNameAfterChanges(newName);

            // Act
            fileToRename.RenameFile();

            // Assert
            string newFilePath = Path.Combine(Path.GetTempPath(), newName);
            Assert.IsTrue(File.Exists(newFilePath));
            Assert.IsFalse(File.Exists(testFilePath));

            // Cleanup
            if (File.Exists(newFilePath))
            {
                File.Delete(newFilePath);
            }
        }

        [TestMethod]
        public void GetFormattedFileSize_ShouldReturnCorrectSize()
        {
            // Arrange
            var fileToRename = new FileToRename(testFilePath);

            // Act
            string fileSize = fileToRename.FileSize;

            // Assert
            Assert.AreEqual("Contenido de prueba".Length + " B", fileSize);
        }
    }
}
