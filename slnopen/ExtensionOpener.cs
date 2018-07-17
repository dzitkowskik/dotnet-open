using System;
using System.IO.Abstractions;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("slnopen.test")]
namespace slnopen
{
    internal class ExtensionOpener
    {
        private readonly IFileSystem _fileSystem;
        private readonly IProgramRunner _programRunner;

        public ExtensionOpener(IProgramRunner programRunner, IFileSystem fileSystem)
        {
            _programRunner = programRunner ?? throw new ArgumentNullException(nameof(programRunner));
            _fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
        }

        public void Open(Options options)
        {
            if (!string.IsNullOrEmpty(options.SelectedFile))
                OpenSingleFile(options.SelectedFile, options.EditMode);
            else
                OpenAllFilesWithExtension(options.Extension, options.EditMode);
        }

        private void OpenAllFilesWithExtension(string extension, bool editMode)
        {
            foreach (var absoluteFilePath in GetAbsolutePathsOfAllFilesWithExtension(extension))
            {
                OpenSingleFile(absoluteFilePath, editMode);
            }
        }

        private string[] GetAbsolutePathsOfAllFilesWithExtension(string extension)
        {
            var currentDirectory = _fileSystem.Directory.GetCurrentDirectory();
            return _fileSystem.Directory.GetFiles(currentDirectory, $"*.{extension}");
        }

        private void OpenSingleFile(string file, bool editMode)
        {
            var absoluteFilePath = GetAbsoluteFilePath(file);
            _programRunner.OpenFileWithDefaultProgram(absoluteFilePath, editMode);
        }

        private string GetAbsoluteFilePath(string filePath)
        {
            if (_fileSystem.Path.IsPathRooted(filePath))
            {
                return filePath;
            }

            var currentDirectory = _fileSystem.Directory.GetCurrentDirectory();

            return _fileSystem.Path.Combine(currentDirectory, filePath);
        }
    }
}
