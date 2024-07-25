using LogSearcherWeb.Interfaces;
using SerilogFileSearcher;
using System.Collections.Concurrent;

namespace LogSearcherWeb.Services
{
    public class LogSearchService : ILogSearchService
    {
        private readonly string _logDirectory;

        public LogSearchService(IConfiguration configuration)
        {
            _logDirectory = configuration["LogDirectory"];
        }


        public Task<ConcurrentDictionary<string, List<string>>> SearchLogsAsync(string pattern)
        {
            return Searcher.SearchAsync(_logDirectory, pattern);
        }
    }
}
