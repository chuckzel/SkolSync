using System.Reflection;

namespace SkolSync.Core.Mapping;

public interface IMemberMap<TSource, TTarget>
{
    MemberInfo TargetMember { get; }

    IdentityStrength IdentityStrength { get; }

    bool ApplyOnCreate { get; }

    bool ApplyOnUpdate { get; }

    TReturn Apply<TReturn>(IMemberMapOperation<TSource, TTarget, TReturn> operation);
}
