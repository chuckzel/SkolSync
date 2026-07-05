namespace SkolSync.Core.Mapping;

public interface IMemberChange
{
    string MemberName { get; }
}

public sealed record MemberChange<TMember>(
    string MemberName,
    TMember? CurrentValue,
    TMember DesiredValue) : IMemberChange;
