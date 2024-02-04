using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Web_Scraping_with_CSharp
{
    public class ConfigReader
    {
        public string GetWebsiteUrl()
        {
            return ConfigurationManager.AppSettings["WebsiteUrl"];
        }
    }
}
