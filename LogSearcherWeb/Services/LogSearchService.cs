using LogSearcherWeb.Interfaces;
using SerilogFileSearcher;

namespace LogSearcherWeb.Services
{
    public class LogSearchService : ILogSearchService
    {
        private readonly string _logDirectory;

        public LogSearchService(IConfiguration configuration)
        {
            _logDirectory = configuration["LogDirectory"];
        }


        public Task<Dictionary<string, List<string>>> SearchLogsAsync(string pattern)
        {
            return Searcher.SearchAsync(_logDirectory, pattern);
        }
    }

}
