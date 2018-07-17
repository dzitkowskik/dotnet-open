using System;
using System.Diagnostics;
using System.IO.Abstractions;

namespace slnopen
{
    internal class ProgramRunner : IProgramRunner
    {
        private readonly IProcessProxy _process;
        private readonly IFileSystem _fileSystem;

        public ProgramRunner(IProcessProxy process, IFileSystem fileSystem)
        {
            _process = process ?? throw new ArgumentNullException(nameof(process));
            _fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
        }

        public void OpenFileWithDefaultProgram(string file, bool editMode = false)
        {
            var mode = editMode ? Verb.EDIT.ToString() : Verb.OPEN.ToString();

            var pi = new ProcessStartInfo(file)
            {
                Arguments = _fileSystem.Path.GetFileName(file),
                UseShellExecute = true,
                WorkingDirectory = _fileSystem.Path.GetDirectoryName(file),
                FileName = file,
                Verb = mode
            };

            _process.StartProcess(pi);
        }

        private enum Verb
        {
            OPEN,
            EDIT
        }
    }
}
