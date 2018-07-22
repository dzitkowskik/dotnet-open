namespace Slnopen
{
    using System;
    using System.Diagnostics;
    using System.IO.Abstractions;

    /// <summary>
    /// Class for running default program for file.
    /// </summary>
    /// <seealso cref="Slnopen.IProgramRunner" />
    internal class ProgramRunner : IProgramRunner
    {
        private readonly IProcessProxy process;
        private readonly IFileSystem fileSystem;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProgramRunner"/> class.
        /// </summary>
        /// <param name="process">The process.</param>
        /// <param name="fileSystem">The file system.</param>
        /// <exception cref="ArgumentNullException">
        /// process
        /// or
        /// fileSystem
        /// </exception>
        public ProgramRunner(IProcessProxy process, IFileSystem fileSystem)
        {
            this.process = process ?? throw new ArgumentNullException(nameof(process));
            this.fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
        }

        private enum Verb
        {
            OPEN,
            EDIT
        }

        /// <summary>
        /// Opens the file with default program.
        /// </summary>
        /// <param name="file">The file to open.</param>
        /// <param name="editMode">if set to <c>true</c> file will be opened in edit mode.</param>
        public void OpenFileWithDefaultProgram(string file, bool editMode = false)
        {
            var mode = editMode ? Verb.EDIT.ToString() : Verb.OPEN.ToString();

            var pi = new ProcessStartInfo(file)
            {
                Arguments = this.fileSystem.Path.GetFileName(file),
                UseShellExecute = true,
                WorkingDirectory = this.fileSystem.Path.GetDirectoryName(file),
                FileName = file,
                Verb = mode
            };

            this.process.StartProcess(pi);
        }
    }
}
