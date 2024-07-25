namespace LogSearcherWeb.Interfaces
{
    public interface ILogSearchService
    {
        Task<Dictionary<string, List<string>>> SearchLogsAsync(string pattern);
    }
}
