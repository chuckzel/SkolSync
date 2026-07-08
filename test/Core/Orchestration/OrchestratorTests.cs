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
}
