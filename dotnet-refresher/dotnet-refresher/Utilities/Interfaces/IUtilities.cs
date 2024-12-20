namespace dotnet_refresher.UtilitieClasses.Interfaces
{
    public interface IUtilities
    {
        /// <summary>
        /// Creates a new directory into a specified path with the given directory name.
        /// </summary>
        /// <param name="path">location where the new directory will get created.</param>
        /// <param name="dirName">Name of the new directory/folder</param>
        string CreateFolder(string path, string dirName);

        /// <summary>
        /// Creates  a new text file in a specified path.
        /// </summary>
        /// <param name="path">location where the new file will get created.</param>
        /// <param name="fileName">Name of the new text file</param>
        void CreateTextFile(string path, string fileName);

        /// <summary>
        /// Write inside an existing file.
        /// </summary>
        /// <param name="path">Location of the existing file.</param>
        /// <param name="content">Data to write in the file.</param>
        void WriteIntoFile(string path, string content);

        /// <summary>
        /// Returns the content of the file.
        /// </summary>
        /// <param name="path">Location of the file.</param>
        /// <returns>content of the file.</returns>
        string GetFileContent(string path);
    }
}
