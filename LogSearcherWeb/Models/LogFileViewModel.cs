namespace LogSearcherWeb.Models
{
    public class LogFileViewModel
    {
        public string FilePath { get; set; }
        public List<string> Lines { get; set; } = new List<string>();
        public string HighlightLine { get; set; }
    }

}
