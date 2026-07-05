using System.Linq.Expressions;
using System.Reflection;

namespace SkolSync.Core.Mapping;

public sealed class MemberMap<TSource, TTarget, TMember> : IMemberMap<TSource, TTarget>
{
    public MemberMap(
        Func<TSource, TMember> sourceGetter,
        Expression<Func<TTarget, TMember>> targetExpression)
    {
        SourceGetter = sourceGetter;
        TargetExpression = targetExpression;
        TargetGetter = TargetExpression.Compile();

        TargetMember = GetTargetMemberInfo(TargetExpression);
        TargetSetter = CreateTargetSetter(TargetMember);
    }

    public Expression<Func<TTarget, TMember>> TargetExpression { get; }

    public Func<TSource, TMember> SourceGetter { get; }

    public Func<TTarget, TMember> TargetGetter { get; }

    public Action<TTarget, TMember> TargetSetter { get; }

    public MemberInfo TargetMember { get; }

    public IdentityStrength IdentityStrength { get; internal set; } = IdentityStrength.None;

    public bool ApplyOnCreate { get; internal set; } = true;

    public bool ApplyOnUpdate { get; internal set; } = true;

    private static MemberInfo GetTargetMemberInfo(Expression<Func<TTarget, TMember>> targetExpression)
    {
        Expression body = targetExpression.Body;
        if (body is UnaryExpression unaryExpression && unaryExpression.NodeType == ExpressionType.Convert)
        {
            body = unaryExpression.Operand;
        }

        if (body is not MemberExpression memberExpression)
        {
            throw new ArgumentException("The target expression must select a field or property.", nameof(targetExpression));
        }

        if (memberExpression.Member is not FieldInfo and not PropertyInfo)
        {
            throw new ArgumentException("The target expression must select a field or property.", nameof(targetExpression));
        }

        return memberExpression.Member;
    }

    private static Action<TTarget, TMember> CreateTargetSetter(MemberInfo targetMember)
    {
        return targetMember switch
        {
            FieldInfo fieldInfo when !fieldInfo.IsInitOnly && !fieldInfo.IsLiteral =>
                (target, value) => fieldInfo.SetValue(target, value),
            PropertyInfo propertyInfo when propertyInfo.CanWrite =>
                (target, value) => propertyInfo.SetValue(target, value),
            _ => throw new ArgumentException("The target member must be writable.", nameof(targetMember)),
        };
    }

    public TReturn Apply<TReturn>(IMemberMapOperation<TSource, TTarget, TReturn> operation)
        => operation.Apply(this);
}