using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using Googler;
namespace JsonProcessor
{
    public class JProcessor
    {
        
        public static string processJson(string jsonString)
        {
            
           // string jsonString = @"{""responseData"": {""results"":[{""GsearchResultClass"":""GwebSearch"",""unescapedUrl"":""http://www.parishilton.com/"",""url"":""http://www.parishilton.com/"",""visibleUrl"":""www.parishilton.com"",""cacheUrl"":""http://www.google.com/search?q\u003dcache:EgDCCgd54xQJ:www.parishilton.com"",""title"":""The Official Website of \u003cb\u003eParis Hilton\u003c/b\u003e"",""titleNoFormatting"":""The Official Website of Paris Hilton"",""content"":""Sign up for access to the world\u0026#39;s most exclusive club and watch an exclusive   trailer for the re-imagining of \u003cb\u003eParis Hilton\u0026#39;s\u003c/b\u003e iconic brand.""},{""GsearchResultClass"":""GwebSearch"",""unescapedUrl"":""http://en.wikipedia.org/wiki/Paris_Hilton"",""url"":""http://en.wikipedia.org/wiki/Paris_Hilton"",""visibleUrl"":""en.wikipedia.org"",""cacheUrl"":""http://www.google.com/search?q\u003dcache:TwrPfhd22hYJ:en.wikipedia.org"",""title"":""\u003cb\u003eParis Hilton\u003c/b\u003e - Wikipedia, the free encyclopedia"",""titleNoFormatting"":""Paris Hilton - Wikipedia, the free encyclopedia"",""content"":""\u003cb\u003eParis\u003c/b\u003e Whitney \u003cb\u003eHilton\u003c/b\u003e (born February 17, 1981) is an American heiress, socialite,   television personality, businesswoman, fashion designer, entrepreneur, model, \u003cb\u003e...\u003c/b\u003e""},{""GsearchResultClass"":""GwebSearch"",""unescapedUrl"":""https://twitter.com/ParisHilton"",""url"":""https://twitter.com/ParisHilton"",""visibleUrl"":""twitter.com"",""cacheUrl"":""http://www.google.com/search?q\u003dcache:hz3HWsYVT64J:twitter.com"",""title"":""\u003cb\u003eParis Hilton\u003c/b\u003e (\u003cb\u003eParisHilton\u003c/b\u003e) on Twitter"",""titleNoFormatting"":""Paris Hilton (ParisHilton) on Twitter"",""content"":""The latest from \u003cb\u003eParis Hilton\u003c/b\u003e (@\u003cb\u003eParisHilton\u003c/b\u003e). Living Life to the Fullest!""},{""GsearchResultClass"":""GwebSearch"",""unescapedUrl"":""http://www.imdb.com/name/nm0385296/"",""url"":""http://www.imdb.com/name/nm0385296/"",""visibleUrl"":""www.imdb.com"",""cacheUrl"":""http://www.google.com/search?q\u003dcache:1i34KkqnsooJ:www.imdb.com"",""title"":""\u003cb\u003eParis Hilton\u003c/b\u003e - IMDb"",""titleNoFormatting"":""Paris Hilton - IMDb"",""content"":""\u003cb\u003eParis Hilton\u003c/b\u003e, Producer: The Simple Life. Socialite \u003cb\u003eParis Hilton\u003c/b\u003e was born on   February 17, 1981 in New York City into the Hilton family and, along with her   three \u003cb\u003e...\u003c/b\u003e""}],""cursor"":{""resultCount"":""30,100,000"",""pages"":[{""start"":""0"",""label"":1},{""start"":""4"",""label"":2},{""start"":""8"",""label"":3},{""start"":""12"",""label"":4},{""start"":""16"",""label"":5},{""start"":""20"",""label"":6},{""start"":""24"",""label"":7},{""start"":""28"",""label"":8}],""estimatedResultCount"":""30100000"",""currentPageIndex"":0,""moreResultsUrl"":""http://www.google.com/search?oe\u003dutf8\u0026ie\u003dutf8\u0026source\u003duds\u0026start\u003d0\u0026hl\u003den\u0026q\u003dParis+Hilton"",""searchResultTime"":""0.20""}}, ""responseDetails"": null, ""responseStatus"": 200}";
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            ResponseText rd = serializer.Deserialize<ResponseText>(jsonString);
            IEnumerable<Result> results = rd.responseData.results;
            StringBuilder sb = new StringBuilder();
            sb.Append("<html>");
            sb.Append("<head>");
            sb.Append("<title>");
            sb.Append("</title>");
            sb.Append("</head>");
            sb.Append("<body>");
            sb.Append("<ol>");
            int i=1;
            foreach(Result r in results)
            {
                r.url = r.url.Replace("/", "%2F").Replace(":", "%3A");
                r.cacheUrl = Global.googlecachelink + r.url;
                Global.links[i] = r.cacheUrl;
                sb.Append("<li>");
                sb.Append("<p>");
                sb.Append("<span style=\"font-size:120%\"><a href='http://webcache.googleusercontent.com/" + (i++).ToString()
                    +"'>" + r.titleNoFormatting + "</a></span><br/>");
                sb.Append("<span><a href='" + r.unescapedUrl + "'>" + r.unescapedUrl + "</a></span><br/>");
                sb.Append("<span>" + r.content + "</span>");
                sb.Append("</p>");
                sb.Append("</li>");

            }
            sb.Append("</ol>");
            sb.Append("</body>");
            sb.Append("</html>");


            
            string more = rd.responseData.cursor.moreResultsUrl;
            return sb.ToString();
           
        }




        static void linkLableClick(object sender, EventArgs e)
        {
            
            LinkLabel ll = (LinkLabel)sender;
            Control c = ll.Parent;
            WebBrowser wb = (WebBrowser)FrmGoogler.ActiveForm.Controls["webBrowserbody"];
            if (ll.Name.Contains("item"))
            {
                //Console.Out.WriteLine(ll.Links.);
                string iStr = ll.Name.Replace("item", "");
                int i = int.Parse(iStr);
                //processHTTP ph = new processHTTP(Global.links[i]);
                //wb.DocumentText = ph.ResponseText;
                wb.DocumentText = Global.texts[i];
                
                wb.Visible = true;
            }
            else
            {
                LinkLabelLinkClickedEventArgs  e2 = (LinkLabelLinkClickedEventArgs )e;
                ProcessStartInfo sInfo = new ProcessStartInfo(e2.Link.LinkData.ToString());
                Process.Start(sInfo);
            }
            
        }

      
    }
}
