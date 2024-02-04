using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Web_Scraping_with_CSharp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var configReader = new ConfigReader();
            var websiteUrl = configReader.GetWebsiteUrl();

            var scraper = new WebScraper();

            try
            {
                var posts = await scraper.ScrapeWebsite(websiteUrl);

                if (posts.Count > 0)
                {
                    foreach (var post in posts)
                    {
                        Console.WriteLine($"Title: {post.Title}");
                        Console.WriteLine($"URL: {post.Url}");
                        Console.WriteLine();
                    }
                }
                else if(posts.Count == 0)
                { 
                    Console.WriteLine("no blogs found"); 
                }
            }
            catch (HttpRequestException)
            {
                Console.WriteLine("Error: Unable to connect to the provided URL. Please make sure it is correct and accessible.");
            }

            Console.WriteLine("----------------------------------------Thank You-----------------------------------------");
            Console.WriteLine("-Developed by Akshay Mudda");
        }


    }
}
