using SkolSync.Core.Mapping;

namespace SkolSync.Core.Reconciliation;

public record struct CompareOperation<TSource, TTarget>(TSource Source, TTarget? Target) : IMemberMapOperation<TSource, TTarget, IMemberChange?>
{
    public IMemberChange? Apply<TMember>(MemberMap<TSource, TTarget, TMember> memberMap)
    {
        TMember sourceValue = memberMap.SourceGetter(Source);
        TMember? targetValue = Target is not null ? memberMap.TargetGetter(Target) : default;

        return !EqualityComparer<TMember>.Default.Equals(sourceValue, targetValue)
            ? new MemberChange<TMember>(
                memberMap.TargetMember.Name,
                targetValue,
                sourceValue)
            : null;
    }
}
