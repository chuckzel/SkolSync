using SkolSync.Core.Mapping;

namespace SkolSync.Core.IdentityResolution;


public class IdentityResolver<TSource, TTarget>(ObjectMap<TSource, TTarget> objectMap)
{
    private readonly IReadOnlyList<IMemberMap<TSource, TTarget>> _identityMaps = [.. objectMap.MemberMaps.Where(m => m.IdentityStrength != IdentityStrength.None)];

    public IEnumerable<(TSource? Source, TTarget? Target)> Resolve(IEnumerable<TSource> sources, IEnumerable<TTarget> targets)
    {
        HashSet<TTarget> unmatchedTargets = [.. targets];
        IList<MatchLookup<TSource, TTarget>> lookups = [];
        foreach (var memberMap in _identityMaps)
        {
            GetMatchLookupOperation<TSource, TTarget> matchOperation = new(targets);
            var lookup = memberMap.Apply(matchOperation);
            lookups.Add(lookup);
            targets = lookup.UnsetTargets;
        }

        foreach (var source in sources)
        {
            var matchedTargetGroup = lookups.Select(l => l.Lookup(source)).FirstOrDefault(t => t.Any());
            if (matchedTargetGroup is null)
            {
                yield return (source, default);
                continue;
            }
            var target = matchedTargetGroup.Single();
            unmatchedTargets.Remove(target);
            yield return (source, target);
        }
        foreach (var unmatchedTarget in unmatchedTargets)
        {
            yield return (default, unmatchedTarget);
        }
    }
}
