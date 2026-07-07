using SkolSync.Core.Interfaces;
using SkolSync.Core.Reconciliation;

namespace SkolSync.Core.Provisioning;

public class Provisioner<TTarget>(IWriteConnector<TTarget> writeConnector)
{
    private readonly IWriteConnector<TTarget> _writeConnector = writeConnector;

    public async Task ProvisionAsync(IEnumerable<IObjectChange<TTarget>> changes, CancellationToken cancellationToken = default)
    {
        foreach (var change in changes)
        {
            switch (change)
            {
                case AddObjectChange<TTarget> addChange:
                    await _writeConnector.AddAsync(addChange, cancellationToken);
                    break;
                case RemoveObjectChange<TTarget> removeChange:
                    await _writeConnector.RemoveAsync(removeChange, cancellationToken);
                    break;
                case UpdateObjectChange<TTarget> updateChange:
                    await _writeConnector.ModifyAsync(updateChange, cancellationToken);
                    break;
                default:
                    throw new InvalidOperationException($"Unsupported change type: {change.GetType().Name}");
            }
        }
    }
}
