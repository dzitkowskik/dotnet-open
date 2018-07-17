namespace slnopen
{
    internal interface IProgramRunner
    {
        void OpenFileWithDefaultProgram(string file);

        void EditFileWithDefaultProgram(string file);
    }
}