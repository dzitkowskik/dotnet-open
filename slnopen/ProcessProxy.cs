using System.Diagnostics;

namespace slnopen
{
    internal class ProcessProxy : IProcessProxy
    {
        public void StartProcess(ProcessStartInfo pi)
        {
            Process.Start(pi);
        }
    }
}
