using SkolSync.Core.Mapping;

namespace SkolSync.Core.IdentityResolution;

public class GetMatchLookupOperation<TSource, TTarget>(IEnumerable<TTarget> targets)
    : IMemberMapOperation<TSource, TTarget, MatchLookup<TSource, TTarget>>
{
    readonly IEnumerable<TTarget> _targets = targets;
    public MatchLookup<TSource, TTarget> Apply<TMember>(MemberMap<TSource, TTarget, TMember> memberMap)
    {
        var lookup = _targets.ToLookup(target => memberMap.TargetGetter(target));

        return new MatchLookup<TSource, TTarget>
        {
            Lookup = s => lookup[memberMap.SourceGetter(s)],
            UnsetTargets = lookup[memberMap.UnsetValue].ToHashSet()
        };
    }
}
