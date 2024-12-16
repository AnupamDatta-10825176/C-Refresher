using dotnet_refresher.UtilitieClasses.Interfaces;
using System.IO;

namespace dotnet_refresher.UtilitieClasses
{
    public class Utilities : IUtilities
    {
        public Utilities()
        { }

        public void CreateFolder(string path, string dirName)
        {
            // Create the folder/directory
            Directory.CreateDirectory(Path.Combine(path, dirName));
        }
    }
}

