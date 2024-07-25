using System.Collections.Concurrent;

namespace LogSearcherWeb.Interfaces
{
    public interface ILogSearchService
    {
        Task<ConcurrentDictionary<string, List<string>>> SearchLogsAsync(string pattern);
    }
}
