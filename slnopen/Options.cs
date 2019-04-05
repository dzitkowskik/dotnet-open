namespace Slnopen
{
    using CommandLine;

    /// <summary>
    /// Options for the program.
    /// </summary>
    internal class Options
    {
        /// <summary>
        /// Gets or sets the extension of files to select.
        /// </summary>
        /// <value>
        /// The extension.
        /// </value>
        [Value(0, HelpText = "Extension of file to open", Required = false)]
        public string Extension { get; set; }

        /// <summary>
        /// Gets or sets the selected file.
        /// </summary>
        /// <value>
        /// The selected file.
        /// </value>
        [Option('f', "file", HelpText = "Selected file to open", Required = false)]
        public string SelectedFile { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether edit mode is on.
        /// </summary>
        /// <value>
        ///   <c>true</c> if edit mode is on; otherwise, <c>false</c>.
        /// </value>
        [Option('e', "edit", Default = false, HelpText = "Edit sln file")]
        public bool EditMode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether admin mode is on.
        /// </summary>
        /// <value>
        ///   <c>true</c> if admin mode is on; otherwise, <c>false</c>.
        /// </value>
        [Option('a', "admin", Default = false, HelpText = "Open in admin mode")]
        public bool AdminMode { get; set; }
    }
}