namespace SkolSync.Core.Reconciliation;

public interface IObjectChange<TTarget>
{
}

public abstract record ObjectChange<TTarget> : IObjectChange<TTarget>
{
}

public record AddObjectChange<TTarget> : ObjectChange<TTarget>
{
    public required IReadOnlyCollection<IMemberChange<TTarget>> MemberChanges { get; init; }
}

public record UpdateObjectChange<TTarget> : ObjectChange<TTarget>
{
    public required TTarget Target { get; init; }
    public required IReadOnlyCollection<IMemberChange<TTarget>> MemberChanges { get; init; }
}

public record RemoveObjectChange<TTarget> : ObjectChange<TTarget>
{
    public required TTarget Target { get; init; }
}
