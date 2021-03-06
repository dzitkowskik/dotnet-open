﻿namespace Slnopen
{
    using System;
    using System.Collections.Generic;
    using System.IO.Abstractions;
    using CommandLine;

    /// <summary>
    /// The main program class.
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(opt => GetOpener().Open(opt))
                .WithNotParsed(errors => Error(errors));
        }

        private static ExtensionOpener GetOpener()
        {
            var fs = new FileSystem();
            var opener = new ExtensionOpener(new ProgramRunner(new ProcessProxy(), fs), fs);
            return opener;
        }

        private static void Error(IEnumerable<Error> errors)
        {
            foreach (var error in errors)
            {
                Console.WriteLine(error);
            }
        }
    }
}
