using System.Reflection;

namespace SkolSync.Core.Interfaces;

public interface IReadConnector<T>
{
    IAsyncEnumerable<T> GetObjectsAsync(IEnumerable<MemberInfo> membersToQuery, CancellationToken cancellationToken = default);
}
