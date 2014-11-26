using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DoubanBookLibrary
{
    class DoubanNet
    {
        private String url;

        public String Url
        {
            get { return url; }
            set { url = value; }
        }

        private HttpClient httpClient;
        public DoubanNet(String url)
        {
            this.Url = url;
            httpClient = new HttpClient();
        }

        public async Task<String> GetResponse()
        {
            String html = await httpClient.GetStringAsync(Url);
            return html;
        }
    }
}
