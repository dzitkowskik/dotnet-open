using System;
using System.IO.Abstractions;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("slnopen.test")]
namespace Slnopen
{
    /// <summary>
    /// Main class containing logic of the program.
    /// </summary>
    internal class ExtensionOpener
    {
        private readonly IFileSystem fileSystem;
        private readonly IProgramRunner programRunner;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtensionOpener"/> class.
        /// </summary>
        /// <param name="programRunner">The program runner.</param>
        /// <param name="fileSystem">The file system.</param>
        /// <exception cref="ArgumentNullException">
        /// programRunner
        /// or
        /// fileSystem
        /// </exception>
        public ExtensionOpener(IProgramRunner programRunner, IFileSystem fileSystem)
        {
            this.programRunner = programRunner ?? throw new ArgumentNullException(nameof(programRunner));
            this.fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
        }

        /// <summary>
        /// Perform file open with specified options.
        /// </summary>
        /// <param name="options">The options.</param>
        public void Open(Options options)
        {
            if (!string.IsNullOrEmpty(options.SelectedFile))
            {
                this.OpenSingleFile(options.SelectedFile, options.EditMode, options.AdminMode);
            }
            else
            {
                this.OpenAllFilesWithExtension(options.Extension, options.EditMode, options.AdminMode);
            }
        }

        private void OpenAllFilesWithExtension(string extension, bool editMode, bool adminMode)
        {
            foreach (var absoluteFilePath in this.GetAbsolutePathsOfAllFilesWithExtension(extension))
            {
                this.OpenSingleFile(absoluteFilePath, editMode, adminMode);
            }
        }

        private string[] GetAbsolutePathsOfAllFilesWithExtension(string extension)
        {
            var currentDirectory = this.fileSystem.Directory.GetCurrentDirectory();
            return this.fileSystem.Directory.GetFiles(currentDirectory, $"*.{extension}");
        }

        private void OpenSingleFile(string file, bool editMode, bool adminMode)
        {
            var absoluteFilePath = this.GetAbsoluteFilePath(file);
            this.programRunner.OpenFileWithDefaultProgram(absoluteFilePath, editMode, adminMode);
        }

        private string GetAbsoluteFilePath(string filePath)
        {
            if (this.fileSystem.Path.IsPathRooted(filePath))
            {
                return filePath;
            }

            var currentDirectory = this.fileSystem.Directory.GetCurrentDirectory();

            return this.fileSystem.Path.Combine(currentDirectory, filePath);
        }
    }
}
