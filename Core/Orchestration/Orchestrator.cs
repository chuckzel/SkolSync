using SkolSync.Core.IdentityResolution;
using SkolSync.Core.Mapping;
using SkolSync.Core.Provisioning;
using SkolSync.Core.Reconciliation;

namespace SkolSync.Core.Orchestration;

public class Orchestrator<TSource, TTarget>(SyncDefinition<TSource, TTarget> syncDef)
{
    private readonly SyncDefinition<TSource, TTarget> _syncDef = syncDef;


    public async Task ExecuteAsync(CancellationToken cancellationToken = default)
    {
        var sources = await _syncDef.SourceConnector.GetObjectsAsync([], cancellationToken).ToListAsync(cancellationToken);
        var targets = await _syncDef.TargetConnector.GetObjectsAsync([], cancellationToken).ToListAsync(cancellationToken);

        IdentityResolver<TSource, TTarget> identityResolver = new(_syncDef.Map);
        var resolvedMatches = identityResolver.Resolve(sources, targets);

        Reconciler<TSource, TTarget> reconciler = new(_syncDef.Map);
        var changes = reconciler.Reconcile(resolvedMatches);

        foreach (var writeConnector in _syncDef.WriteConnectors)
        {
            Provisioner<TTarget> provisioner = new(writeConnector);
            await provisioner.ProvisionAsync(changes, cancellationToken);
        }
    }
}
