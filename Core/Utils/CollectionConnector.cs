using System.Reflection;

using SkolSync.Core.Interfaces;
using SkolSync.Core.Reconciliation;

namespace SkolSync.Core.Utils;

public class CollectionConnector<T>(ICollection<T> collection, Func<T> newItemFactory) : IReadConnector<T>, IWriteConnector<T>
{
    private readonly Func<T> _factory = newItemFactory;

    public ICollection<T> Collection { get; } = collection;

    public IAsyncEnumerable<T> GetObjectsAsync(IEnumerable<MemberInfo> membersToQuery, CancellationToken cancellationToken = default)
        => Collection.ToAsyncEnumerable();

    public Task AddAsync(AddObjectChange<T> change, CancellationToken cancellationToken = default)
    {
        T obj = _factory();
        change.SetMembers(obj);
        Collection.Add(obj);
        return Task.CompletedTask;
    }

    public Task ModifyAsync(UpdateObjectChange<T> change, CancellationToken cancellationToken = default)
    {
        change.UpdateMembers();
        return Task.CompletedTask;
    }

    public Task RemoveAsync(RemoveObjectChange<T> change, CancellationToken cancellationToken = default)
    {
        Collection.Remove(change.Target);
        return Task.CompletedTask;
    }
}
