namespace Slnopen
{
    using System.Diagnostics;

    /// <summary>
    /// Proxy for Process.
    /// </summary>
    internal interface IProcessProxy
    {
        /// <summary>
        /// Starts the process.
        /// </summary>
        /// <param name="pi">The process start information.</param>
        void StartProcess(ProcessStartInfo pi);
    }
}