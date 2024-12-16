using dotnet_refresher.UtilitieClasses.Interfaces;
using dotnet_refresher.UtilitieClasses;

namespace dotnet_refresher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IUtilities utilities = new Utilities();

            // Create a new folder
            string dirPath = @"C:\Users\10825176\OneDrive - LTIMindtree\Desktop";
            utilities.CreateFolder(dirPath, "Test Dir");
        }
    }
}
