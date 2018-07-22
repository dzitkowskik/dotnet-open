namespace Slnopen
{
    using System.Diagnostics;

    /// <summary>
    /// Simple procy class for Process.
    /// </summary>
    /// <seealso cref="Slnopen.IProcessProxy" />
    internal class ProcessProxy : IProcessProxy
    {
        /// <summary>
        /// Starts the process.
        /// </summary>
        /// <param name="pi">The process start info.</param>
        public void StartProcess(ProcessStartInfo pi)
        {
            Process.Start(pi);
        }
    }
}
