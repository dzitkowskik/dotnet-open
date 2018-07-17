using System.Diagnostics;

namespace slnopen.test
{
    internal class MockProcessProxy : IProcessProxy
    {
        public ProcessStartInfo LastPassedProcessStartInfo { get; private set; }

        public void StartProcess(ProcessStartInfo pi)
        {
            LastPassedProcessStartInfo = pi;
        }
    }
}
