using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace Googler
{
    public class BackGroundWork
    {
        public static void getLinkText()
        {
            for (int i = 1; i < 2; i++)
            {
                processHTTP ph = new processHTTP(Global.links[i]);
                string rt = ph.ResponseText;
                int x = rt.IndexOf("<body");
                int y = rt.IndexOf("</body>")+7;
                if (x > 10 && y > 10)
                {
                    rt = rt.Substring(x, y - x);
                }
                rt = "<html><head><title>Googler</title></head>" + rt + "</html>";

                rt = removeScript(rt);
                    
                Global.texts[i] = rt;
                Thread.Sleep(200);
            }
        }

        public static string removeScript(string source)
        {
            string newString = source;
            int x = source.IndexOf("<script");
            int y = source.IndexOf("</script");
            while (x > 1 && y > 1)
            {
                newString = source.Substring(0, x);
                newString = newString + source.Substring(y + 8);
                source=newString;
                x = source.IndexOf("<script");
                y = source.IndexOf("</script");
            }
            return newString;
        }
       
    }
}
