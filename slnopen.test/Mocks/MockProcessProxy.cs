namespace Slnopen.Test
{
    using System.Diagnostics;

    internal class MockProcessProxy : IProcessProxy
    {
        public ProcessStartInfo LastPassedProcessStartInfo { get; private set; }

        public void StartProcess(ProcessStartInfo pi)
        {
            this.LastPassedProcessStartInfo = pi;
        }
    }
}
