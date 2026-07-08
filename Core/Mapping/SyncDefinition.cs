using SkolSync.Core.Interfaces;

namespace SkolSync.Core.Mapping;

public class SyncDefinition<TSource, TTarget>
{
    public required ObjectMap<TSource, TTarget> Map { get; init; }
    public required IReadConnector<TSource> SourceConnector { get; init; }
    public required IReadConnector<TTarget> TargetConnector { get; init; }
    public required IEnumerable<IWriteConnector<TTarget>> WriteConnectors { get; init; }
}
