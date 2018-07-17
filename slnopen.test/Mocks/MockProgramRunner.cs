using System.Collections.Generic;

namespace slnopen.test
{
    public class MockProgramRunner : IProgramRunner
    {
        public IList<string> OpenedFiles { get; } = new List<string>();

        public IList<string> EditedFiles { get; } = new List<string>();

        public void EditFileWithDefaultProgram(string file)
        {
            EditedFiles.Add(file);
        }

        public void OpenFileWithDefaultProgram(string file)
        {
            OpenedFiles.Add(file);
        }
    }
}
