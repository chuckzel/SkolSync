using SkolSync.Core.Reconciliation;

namespace SkolSync.Core.Interfaces;

public interface IWriteConnector<T>
{
    Task AddAsync(AddObjectChange<T> obj, CancellationToken cancellationToken = default);
    Task RemoveAsync(RemoveObjectChange<T> obj, CancellationToken cancellationToken = default);
    Task ModifyAsync(UpdateObjectChange<T> obj, CancellationToken cancellationToken = default);
}
