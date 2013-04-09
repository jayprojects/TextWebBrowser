using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace testwebbrower
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "<html><head><title>mypage</title></head><body><p><a href=\"http://jay.2das.net\">ok</a></p></body></html>";
            webBrowser1.DocumentText = str;
        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (e.Url.Host != String.Empty)
            {
                
                webBrowser1.DocumentText = "<html> "+e.Url.Host+" </html>";
                e.Cancel = true;
            }
        }
    }
}
