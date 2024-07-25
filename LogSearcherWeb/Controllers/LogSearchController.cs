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

        public async Task<IActionResult> Search(string pattern, int page = 1, int pageSize = 10)
        {
            var results = await _logSearchService.SearchLogsAsync(pattern);
            var pagedResults = results
                .SelectMany(kvp => kvp.Value.Select(log => new { Page = kvp.Key, Log = log }))
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .GroupBy(item => item.Page)
                .ToDictionary(g => g.Key, g => g.Select(item => item.Log).ToList());

            ViewBag.TotalPages = (int)Math.Ceiling((double)results.Sum(kvp => kvp.Value.Count) / pageSize);
            ViewBag.CurrentPage = page;
            ViewBag.Pattern = pattern;

            return View("Index", pagedResults);
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
