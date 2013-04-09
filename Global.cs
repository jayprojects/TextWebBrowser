using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Googler
{
    public class Global
    {
        public static string[] links = new string[9];
        public static string[] texts = new string[9];
        public static string googlecachelink = "http://webcache.googleusercontent.com/search?q=cache:";
        public static string googleSearchUrl = "https://ajax.googleapis.com/ajax/services/search/web?v=1.0&q=";
        public static string systemIPParam = "&userip=146.245.120.110";
        public static string searchNumParam = "&rsz=8";

        public static bool preload = false;
    }
}
