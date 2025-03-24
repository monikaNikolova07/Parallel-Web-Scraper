using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parallel_Web_Scraper
{
    public class WebScraper
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<string> GetHtmlContentAsync(string url)
        {
            try
            {
                await Task.Delay(1000); // Rate limiting
                return await client.GetStringAsync(url);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Request error for {url}: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General error for {url}: {ex.Message}");
            }
            return null;
        }

        public static async Task<List<string>> ScrapeMultiplePagesAsync(string[] urls)
        {
            var tasks = urls.Select(url => GetHtmlContentAsync(url)).ToArray();
            var htmlContents = await Task.WhenAll(tasks);

            var allHeadlines = new List<string>();
            foreach (var html in htmlContents)
            {
                if (!string.IsNullOrEmpty(html))
                {
                    var headlines = HtmlParser.ExtractHeadlines(html);
                    allHeadlines.AddRange(headlines);
                }
            }
            return allHeadlines;
        }
    }
}
