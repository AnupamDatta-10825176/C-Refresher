using System.IO;
using dotnet_refresher.UtilitieClasses;
using dotnet_refresher.UtilitieClasses.Interfaces;

namespace dotnet_refresher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IUtilities utilities = new Utilities();

            // Create a new folder
            string dirPath = @"C:\Users\10825176\OneDrive - LTIMindtree\Desktop";
            string dirName = "Test Dir";
            string dirFinalPath = utilities.CreateFolder(dirPath, dirName);

            // Create a new file
            string fileName = @"Test file.txt";
            utilities.CreateTextFile(dirFinalPath, fileName);

            // Write inside the file
            string filePath = Path.Combine(dirFinalPath, fileName);
            string fileContent = @"Test data inside test file";
            utilities.WriteIntoFile(filePath, fileContent);
        }
    }
}
