using SkolSync.Core.Mapping;
using SkolSync.Core.Orchestration;
using SkolSync.Core.Tests.TestModels;
using SkolSync.Core.Utils;

namespace SkolSync.Core.Tests.Orchestration;

public class OrchestratorTests
{
    [Test]
    public async Task Execute_WithSyncedTarget_RemainsUnchanged()
    {
        var syncMap = BasicModel.Map;
        List<BasicModel.Source> sourceItems = [
            new BasicModel.Source(1, "John", "Doe"),
            new BasicModel.Source(2, "Jane", "Smith")
        ];
        List<BasicModel.Target> targetItems = [
            new BasicModel.Target("1", "john.doe@example.com", "passJohn1"),
            new BasicModel.Target("2", "jane.smith@example.com", "passJane2")
        ];
        CollectionConnector<BasicModel.Source> source = new([.. sourceItems], () => throw new NotImplementedException("bad api, will not get called")); //TODO: fix, separate read and write connectors
        CollectionConnector<BasicModel.Target> target = new([.. targetItems], () => new("", "", ""));
        SyncDefinition<BasicModel.Source, BasicModel.Target> syncDef = new()
        {
            Map = syncMap,
            SourceConnector = source,
            TargetConnector = target,
            WriteConnectors = [target]
        };

        Orchestrator<BasicModel.Source, BasicModel.Target> orchestrator = new(syncDef);
        await orchestrator.ExecuteAsync();

        await Assert.That(target.Collection).IsEquivalentTo(targetItems);
    }

    [Test]
    public async Task Execute_WithEmptyTargetCollection_AddsItems()
    {
        var syncMap = BasicModel.Map;
        List<BasicModel.Source> sourceItems = [
            new BasicModel.Source(1, "John", "Doe"),
            new BasicModel.Source(2, "Jane", "Smith")
        ];
        List<BasicModel.Target> targetItems = [];
        CollectionConnector<BasicModel.Source> source = new([.. sourceItems], () => throw new NotImplementedException("bad api, will not get called")); //TODO: fix, separate read and write connectors
        CollectionConnector<BasicModel.Target> target = new([.. targetItems], () => new("", "", "defaultPassword"));
        SyncDefinition<BasicModel.Source, BasicModel.Target> syncDef = new()
        {
            Map = syncMap,
            SourceConnector = source,
            TargetConnector = target,
            WriteConnectors = [target]
        };

        Orchestrator<BasicModel.Source, BasicModel.Target> orchestrator = new(syncDef);
        await orchestrator.ExecuteAsync();

        await Assert.That(target.Collection).IsEquivalentTo([
            new BasicModel.Target("1", "john.doe@example.com", "passJohn1"),
            new BasicModel.Target("2", "jane.smith@example.com", "passJane2")
        ]);
    }

    [Test]
    public async Task Execute_WithModifiedTargetCollection_UpdatesItems()
    {
        var syncMap = BasicModel.Map;
        List<BasicModel.Source> sourceItems = [
            new BasicModel.Source(1, "John", "Doe"),
            new BasicModel.Source(2, "Jane", "Smith")
        ];
        List<BasicModel.Target> targetItems = [
            new BasicModel.Target("1", "doe.john@oldDomain.com", "passJohn1"),
            new BasicModel.Target("2", "smith.jane@oldDomain.com", "passJane2")
        ];
        CollectionConnector<BasicModel.Source> source = new([.. sourceItems], () => throw new NotImplementedException("bad api, will not get called")); //TODO: fix, separate read and write connectors
        CollectionConnector<BasicModel.Target> target = new([.. targetItems], () => new("", "", "defaultPassword"));
        SyncDefinition<BasicModel.Source, BasicModel.Target> syncDef = new()
        {
            Map = syncMap,
            SourceConnector = source,
            TargetConnector = target,
            WriteConnectors = [target]
        };

        Orchestrator<BasicModel.Source, BasicModel.Target> orchestrator = new(syncDef);
        await orchestrator.ExecuteAsync();

        await Assert.That(target.Collection).IsEquivalentTo([
            new BasicModel.Target("1", "john.doe@example.com", "passJohn1"),
            new BasicModel.Target("2", "jane.smith@example.com", "passJane2")
        ]);
    }

    [Test]
    public async Task Execute_WithModifiedMapOnUpdateFalseMember_RemainsUnchanged()
    {
        var syncMap = BasicModel.Map;
        List<BasicModel.Source> sourceItems = [
            new BasicModel.Source(1, "John", "Doe"),
            new BasicModel.Source(2, "Jane", "Smith")
        ];
        List<BasicModel.Target> targetItems = [
            new BasicModel.Target("1", "john.doe@example.com", "oldPassJohn1"),
            new BasicModel.Target("2", "jane.smith@example.com", "oldPassJane2")
        ];
        CollectionConnector<BasicModel.Source> source = new([.. sourceItems], () => throw new NotImplementedException("bad api, will not get called")); //TODO: fix, separate read and write connectors
        CollectionConnector<BasicModel.Target> target = new([.. targetItems], () => new("", "", "defaultPassword"));
        SyncDefinition<BasicModel.Source, BasicModel.Target> syncDef = new()
        {
            Map = syncMap,
            SourceConnector = source,
            TargetConnector = target,
            WriteConnectors = [target]
        };

        Orchestrator<BasicModel.Source, BasicModel.Target> orchestrator = new(syncDef);
        await orchestrator.ExecuteAsync();

        await Assert.That(target.Collection).IsEquivalentTo(targetItems);
    }

