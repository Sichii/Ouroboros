namespace Ouroboros.PInvoke
{
    public struct ProcessInformation
    {
        public nint ProcessHandle { get; set; }
        public nint ThreadHandle { get; set; }
        public int ProcessId { get; set; }
        public int ThreadId { get; set; }
    }
}