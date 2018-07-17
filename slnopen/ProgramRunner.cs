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

        public void OpenFileWithDefaultProgram(string file)
        {
            RunFileWithDefaultProgram(file, Verb.OPEN.ToString());
        }

        public void EditFileWithDefaultProgram(string file)
        {
            RunFileWithDefaultProgram(file, Verb.EDIT.ToString());
        }

        private void RunFileWithDefaultProgram(string file, string action)
        {
            var pi = new ProcessStartInfo(file)
            {
                Arguments = _fileSystem.Path.GetFileName(file),
                UseShellExecute = true,
                WorkingDirectory = _fileSystem.Path.GetDirectoryName(file),
                FileName = file,
                Verb = action
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
