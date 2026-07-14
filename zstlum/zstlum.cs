#:property PublishAot=false
#:property TargetFramework=net10.0-windows
#:project ../Core/SkolSync.Core.csproj
#:project ./BakaDB/BakaDB.csproj
#:package System.DirectoryServices.AccountManagement@*
using System.DirectoryServices.AccountManagement;
using System.Globalization;
using System.Reflection;
using System.Text;

using BakaDB;

using SkolSync.Core.Mapping;
using SkolSync.Core.Interfaces;
using SkolSync.Core.Reconciliation;
using SkolSync.Core.Orchestration;

var source = new BakaUserConnector();

using var context = new PrincipalContext(ContextType.Domain);
var target = new ActiveDirectoryConnector(context);

using var s = new StreamWriter("changelog.txt", false, Encoding.UTF8);
PlaintextConnector<UserPrincipal> changelogger = new(s);

SyncDefinition<Zaci, UserPrincipal> syncDef = new()
{
    Map = new ObjectMap<Zaci, UserPrincipal>()
    {
        MemberMaps = [
            new MemberMap<Zaci, UserPrincipal, string>(MapToSamAccountName, t => t.SamAccountName) with { IdentityStrength = IdentityStrength.Strong },
            new MemberMap<Zaci, UserPrincipal, string>(s => $"{MapToMailName(s)}@zstlumacov.cz", t => t.UserPrincipalName),
            new MemberMap<Zaci, UserPrincipal, string>(s => s.Jmeno.Trim(), t => t.GivenName),
            new MemberMap<Zaci, UserPrincipal, string>(s => s.Prijmeni.Trim().ToTitleCase(), t => t.Surname),
            new MemberMap<Zaci, UserPrincipal, string>(s => $"{s.Jmeno.Trim()} {s.Prijmeni.Trim().ToTitleCase()}", t => t.DisplayName),
        ]
    },
    SourceConnector = source,
    TargetConnector = target,
    WriteConnectors = [changelogger]
};

Orchestrator<Zaci, UserPrincipal> orchestrator = new(syncDef);
await orchestrator.ExecuteAsync();

static string MapToMailName(Zaci student)
    => $"{student.Jmeno.Trim().Split(' ')[0]}.{student.Prijmeni.Trim().Split(' ')[0]}"
        .RemoveDiacritics().ToLowerInvariant();

static string MapToSamAccountName(Zaci student)
    => $"{student.Prijmeni.Trim().Split(' ')[0][0..4]}{student.Jmeno.Trim().Split(' ')[0][0..2]}"
        .RemoveDiacritics().ToLowerInvariant();

static class StringExtensions
{
    extension(string str)
    {
        public string ToTitleCase() =>
            CultureInfo.InvariantCulture.TextInfo.ToTitleCase(str.ToLowerInvariant());

        public string RemoveDiacritics() =>
            string.Concat(str.Normalize(NormalizationForm.FormD)
                .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark))
                .Normalize(NormalizationForm.FormC);
    }
}

class BakaUserConnector : IReadConnector<Zaci>
{
    public IAsyncEnumerable<Zaci> GetObjectsAsync(IEnumerable<MemberInfo> membersToQuery, CancellationToken cancellationToken = default)
    {
        using var context = new BakalariContext();
        return context.Zaci.Where(z => z.EvidDo == null).OrderBy(z => z.EvidOd).ToList().ToAsyncEnumerable();
    }
}

class ActiveDirectoryConnector(PrincipalContext context) : IReadConnector<UserPrincipal>, IWriteConnector<UserPrincipal>
{
    private readonly PrincipalContext _context = context;

    public Task AddAsync(AddObjectChange<UserPrincipal> obj, CancellationToken cancellationToken = default)
    {
        Console.WriteLine("Adding user: " + obj.MemberChanges);
        return Task.CompletedTask;
    }

    public IAsyncEnumerable<UserPrincipal> GetObjectsAsync(IEnumerable<MemberInfo> membersToQuery, CancellationToken cancellationToken = default)
    {
        using var searcher = new PrincipalSearcher(new UserPrincipal(_context));
        return searcher.FindAll().OfType<UserPrincipal>().ToList().ToAsyncEnumerable();
    }

    public Task ModifyAsync(UpdateObjectChange<UserPrincipal> obj, CancellationToken cancellationToken = default)
    {
        Console.WriteLine("Modifying user: " + obj.Target.SamAccountName);
        return Task.CompletedTask;
    }

    public Task RemoveAsync(RemoveObjectChange<UserPrincipal> obj, CancellationToken cancellationToken = default)
    {
        Console.WriteLine("Removing user: " + obj.Target.SamAccountName);
        return Task.CompletedTask;
    }
}

class PlaintextConnector<T>(StreamWriter writer) : IWriteConnector<T>
{
    private readonly StreamWriter _writer = writer;

    public Task AddAsync(AddObjectChange<T> obj, CancellationToken cancellationToken = default)
    {
        _writer.WriteLine($"Adding object: \n  {string.Join("\n  ", obj.MemberChanges)}");
        return Task.CompletedTask;
    }

    public Task ModifyAsync(UpdateObjectChange<T> obj, CancellationToken cancellationToken = default)
    {
        _writer.WriteLine($"Modifying object {obj.Target}: \n  {string.Join("\n  ", obj.MemberChanges)}");
        return Task.CompletedTask;
    }

    public Task RemoveAsync(RemoveObjectChange<T> obj, CancellationToken cancellationToken = default)
    {
        _writer.WriteLine($"Removing object {obj.Target}");
        return Task.CompletedTask;
    }
}
