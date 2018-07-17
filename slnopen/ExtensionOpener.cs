using System;
using System.IO;
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
            if (string.IsNullOrEmpty(options.SelectedFile))
                OpenAllFiles();
            else
                OpenSelectedFile(options.SelectedFile);
        }

        private void OpenSelectedFile(string selectedFile)
        {
            if (_fileSystem.Path.IsPathRooted(selectedFile))
            {
                _programRunner.OpenFileWithDefaultProgram(selectedFile);
            }

            var currentDirectory = _fileSystem.Directory.GetCurrentDirectory();

            var absoluteFilePath = _fileSystem.Path.Combine(currentDirectory, selectedFile);

            _programRunner.OpenFileWithDefaultProgram(absoluteFilePath);
        }

        private void OpenAllFiles()
        {
            var currentDirectory = _fileSystem.Directory.GetCurrentDirectory();

            var slnFiles = _fileSystem.Directory.GetFiles(currentDirectory, "*.sln");

            foreach (var file in slnFiles)
            {
                _programRunner.OpenFileWithDefaultProgram(file);
            }
        }
    }
}
