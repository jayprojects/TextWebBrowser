using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using JsonProcessor;
namespace Googler
{
    public partial class FrmGoogler : Form
    {
        public FrmGoogler()
        {
            InitializeComponent();
        }

        private void Googler_Load(object sender, EventArgs e)
        {
            setSize();
        }

        private void textBoxUrl_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            googleIt();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            webBrowserSecond.Visible = false;
            webBrowserBody.Document.Body.Focus();
        }

        private void textBoxUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) googleIt();
        }

        /// <summary>
        /// intercept link click event on the webbrowser
        /// insted of going to the live link dispaly text from memory
        /// </summary>
        private void webBrowserBody_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (e.Url.Host != String.Empty && e.Url.Host.Contains("googleusercontent"))
            {
                string url = e.Url.ToString();
                url = url.Replace("http://webcache.googleusercontent.com/", "");
                int i = int.Parse(url);
                if (Global.preload)
                {
                    webBrowserSecond.DocumentText = Global.texts[i];

                }
                else
                {
                    processHTTP ph = new processHTTP(Global.links[i]);
                    webBrowserSecond.DocumentText = ph.ResponseText;
                }
                webBrowserSecond.Visible = true;
                webBrowserSecond.Focus();
                e.Cancel = true;
            }
        }

        private void FrmGoogler_Resize(object sender, EventArgs e)
        {
            setSize();
        }


        /// <summary>
        /// Butild a search query, send httprequest to ajax google server
        /// process the return json object to html
        /// assign the html code to the browser source
        /// </summary>
        void googleIt()
        {
            string query = textBoxUrl.Text;
            
            string url = Global.googleSearchUrl 
                        + query.Replace(' ', '+') 
                        + Global.searchNumParam
                        +Global.systemIPParam;
            processHTTP ph = new processHTTP(url);
            webBrowserBody.DocumentText = JProcessor.processJson(ph.ResponseText);
            webBrowserBody.Focus();
            string responseText = ph.ResponseText;

            if (Global.preload)
            {
                var thread = new Thread(new ThreadStart(BackGroundWork.getLinkText));
                thread.Start();
            }
        }

        /// <summary>
        /// Change the lenght height and position of the controls if the form size changes
        /// </summary>
        void setSize()
        {
            webBrowserBody.Width = this.Width - 10;
            webBrowserBody.Height = this.Height - 68;
            webBrowserBody.Location = new Point(1, 40);
            webBrowserSecond.Width = this.Width - 10;
            webBrowserSecond.Height = this.Height - 68;
            webBrowserSecond.Location = new Point(1, 40);
            buttonBack.Left = this.Width - 100;
            buttonGo.Left = this.Width - 150;
            textBoxUrl.Width = this.Width - 250;
        }

        


    }
}
