namespace Parallel_Web_Scraper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            static async Task Main()
            {
                string[] urls = {
            "https://www.cnn.com",
            "https://www.bbc.com",
            "https://www.reuters.com"
        };

                var headlines = await WebScraper.ScrapeMultiplePagesAsync(urls);
                CsvWriter.WriteToCsv(headlines, "headlines.csv");
                Console.WriteLine("Scraping completed. Data saved to headlines.csv");
            }
        }
    }
}
