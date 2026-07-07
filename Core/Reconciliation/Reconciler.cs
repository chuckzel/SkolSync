using SkolSync.Core.Mapping;

namespace SkolSync.Core.Reconciliation;

public class Reconciler<TSource, TTarget>
{
    public SyncMap<TSource, TTarget> SyncMap { get; }
    private readonly IReadOnlyList<IMemberMap<TSource, TTarget>> _createMemberMaps;
    private readonly IReadOnlyList<IMemberMap<TSource, TTarget>> _updateMemberMaps;
    public Reconciler(SyncMap<TSource, TTarget> syncMap)
    {
        SyncMap = syncMap;
        _createMemberMaps = [.. syncMap.MemberMaps.Where(m => m.ApplyOnCreate)];
        _updateMemberMaps = [.. syncMap.MemberMaps.Where(m => m.ApplyOnUpdate)];
    }
    public IObjectChange<TTarget>? Reconcile(TSource? source, TTarget? target)
    {
        if (source is null)
        {
            return target is null
                ? null
                : new RemoveObjectChange<TTarget> { Target = target };
        }

        var memberMaps = target is null ? _createMemberMaps : _updateMemberMaps;
        CompareOperation<TSource, TTarget> compareOperation = new(source, target);
        IReadOnlyList<IMemberChange<TTarget>> memberChanges = [.. memberMaps
            .Select(m => m.Apply(compareOperation))
            .OfType<IMemberChange<TTarget>>()];

        return memberChanges.Count > 0
            ? target is null
                ? new AddObjectChange<TTarget> { MemberChanges = memberChanges }
                : new UpdateObjectChange<TTarget> { Target = target, MemberChanges = memberChanges }
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
