using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace DoubanBookLibrary
{
    class DoubanBookManager
    {
        public static DoubanBookInfo GetDoubanBookInfo(HtmlNode htmlNode)
        {
            String bookLink = GetBookLink(htmlNode);
            Console.WriteLine(bookLink);
            String imageLink = GetImageLink(htmlNode);
            Console.WriteLine(imageLink);
            String title = GetTitle(htmlNode);
            Console.WriteLine(title);
            String pubInfo = GetPubInfo(htmlNode);
            Console.WriteLine(pubInfo);
            String tag = GetTag(htmlNode);
            Console.WriteLine(tag);
            String rating = GetRating(htmlNode);
            Console.WriteLine(rating);
            DoubanBookInfo doubanBookInfo = new DoubanBookInfo(bookLink, imageLink, title, tag, rating, pubInfo);
            return doubanBookInfo;
        }

        private static String GetBookLink(HtmlNode htmlNode)
        {
            return htmlNode.SelectSingleNode(".//a").Attributes["href"].Value;
        }

        private static String GetImageLink(HtmlNode htmlNode)
        {
            return htmlNode.SelectSingleNode(".//img").Attributes["src"].Value;
        }

        private static String GetTitle(HtmlNode htmlNode)
        {
            return htmlNode.SelectSingleNode(".//a[@title]").Attributes["title"].Value;
        }

        private static String GetPubInfo(HtmlNode htmlNode)
        {
            return htmlNode.SelectSingleNode(".//div[@class='pub']").InnerText;
        }

        private static String GetTag(HtmlNode htmlNode)
        {
            return htmlNode.SelectSingleNode(".//span[@class='tags']").InnerText;
        }

        private static String GetRating(HtmlNode htmlNode)
        {
            HtmlNodeCollection htmlNodes = htmlNode.SelectNodes(".//span");
            foreach (HtmlNode node in htmlNodes)
            {
                if (node.Attributes["class"] == null)
                {
                    continue;
                }
                String rating = node.Attributes["class"].Value;
                if (!String.IsNullOrEmpty(rating) && rating.Length > 6 && rating.Substring(0, 6).Equals("rating"))
                {
                    return rating;
                }
            }
            return "";
        }
    }
}
