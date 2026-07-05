using SkolSync.Core.Mapping;

namespace SkolSync.Core.Reconciliation;

public class Reconciler<TSource, TTarget>
{
    public SyncMap<TSource, TTarget> SyncMap { get; }
    private readonly IReadOnlyList<IMemberMap<TSource, TTarget>> createMemberMaps;
    private readonly IReadOnlyList<IMemberMap<TSource, TTarget>> updateMemberMaps;
    public Reconciler(SyncMap<TSource, TTarget> syncMap)
    {
        SyncMap = syncMap;
        createMemberMaps = [.. syncMap.MemberMaps.Where(m => m.ApplyOnCreate)];
        updateMemberMaps = [.. syncMap.MemberMaps.Where(m => m.ApplyOnUpdate)];
    }
    public IObjectChange<TTarget>? Reconcile(TSource? source, TTarget? target)
    {
        if (source is null)
        {
            return target is null
                ? null
                : new RemoveObjectChange<TSource, TTarget> { Target = target };
        }

        var memberMaps = target is null ? createMemberMaps : updateMemberMaps;
        CompareOperation<TSource, TTarget> compareOperation = new(source, target);
        IReadOnlyList<IMemberChange> memberChanges = [.. memberMaps
            .Select(m => m.Apply(compareOperation))
            .OfType<IMemberChange>()];

        return memberChanges.Count > 0
            ? target is null
                ? new AddObjectChange<TSource, TTarget> { Target = default!, MemberChanges = memberChanges }
                : new UpdateObjectChange<TSource, TTarget> { Target = target, MemberChanges = memberChanges }
            : null;
    }

    public IEnumerable<IObjectChange<TTarget>> Reconcile(IEnumerable<(TSource? Source, TTarget? Target)> pairs)
    {
        foreach (var (source, target) in pairs)
        {
            var change = Reconcile(source, target);
            if (change != null)
            {
                yield return change;
            }
        }
    }
}
