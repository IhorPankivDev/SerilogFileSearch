using System.Collections.Concurrent;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SerilogFileSearcher
{
    public static class Searcher
    {
        public static async Task<ConcurrentDictionary<string, List<string>>> SearchAsync(string directoryPath, string searchPattern)
        {
            var finalResult = new ConcurrentDictionary<string, List<string>>();

            var logFiles = Directory.GetFiles(directoryPath, "*.log", SearchOption.AllDirectories);

            string regexPattern = ConvertWildcardToRegex(searchPattern);

            var tasks = logFiles.Select(async logFile =>
            {
                using (StreamReader reader = new StreamReader(logFile))
                {
                    var matchesOfOneFile = new List<string>();

                    string line;
                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        if (Regex.IsMatch(line, regexPattern))
                        {
                            lock (finalResult)
                            {
                                matchesOfOneFile.Add(line);
                            }
                        }
                    }

                    finalResult[logFile] = matchesOfOneFile;
                }
            });

            await Task.WhenAll(tasks);

            return finalResult;
        }

        

        private static string ConvertWildcardToRegex(string searchPattern)
        {
            string pattern = searchPattern
            .Replace("*", ".*")
            .Replace("?", ".")
            .Replace(" AND ", ".*")
            .Replace(" OR ", "|")
            .Replace("(", "(?:").Replace(")", ")");

            pattern = $"(?i){pattern}";

            return pattern;
        }
    }
}

