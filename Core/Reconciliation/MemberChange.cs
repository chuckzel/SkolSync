using SkolSync.Core.Mapping;

namespace SkolSync.Core.Reconciliation;

public interface IMemberChange<TTarget>
{
    void Apply(TTarget target);
}

public sealed record MemberChange<TSource, TTarget, TMember>(
    MemberMap<TSource, TTarget, TMember> MemberMap,
    TMember? CurrentValue,
    TMember DesiredValue) : IMemberChange<TTarget>
{
    public void Apply(TTarget target)
    {
        MemberMap.TargetSetter(target, DesiredValue);
    }
}
