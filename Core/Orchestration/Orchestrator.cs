using SkolSync.Core.IdentityResolution;
using SkolSync.Core.Mapping;
using SkolSync.Core.Provisioning;
using SkolSync.Core.Reconciliation;

namespace SkolSync.Core.Orchestration;

public class Orchestrator<TSource, TTarget>(SyncMap<TSource, TTarget> syncMap)
{
    private readonly SyncMap<TSource, TTarget> _syncMap = syncMap;


    public async Task ExecuteAsync(CancellationToken cancellationToken = default)
    {
        var sources = await _syncMap.SourceConnector.GetObjectsAsync([], cancellationToken).ToListAsync(cancellationToken);
        var targets = await _syncMap.TargetConnector.GetObjectsAsync([], cancellationToken).ToListAsync(cancellationToken);

        IdentityResolver<TSource, TTarget> identityResolver = new(_syncMap);
        var resolvedMatches = identityResolver.Resolve(sources, targets);

        Reconciler<TSource, TTarget> reconciler = new(_syncMap);
        var changes = reconciler.Reconcile(resolvedMatches);

        foreach (var writeConnector in _syncMap.WriteConnectors)
        {
            Provisioner<TTarget> provisioner = new(writeConnector);
            await provisioner.ProvisionAsync(changes, cancellationToken);
        }
    }
}
