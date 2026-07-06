namespace SkolSync.Core.IdentityResolution;

public class MatchLookup<TSource, TTarget>
{
    public required Func<TSource, IEnumerable<TTarget>> Lookup { get; init; }
    public required ICollection<TTarget> UnsetTargets { get; init; }
}
