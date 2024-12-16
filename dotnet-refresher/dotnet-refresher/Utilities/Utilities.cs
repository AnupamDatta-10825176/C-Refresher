using System.IO;
using dotnet_refresher.UtilitieClasses.Interfaces;

namespace dotnet_refresher.UtilitieClasses
{
    public class Utilities : IUtilities
    {
        public Utilities()
        { }

        public string CreateFolder(string path, string dirName)
        {
            // Create the folder/directory
            return Directory.CreateDirectory(Path.Combine(path, dirName)).FullName;
        }

        public void CreateTextFile(string path, string fileName)
        {
            // Create new text file
            File.Create(Path.Combine(path, fileName)).Close();
        }

        public void WriteIntoFile(string path, string content)
        {
            // Write inside a file.
            File.AppendAllText(path, content);
        }

        public string GetFileContent(string path)
        {
            return File.ReadAllText(path);            
        }
    }
}

