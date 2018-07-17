namespace slnopen
{
    internal interface IProgramRunner
    {
        void OpenFileWithDefaultProgram(string file, bool editMode = false);
    }
}