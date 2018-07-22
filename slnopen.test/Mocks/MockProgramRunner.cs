namespace Slnopen.Test
{
    using System.Collections.Generic;

    public class MockProgramRunner : IProgramRunner
    {
        public IList<string> OpenedFiles { get; } = new List<string>();

        public IList<string> EditedFiles { get; } = new List<string>();

        public void OpenFileWithDefaultProgram(string file, bool editMode = false)
        {
            if (editMode)
            {
                this.EditedFiles.Add(file);
            }
            else
            {
                this.OpenedFiles.Add(file);
            }
        }
    }
}
