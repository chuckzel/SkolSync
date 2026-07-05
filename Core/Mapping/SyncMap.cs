namespace SkolSync.Core.Mapping;

public sealed class SyncMap<TSource, TTarget>
{
    internal SyncMap(IEnumerable<IMemberMap<TSource, TTarget>> memberMaps)
    {
        MemberMaps = [.. memberMaps];
    }

    public IReadOnlyList<IMemberMap<TSource, TTarget>> MemberMaps { get; }
}
