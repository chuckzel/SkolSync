namespace SkolSync.Core.Mapping;

public sealed class SyncContext<TSource, TTarget>
{
    public SyncContext(SyncOperation operation, bool isDryRun = false)
    {
        Operation = operation;
        IsDryRun = isDryRun;
    }

    public SyncOperation Operation { get; }

    public bool IsDryRun { get; }
}