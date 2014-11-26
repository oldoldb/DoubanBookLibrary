using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace DoubanBookLibrary
{
    public class DoubanHtmlParser
    {
        public enum DoubanBookKind
        {
            DO,WISH,COLLECT
        }
        private DoubanBook mDoubanBook;
        private DoubanNet mDoubanNet;
        public DoubanHtmlParser(String userId)
        {
            mDoubanBook = new DoubanBook(userId);
            mDoubanNet = new DoubanNet(mDoubanBook.UrlBookDo);
        }

        public DoubanHtmlParser(String userId, DoubanBookKind kind) : this(userId)
        {
            switch(kind)
            {
                case DoubanBookKind.COLLECT:
                    mDoubanNet = new DoubanNet(mDoubanBook.UrlBookCollect);
                    break;
                case DoubanBookKind.WISH:
                    mDoubanNet = new DoubanNet(mDoubanBook.UrlBookWish);
                    break;
                case DoubanBookKind.DO:
                default:
                    break;
            }
        }

        public async Task<List<DoubanBookInfo>> GetBookInfos()
        {
            List<DoubanBookInfo> list = new List<DoubanBookInfo>();
            String html = await mDoubanNet.GetResponse();
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);
            HtmlNodeCollection keyNodes = htmlDocument.DocumentNode.SelectNodes("//ul[@class='interest-list']/li[@class='subject-item']");
            foreach (HtmlNode keyNode in keyNodes)
            {
                list.Add(DoubanBookManager.GetDoubanBookInfo(keyNode));
            }
            String nextUrl = GetNextPageUrl(htmlDocument);
            if(nextUrl != null)
            {
                mDoubanNet.Url = nextUrl;
                list.AddRange(await GetBookInfos());
            }
            return list;
        }

        private String GetNextPageUrl(HtmlDocument htmlDocument)
        {
            HtmlNode htmlNode = htmlDocument.DocumentNode.SelectSingleNode("//link[@rel='next']");
            return htmlNode == null ? null : htmlNode.Attributes["href"].Value;
        }
    }   
}
