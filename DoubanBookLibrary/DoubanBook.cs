using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubanBookLibrary
{
    class DoubanBook
    {
        private static String urlPrefix = "http://book.douban.com/people/";
        private static String urlDoSuffix = "do";
        private static String urlWishSuffix = "wish";
        private static String urlCollectSuffix = "collect";

        private String uniformSuffix;

        public String UniformSuffix
        {
            get { return uniformSuffix; }
            private set { uniformSuffix = value; }
        }


        private String urlBookDo;

        public String UrlBookDo
        {
            get { return urlBookDo; }
            set { urlBookDo = value; }
        }
        private String urlBookWish;

        public String UrlBookWish
        {
            get { return urlBookWish; }
            set { urlBookWish = value; }
        }
        private String urlBookCollect;

        public String UrlBookCollect
        {
            get { return urlBookCollect; }
            set { urlBookCollect = value; }
        }

        public DoubanBook(String userId)
        {
            this.UniformSuffix = urlPrefix + userId + "/";
            this.UrlBookDo = this.UniformSuffix + urlDoSuffix;
            this.urlBookWish = this.UniformSuffix + urlWishSuffix;
            this.urlBookCollect = this.UniformSuffix + urlCollectSuffix;
        }
    }
}
