using System.Text.RegularExpressions;

namespace SerilogFileSearcherConsole
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter directory path (or type 'exit' to quit):");
                string directoryPath = Console.ReadLine();

                if (directoryPath.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                Console.WriteLine("Enter search pattern:");
                string searchPattern = Console.ReadLine();

                try
                {
                    var results = await SearchAsync(directoryPath, searchPattern);

                    foreach (var kvp in results)
                    {
                        Console.WriteLine($"File: {kvp.Key}");
                        foreach (var line in kvp.Value)
                        {
                            Console.WriteLine($"  {line}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }

        public static async Task<Dictionary<string, List<string>>> SearchAsync(string directoryPath, string searchPattern)
        {
            var finalResult = new Dictionary<string, List<string>>();

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
