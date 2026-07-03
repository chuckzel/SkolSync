using System.Linq.Expressions;
using System.Reflection;

namespace SkolSync.Core.Mapping;

public enum IdentityStrength
{
    None = 0,
    Weak = 1,
    Strong = 2,
}

public enum MemberChangeKind
{
    NoChange = 0,
    Create = 1,
    Update = 2,
}

public interface IMemberChange
{
    string MemberName { get; }

    MemberChangeKind Kind { get; }

    object? TargetValue { get; }

    object? DesiredValue { get; }

    bool HasChange { get; }
}

public sealed record MemberChange<TMember>(
    string MemberName,
    MemberChangeKind Kind,
    TMember? CurrentValue,
    TMember DesiredValue) : IMemberChange
{
    public bool HasChange => Kind != MemberChangeKind.NoChange;

    object? IMemberChange.TargetValue => CurrentValue;

    object? IMemberChange.DesiredValue => DesiredValue;
}

public interface IMemberMap<TSource, TTarget>
{
    MemberInfo TargetMember { get; }

    IdentityStrength IdentityStrength { get; }

    bool ApplyOnCreate { get; }

    bool ApplyOnUpdate { get; }

    IMemberChange Compare(TSource source, TTarget target, SyncOperation operation);

    void Apply(TSource source, TTarget target);
}

public sealed class MemberMap<TSource, TTarget, TMember> : IMemberMap<TSource, TTarget>
{
    public MemberMap(
        Func<TSource, TMember> sourceGetter,
        Expression<Func<TTarget, TMember>> targetExpression)
    {
        SourceGetter = sourceGetter;
        TargetExpression = targetExpression;

        TargetGetter = TargetExpression.Compile();

        TargetMemberInfo = GetTargetMemberInfo(TargetExpression);
        TargetSetter = CreateTargetSetter(TargetMemberInfo);
    }

    public Expression<Func<TTarget, TMember>> TargetExpression { get; }

    public Func<TSource, TMember> SourceGetter { get; }

    public Func<TTarget, TMember> TargetGetter { get; }

    public Action<TTarget, TMember> TargetSetter { get; }

    public MemberInfo TargetMemberInfo { get; }

    public IdentityStrength IdentityStrength { get; internal set; } = IdentityStrength.None;

    public bool ApplyOnCreate { get; internal set; } = true;

    public bool ApplyOnUpdate { get; internal set; } = true;

    public Func<SyncContext<TSource, TTarget>, bool>? Condition { get; internal set; }

    MemberInfo IMemberMap<TSource, TTarget>.TargetMember => TargetMemberInfo;

    IdentityStrength IMemberMap<TSource, TTarget>.IdentityStrength => IdentityStrength;

    bool IMemberMap<TSource, TTarget>.ApplyOnCreate => ApplyOnCreate;

    bool IMemberMap<TSource, TTarget>.ApplyOnUpdate => ApplyOnUpdate;

    public IMemberChange Compare(TSource source, TTarget target, SyncOperation operation)
    {
        TMember sourceValue = SourceGetter(source);
        TMember targetValue = TargetGetter(target);

        if (!EqualityComparer<TMember>.Default.Equals(sourceValue, targetValue))
        {
            return new MemberChange<TMember>(
                TargetMemberInfo.Name,
                operation == SyncOperation.Create ? MemberChangeKind.Create : MemberChangeKind.Update,
                targetValue,
                sourceValue);
        }

        return new MemberChange<TMember>(
            TargetMemberInfo.Name,
            MemberChangeKind.NoChange,
            targetValue,
            sourceValue);
    }

    public void Apply(TSource source, TTarget target) => TargetSetter(target, SourceGetter(source));

    public bool CanApply(SyncContext<TSource, TTarget> context)
    {
        return context.Operation switch
        {
            SyncOperation.Create => ApplyOnCreate,
            SyncOperation.Update => ApplyOnUpdate,
            _ => false,
        } && (Condition is null || Condition(context));
    }

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
}