using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cw1
{
    class Crawler
    {
        string str;
        public Crawler()
        {
            var url = "https://www.pja.edu.pl/";
            str = url;
        }

        public async Task dom()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(str);

            var htmlContent = await response.Content.ReadAsStringAsync();

            var regex = new Regex("[a-z]+[a-z0-9]*@[a-z0-9]+\\.[a-z]+", RegexOptions.IgnoreCase);

            var matches = regex.Matches(htmlContent);

            foreach(var match in matches)
            {
                Console.WriteLine(match.ToString());
            }

        }
    }
}
