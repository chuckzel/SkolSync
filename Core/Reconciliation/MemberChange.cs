namespace SkolSync.Core.Reconciliation;

public interface IMemberChange<TTarget>
{
    string MemberName { get; }
}

public sealed record MemberChange<TSource, TTarget, TMember>(
    string MemberName,
    TMember? CurrentValue,
    TMember DesiredValue) : IMemberChange<TTarget>;
