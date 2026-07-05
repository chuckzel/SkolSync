namespace SkolSync.Core.Mapping;

public interface IMemberMapOperation<TSource, TTarget, TReturn>
{
    TReturn Apply<TMember>(MemberMap<TSource, TTarget, TMember> memberMap);
}
