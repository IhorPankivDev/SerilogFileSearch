namespace SerilogFileSearcher.Tests
{
    public class SerilogFileSearcherTests
    {
        private const string TestDirectory = @"..\..\..\Static files";
        private const string TestFileName = "TestCases.log";
        private const string TestFilePath = TestDirectory + "\\" + TestFileName;
        
        [SetUp]
        public void Setup()
        {
            if (!Directory.Exists(TestDirectory))
            {
                Directory.CreateDirectory(TestDirectory);
            }

            File.WriteAllLines(TestFilePath, Datainitializer.GetFakeLog());
        }

        [TestCase("(error OR warn) AND critical", "2024-07-25 14:36:15 [WARN] API rate limit exceeded: 1000 requests in 1 hour critical")]
        public async Task SearchLogsAsync_FindsMatchingLines(string pattern, string expectedMatch)
        {
            var results = await Searcher.SearchAsync(TestDirectory, pattern);

            Assert.IsNotEmpty(results);
            Assert.IsTrue(results.Any(result => result.Value.Any(ir => ir.Contains(expectedMatch))));
        }
    }
}