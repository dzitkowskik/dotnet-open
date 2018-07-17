using System.Collections.Generic;

namespace slnopen.test
{
    public class MockProgramRunner : IProgramRunner
    {
        public IList<string> OpenedFiles { get; } = new List<string>();

        public IList<string> EditedFiles { get; } = new List<string>();

        public void OpenFileWithDefaultProgram(string file, bool editMode = false)
        {
            if (editMode)
                EditedFiles.Add(file);
            else
                OpenedFiles.Add(file);
        }
    }
}
