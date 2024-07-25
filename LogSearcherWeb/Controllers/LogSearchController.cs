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
        public async Task<IActionResult> ViewLogFile(string highlightLine, string filePath, int? pageNumber, int pageSize = 10)
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

            int highlightLineIndex = logLines.FindIndex(line => line.Contains(highlightLine));
            if (highlightLineIndex != -1 && !pageNumber.HasValue)
            {
                pageNumber = (highlightLineIndex / pageSize) + 1;
            }

            pageNumber = pageNumber ?? 1;

            var paginatedLines = logLines.Skip((pageNumber.Value - 1) * pageSize).Take(pageSize).ToList();
            var totalLines = logLines.Count;

            var model = new LogFileViewModel
            {
                FilePath = filePath,
                Lines = paginatedLines,
                PageNumber = pageNumber.Value,
                PageSize = pageSize,
                TotalLines = totalLines,
                HighlightLine = highlightLine,
                HighlightLineIndex = highlightLineIndex
            };

            return View(model);
        }
    }
}
