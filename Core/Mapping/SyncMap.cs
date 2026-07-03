namespace SkolSync.Core.Mapping;

public sealed class SyncMap<TSource, TTarget>
{
    internal SyncMap(IEnumerable<IMemberMap<TSource, TTarget>> memberMaps)
    {
        MemberMaps = [.. memberMaps];
    }

    public IReadOnlyList<IMemberMap<TSource, TTarget>> MemberMaps { get; }

    public IReadOnlyList<IMemberMap<TSource, TTarget>> IdentityMaps => MemberMaps.Where(memberMap => memberMap.IdentityStrength != IdentityStrength.None).ToArray();

    public IReadOnlyList<IMemberMap<TSource, TTarget>> StrongIdentityMaps => MemberMaps.Where(memberMap => memberMap.IdentityStrength == IdentityStrength.Strong).ToArray();

    public IReadOnlyList<IMemberMap<TSource, TTarget>> WeakIdentityMaps => MemberMaps.Where(memberMap => memberMap.IdentityStrength == IdentityStrength.Weak).ToArray();
}