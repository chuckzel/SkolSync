using System.Linq.Expressions;

namespace SkolSync.Core.Mapping;

public sealed class SyncMapBuilder<TSource, TTarget>
{
    private readonly List<IMemberMap<TSource, TTarget>> _memberMaps = new();

    public MemberMapBuilder<TSource, TTarget, TMember> Map<TMember>(
        Func<TSource, TMember> sourceGetter,
        Expression<Func<TTarget, TMember>> targetExpression)
    {
        MemberMap<TSource, TTarget, TMember> memberMap = new(sourceGetter, targetExpression);
        _memberMaps.Add(memberMap);

        return new MemberMapBuilder<TSource, TTarget, TMember>(memberMap);
    }

    public SyncMap<TSource, TTarget> Build()
    {
        return new SyncMap<TSource, TTarget>(_memberMaps);
    }
}

public sealed class MemberMapBuilder<TSource, TTarget, TMember>
{
    private readonly MemberMap<TSource, TTarget, TMember> _memberMap;

    internal MemberMapBuilder(MemberMap<TSource, TTarget, TMember> memberMap)
    {
        _memberMap = memberMap;
    }

    public MemberMapBuilder<TSource, TTarget, TMember> AsStrongIdentity()
    {
        _memberMap.IdentityStrength = IdentityStrength.Strong;
        return this;
    }

    public MemberMapBuilder<TSource, TTarget, TMember> AsWeakIdentity()
    {
        _memberMap.IdentityStrength = IdentityStrength.Weak;
        return this;
    }

    public MemberMapBuilder<TSource, TTarget, TMember> ApplyOnCreate(bool apply = true)
    {
        _memberMap.ApplyOnCreate = apply;
        return this;
    }

    public MemberMapBuilder<TSource, TTarget, TMember> ApplyOnUpdate(bool apply = true)
    {
        _memberMap.ApplyOnUpdate = apply;
        return this;
    }
}
