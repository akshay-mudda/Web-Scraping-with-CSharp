using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Web_Scraping_with_CSharp
{
    public class WebScraper
    {
        private readonly HttpClient _client;

        public WebScraper()
        {
            _client = new HttpClient();
        }

        public async Task<List<BlogPost>> ScrapeWebsite(string url)
        {
            var html = await _client.GetStringAsync(url);
            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            var posts = new List<BlogPost>();

            var postNodes = doc.DocumentNode.SelectNodes("//article");

            Console.WriteLine($"Number of postNodes: {postNodes?.Count}");

            if (postNodes != null)
            {
                foreach (var postNode in postNodes)
                {
                    var titleNode = postNode.SelectSingleNode(".//h2/a");
                    var urlNode = postNode.SelectSingleNode(".//h2/a/@href");

                    if (titleNode != null && urlNode != null)
                    {
                        var post = new BlogPost
                        {
                            Title = titleNode.InnerText.Trim(),
                            Url = urlNode.GetAttributeValue("href", "")
                        };

                        posts.Add(post);
                    }
                    else
                    {
                        Console.WriteLine("Unable to extract title or URL from postNode:");
                        Console.WriteLine(postNode.InnerHtml);
                    }
                }
            }

            Console.WriteLine($"Number of posts added to list: {posts.Count}");

            return posts;
        }

    }
}
