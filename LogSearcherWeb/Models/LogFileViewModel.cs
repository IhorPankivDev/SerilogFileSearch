namespace LogSearcherWeb.Models
{
    public class LogFileViewModel
    {
        public string FilePath { get; set; }
        public List<string> Lines { get; set; } = new List<string>();
        public string HighlightLine { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalLines { get; set; }
        public int HighlightLineIndex { get; set; }
    }

}
