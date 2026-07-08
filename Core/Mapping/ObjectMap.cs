namespace SkolSync.Core.Mapping;

public sealed class ObjectMap<TSource, TTarget>
{
    public required IReadOnlyList<IMemberMap<TSource, TTarget>> MemberMaps { get; init; }
}
