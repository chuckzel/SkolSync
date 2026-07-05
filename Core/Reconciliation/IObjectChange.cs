namespace SkolSync.Core.Reconciliation;

public interface IObjectChange<TTarget>
{
}

public abstract record ObjectChange<TSource, TTarget> : IObjectChange<TTarget>
{
    public required TTarget Target { get; init; }
}

public record AddObjectChange<TSource, TTarget> : ObjectChange<TSource, TTarget>
{
    public required IReadOnlyCollection<IMemberChange> MemberChanges { get; init; }
}

public record UpdateObjectChange<TSource, TTarget> : ObjectChange<TSource, TTarget>
{
    public required IReadOnlyCollection<IMemberChange> MemberChanges { get; init; }
}

public record RemoveObjectChange<TSource, TTarget> : ObjectChange<TSource, TTarget>
{
}
