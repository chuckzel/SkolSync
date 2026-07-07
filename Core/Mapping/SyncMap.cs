using SkolSync.Core.Interfaces;

namespace SkolSync.Core.Mapping;

public sealed class SyncMap<TSource, TTarget>
{
    public required IReadOnlyList<IMemberMap<TSource, TTarget>> MemberMaps { get; init; }
    public required IReadConnector<TSource> SourceConnector { get; init; }
    public required IReadConnector<TTarget> TargetConnector { get; init; }
    public required IEnumerable<IWriteConnector<TTarget>> WriteConnectors { get; init; }
}
