using System;
using System.IO;

namespace AdTools.Tests.UnitTests.Commands.InPlaceGitBackup
{
    public class TestFolderHelper
    {
        public static TestFolder CreateTestFolder()
        {
            var tempFolder = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            var testFolder = new TestFolder(tempFolder);
            return testFolder;
        }

        //public static TestFolder CreateTestFolderWithOneFile()
        //{
        //    var testFolder = TestFolderHelper.CreateTestFolder();
        //    var testFile = CreateTestFile(testFolder.Path);
        //    return testFolder;
        //}

        //public static string CreateTestFile(string testFolderPath)
        //{
        //    var tempFile = Path.Combine(testFolderPath, Guid.NewGuid() + ".txt");
        //    using (var sw = new StreamWriter(tempFile))
        //    {
        //        sw.Write("Testing");
        //    }
        //    return tempFile;
        //}

        //public static TestFolder CreateTestFolderWithTwoFiles()
        //{
        //    var testFolder = TestFolderHelper.CreateTestFolder();
        //    var testFile = CreateTestFile(testFolder.Path);
        //    var testFile2 = CreateTestFile(testFolder.Path);
        //    return testFolder;
        //}
    }
}