using SkolSync.Core.Mapping;

namespace SkolSync.Core.Tests.TestModels;

public static class BasicModel
{
    public record Source(int Id, string FirstName, string LastName);
    public record Target(string Id, string Email, string FirstUsePassword);

    public static ObjectMap<Source, Target> Map => new()
    {
        MemberMaps = [
            new MemberMap<Source, Target, string>(s => s.Id.ToString(), t => t.Id) with { IdentityStrength = IdentityStrength.Strong },
            new MemberMap<Source, Target, string>(s => $"{s.FirstName}.{s.LastName}@example.com".ToLowerInvariant(), t => t.Email),
            new MemberMap<Source, Target, string>(s => $"pass{s.FirstName}{s.Id}", t => t.FirstUsePassword) with { ApplyOnCreate = true, ApplyOnUpdate = false }
        ]
    };
}
