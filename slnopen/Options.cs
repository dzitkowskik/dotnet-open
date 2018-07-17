using CommandLine;

namespace slnopen
{
    internal class Options
    {
        [Value(0, HelpText = "Extension of file to open", Required = false)]
        public string Extension { get; set; }

        [Option('f', "file", HelpText = "Selected file to open", Required = false)]
        public string SelectedFile { get; set; }

        [Option('e', "edit", Default = false, HelpText = "Edit sln file")]
        public bool EditMode { get; set; }
    }
}