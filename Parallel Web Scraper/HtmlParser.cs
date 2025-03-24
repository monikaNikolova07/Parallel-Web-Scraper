using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parallel_Web_Scraper
{
    public class HtmlParser
    {
        public static List<string> ExtractHeadlines(string html)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            var headlines = new List<string>();
            var headlineNodes = doc.DocumentNode.SelectNodes("//h1");

            if (headlineNodes != null)
            {
                foreach (var node in headlineNodes)
                {
                    headlines.Add(node.InnerText.Trim());
                }
            }
            return headlines;
        }
    }
}