    [Test]
    public async Task Execute_WithEmptySourceCollection_RemovesAllItems()
    {
        var syncMap = BasicModel.Map;
        List<BasicModel.Source> sourceItems = [];
        List<BasicModel.Target> targetItems = [
            new BasicModel.Target("1", "john.doe@example.com", "passJohn1"),
            new BasicModel.Target("2", "jane.smith@example.com", "passJane2")
        ];
        CollectionConnector<BasicModel.Source> source = new([.. sourceItems], () => throw new NotImplementedException("bad api, will not get called")); //TODO: fix, separate read and write connectors
        CollectionConnector<BasicModel.Target> target = new([.. targetItems], () => new("", "", "defaultPassword"));
        SyncDefinition<BasicModel.Source, BasicModel.Target> syncDef = new()
        {
            Map = syncMap,
            SourceConnector = source,
            TargetConnector = target,
            WriteConnectors = [target]
        };

        Orchestrator<BasicModel.Source, BasicModel.Target> orchestrator = new(syncDef);
        await orchestrator.ExecuteAsync();

        await Assert.That(target.Collection).IsEmpty();
    }

    [Test]
    public async Task Execute_WithExtraTargetItem_RemovesItem()
    {
        var syncMap = BasicModel.Map;
        List<BasicModel.Source> sourceItems = [
            new BasicModel.Source(1, "John", "Doe"),
        ];
        List<BasicModel.Target> targetItems = [
            new BasicModel.Target("1", "john.doe@example.com", "passJohn1"),
            new BasicModel.Target("2", "jane.smith@example.com", "passJane2")
        ];
        CollectionConnector<BasicModel.Source> source = new([.. sourceItems], () => throw new NotImplementedException("bad api, will not get called")); //TODO: fix, separate read and write connectors
        CollectionConnector<BasicModel.Target> target = new([.. targetItems], () => new("", "", "defaultPassword"));
        SyncDefinition<BasicModel.Source, BasicModel.Target> syncDef = new()
        {
            Map = syncMap,
            SourceConnector = source,
            TargetConnector = target,
            WriteConnectors = [target]
        };

        Orchestrator<BasicModel.Source, BasicModel.Target> orchestrator = new(syncDef);
        await orchestrator.ExecuteAsync();

        await Assert.That(target.Collection).IsEquivalentTo([
            new BasicModel.Target("1", "john.doe@example.com", "passJohn1")
        ]);
    }

    [Test]
    public async Task Execute_WithEmptyStrongKeyItem_RemainsUnchanged()
    {
        var syncMap = WeakResolutionModel.Map;
        List<WeakResolutionModel.Source> sourceItems = [];
        List<WeakResolutionModel.Target> targetItems = [
            new WeakResolutionModel.Target("0", null, "untracked.account@example.com", "defaultPassword")
        ];
        CollectionConnector<WeakResolutionModel.Source> source = new([.. sourceItems], () => throw new NotImplementedException("bad api, will not get called"));
        CollectionConnector<WeakResolutionModel.Target> target = new([.. targetItems], () => new("", "", "", "defaultPassword"));
        SyncDefinition<WeakResolutionModel.Source, WeakResolutionModel.Target> syncDef = new()
        {
            Map = syncMap,
            SourceConnector = source,
            TargetConnector = target,
            WriteConnectors = [target]
        };

        Orchestrator<WeakResolutionModel.Source, WeakResolutionModel.Target> orchestrator = new(syncDef);
        await orchestrator.ExecuteAsync();

        await Assert.That(target.Collection).IsEquivalentTo(targetItems);
    }

    [Test]
    public async Task Execute_WithEmptyStrongKeyItem_SetsStrongKey()
    {
        var syncMap = WeakResolutionModel.Map;
        List<WeakResolutionModel.Source> sourceItems = [
            new WeakResolutionModel.Source(1, "John", "Doe")
        ];
        List<WeakResolutionModel.Target> targetItems = [
            new WeakResolutionModel.Target("i1", null, "john.doe@example.com", "passJohn1")
        ];
        CollectionConnector<WeakResolutionModel.Source> source = new([.. sourceItems], () => throw new NotImplementedException("bad api, will not get called"));
        CollectionConnector<WeakResolutionModel.Target> target = new([.. targetItems], () => new("", "", "", "defaultPassword"));
        SyncDefinition<WeakResolutionModel.Source, WeakResolutionModel.Target> syncDef = new()
        {
            Map = syncMap,
            SourceConnector = source,
            TargetConnector = target,
            WriteConnectors = [target]
        };

        Orchestrator<WeakResolutionModel.Source, WeakResolutionModel.Target> orchestrator = new(syncDef);
        await orchestrator.ExecuteAsync();

        await Assert.That(target.Collection).IsEquivalentTo([
            new WeakResolutionModel.Target("i1", "1", "john.doe@example.com", "passJohn1")
        ]);
    }
}
