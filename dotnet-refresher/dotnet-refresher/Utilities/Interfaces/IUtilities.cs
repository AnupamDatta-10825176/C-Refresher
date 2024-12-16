namespace dotnet_refresher.UtilitieClasses.Interfaces
{
    public interface IUtilities
    {
        /// <summary>
        /// Creates a new directory into a specified path with the given directory name.
        /// </summary>
        /// <param name="path">location where the new directory will get created.</param>
        /// <param name="dirName">Name of the new directory/folder</param>
        void CreateFolder(string path, string dirName);
    }
}
