using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubanBookLibrary
{
    public class DoubanBookInfo
    {
        private String bookLink;

        public String BookLink
        {
            get { return bookLink; }
            set { bookLink = value; }
        }
        private String imageLink;

        public String ImageLink
        {
            get { return imageLink; }
            set { imageLink = value; }
        }
        private String title;

        public String Title
        {
            get { return title; }
            set { title = value; }
        }
        private String tag;

        public String Tag
        {
            get { return tag; }
            set { tag = value; }
        }

        private String rating;

        public String Rating
        {
            get { return rating; }
            set { rating = value; }
        }

        private String pubInfo;

        public String PubInfo
        {
            get { return pubInfo; }
            set { pubInfo = value; }
        }

        public DoubanBookInfo(String bookLink, String imageLink, String title, String tag, String rating, String pubInfo)
        {
            this.BookLink = bookLink;
            this.ImageLink = imageLink;
            this.Title = title;
            this.Tag = tag;
            this.Rating = rating;
            this.PubInfo = pubInfo;
        }

        public override string ToString()
        {
            return "BookLink : " + BookLink
                + ";\nImageLink : " + ImageLink
                + ";\nTitle : " + Title
                + ";\nTag : " + Tag
                + ";\nRating : " + Rating
                + ";\nPubInfo : " + PubInfo;
        }
    }
}
