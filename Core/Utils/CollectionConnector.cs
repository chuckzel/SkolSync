using System.Reflection;

using SkolSync.Core.Interfaces;
using SkolSync.Core.Reconciliation;

namespace SkolSync.Core.Utils;

class CollectionConnector<T>(ICollection<T> collection, Func<T> newItemFactory) : IReadConnector<T>, IWriteConnector<T>
{
    private readonly ICollection<T> _collection = collection;
    private readonly Func<T> _factory = newItemFactory;

    public IAsyncEnumerable<T> GetObjectsAsync(IEnumerable<MemberInfo> membersToQuery, CancellationToken cancellationToken = default)
        => _collection.ToAsyncEnumerable();

    public Task AddAsync(AddObjectChange<T> change, CancellationToken cancellationToken = default)
    {
        T obj = _factory();

        _collection.Add(obj);
        return Task.CompletedTask;
    }

    public Task ModifyAsync(UpdateObjectChange<T> change, CancellationToken cancellationToken = default)
    {
        return Task.CompletedTask;
    }

    public Task RemoveAsync(RemoveObjectChange<T> change, CancellationToken cancellationToken = default)
    {
        _collection.Remove(change.Target);
        return Task.CompletedTask;
    }
}
