DoubanBookLibrary
=================

Many people use Douban Book to record what they have read, what they are reading and what they want to read.
I wrote this .dll to provide a simple way to get someone's readlist.
With just a userId provided, you can get a List which containes user's bookInfo.

To use the .dll, you should do as follows:

1.  add DoubanBookLibrary.dll to your project's reference
2.  add "using DoubanBookLibrary" to your code
3.  use "DoubanHtmlParser doubanHtmlParser = new DoubanHtmlParser(userid, bookKind);" to initialize it.
    here, userid is user's Douban id, for example, my Douban Id is "oldoldb"
          bookKind is an enumType which contains "DO, WISH, COLLECT"
4.  use "List<DoubanBookInfo> list = await doubanBookHtmlParser.GetBoookInfos()" to get a list 
5.  then you can get what you need from the list

here is the structure of DoubanBookInfo:

    public class DoubanBookInfo
    {
        private String bookLink;
        private String imageLink;
        private String title;
        private String tag;
        private String rating;
        private String pubInfo;
    }
