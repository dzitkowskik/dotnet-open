namespace Slnopen
{
    /// <summary>
    /// File runner.
    /// </summary>
    internal interface IProgramRunner
    {
        /// <summary>
        /// Opens the file with default program.
        /// </summary>
        /// <param name="file">The file to open.</param>
        /// <param name="editMode">if set to <c>true</c> file will be opened in edit mode.</param>
        /// <param name="adminMode">if set to <c>true</c> file will be opened in admin mode.</param>
        void OpenFileWithDefaultProgram(string file, bool editMode = false, bool adminMode = false);
    }
}