using LogSearcherWeb.Interfaces;
using LogSearcherWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace LogSearcherWeb.Controllers
{
    public class LogSearchController : Controller
    {
        private readonly ILogSearchService _logSearchService;

        public LogSearchController(ILogSearchService logSearchService)
        {
            _logSearchService = logSearchService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(string pattern)
        {
            var results = await _logSearchService.SearchLogsAsync(pattern);
            return View("Index", results);
        }

        [HttpGet]
        public async Task<IActionResult> ViewLogFile(string highlightLine, string filePath, int lineNumber = 0)
        {
            var logLines = new List<string>();

            using (var reader = new StreamReader(filePath))
            {
                string line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    logLines.Add(line);
                }
            }

            var model = new LogFileViewModel
            {
                FilePath = filePath,
                Lines = logLines,
                HighlightLine = highlightLine
            };
            return View(model);
        }
    }
}
