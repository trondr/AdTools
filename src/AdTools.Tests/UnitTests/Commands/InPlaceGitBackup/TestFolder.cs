using System;
using System.Diagnostics;
using System.IO;

namespace AdTools.Tests.UnitTests.Commands.InPlaceGitBackup
{
    public class TestFolder : IDisposable
    {
        private readonly string _path;

        public TestFolder(string path)
        {
            if (path == null) throw new ArgumentNullException(nameof(path));
            _path = path;
            if (Directory.Exists(_path))
                throw new Exception("Test folder allready exists: " + _path);            
        }

        public string Path
        {
            get
            {
                if (!Directory.Exists(_path))
                {
                    Console.WriteLine("TEST: Creating test folder before test: " + _path);
                    Directory.CreateDirectory(_path);
                }
                return _path;
            }
        }

        public string AddOneFile()
        {
            var tempFile = System.IO.Path.Combine(Path, Guid.NewGuid() + ".txt");
            using (var sw = new StreamWriter(tempFile))
            {
                sw.WriteLine("Testing");
            }
            return tempFile;
        }    
        
        public void ModifyFile(string filePath)
        {
            using (var sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine("Testing");
                sw.WriteLine("Testing Modified");
            }            
        } 

        public void OverWriteButDoNotChange(string filePath)
        {
            using (var sw = new StreamWriter(filePath, false))
            {
                sw.WriteLine("Testing");               
            }
        }
        
        public void RemoveFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }      

        public void Dispose()
        {
            if (Directory.Exists(_path))
            {
                Console.WriteLine("TEST: Deleting test folder after test: " + _path);
                ResetAttributes(_path);
                Directory.Delete(_path, true);
            }
        }

        private void ResetAttributes(string path)
        {
            var folderPattern = System.IO.Path.Combine(path, "*");
            var arguments = string.Format("-R -H -S \"{0}\" /s /d", folderPattern);
            var startInfo = new ProcessStartInfo("attrib.exe", arguments);
            var process = Process.Start(startInfo);
            process?.WaitForExit();
        }

        
    }
}