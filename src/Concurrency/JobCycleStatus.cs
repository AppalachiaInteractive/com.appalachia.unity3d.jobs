namespace Appalachia.Core.Concurrency
{
    public enum JobCycleStatus : byte
    {
        Inactive = 0,
        Active = 10,
        Completed = 20,
        Delayed = 90
    }
}
