using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
namespace TextWebBrowser
{
    public partial class TWB : Form
    {
        public TWB()
        {
            InitializeComponent();
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            makeRequest();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {

        }

        private void textBoxUrl_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBoxBody_TextChanged(object sender, EventArgs e)
        {

        }

        private void TWB_Load(object sender, EventArgs e)
        {
            resize();
        }

        void makeRequest()
        {
            string url = textBoxUrl.Text;
            processHTTP ph = new processHTTP(url);
            string responseText = ph.ResponseText;

            //Remove Script
            int x = responseText.IndexOf("<body");
            int y = responseText.IndexOf("</body>") - x + 7;
            responseText = responseText.Substring(x, y);
            responseText = StripTagsCharArray(responseText);
            responseText = responseText.Replace("	", "");
            responseText = responseText.Replace("&nbsp;", "");
            responseText = responseText.Replace("&#39;", "'");
            responseText = responseText.Replace("&#160;", " ");
            responseText = responseText.Replace("â€“", "-");


            responseText = Regex.Replace(responseText, @"[\r\n]+", "\n");

            richTextBoxBody.Text = responseText;
        }

        public static string StripTagsCharArray(string source)
        {
            char[] array = new char[source.Length];
            int arrayIndex = 0;
            bool inside = false;

            for (int i = 0; i < source.Length; i++)
            {
                char let = source[i];
                if (let == '<')
                {
                    inside = true;
                    continue;
                }
                if (let == '>')
                {
                    inside = false;
                    continue;
                }
                if (!inside)
                {
                    array[arrayIndex] = let;
                    arrayIndex++;
                }
            }
            return new string(array, 0, arrayIndex);
        }
        void resize()
        {
            richTextBoxBody.Width = this.Width - 50;
            richTextBoxBody.Height = this.Height - 100;

            richTextBoxBody.Width = this.Width - 10;
            richTextBoxBody.Height = this.Height - 68;
            richTextBoxBody.Location = new Point(1, 40);

            buttonBack.Left = this.Width - 100;
            buttonGo.Left = this.Width - 150;
            textBoxUrl.Width = this.Width - 180;
        }

        private void TWB_Resize(object sender, EventArgs e)
        {
            resize();
        }

        private void textBoxUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                makeRequest();
            }
        }
        /*private void buttonGo_Click(object sender, EventArgs e)
        {

            gogogo();
        }
        void gogogo()
        {
            string url = textBoxUrl.Text;
            processHTTP ph = new processHTTP(url);
            string responseText = ph.ResponseText;

            //Remove Script
            int x = responseText.IndexOf("<body");
            int y = responseText.IndexOf("</body>") - x + 7;
            responseText = responseText.Substring(x, y);
            responseText = StripTagsCharArray(responseText);
            responseText = responseText.Replace("	", "");
            responseText = responseText.Replace("&nbsp;", "");
            responseText = responseText.Replace("&#39;", "'");
            responseText = responseText.Replace("&#160;", " ");
            responseText = responseText.Replace("â€“", "-");
            

            responseText = Regex.Replace(responseText, @"[\r\n]+", "\n");

            richTextBoxBody.Text = responseText;
        }

        public static string StripTagsCharArray(string source)
        {
            char[] array = new char[source.Length];
            int arrayIndex = 0;
            bool inside = false;

            for (int i = 0; i < source.Length; i++)
            {
                char let = source[i];
                if (let == '<')
                {
                    inside = true;
                    continue;
                }
                if (let == '>')
                {
                    inside = false;
                    continue;
                }
                if (!inside)
                {
                    array[arrayIndex] = let;
                    arrayIndex++;
                }
            }
            return new string(array, 0, arrayIndex);
        }

        private void TWB_Load(object sender, EventArgs e)
        {
            resize();
        }

        private void TWB_Resize(object sender, EventArgs e)
        {
            resize();
            
        }
        void resize()
        {
            richTextBoxBody.Width = this.Width - 50;
            richTextBoxBody.Height = this.Height - 100;

            richTextBoxBody.Width = this.Width - 10;
            richTextBoxBody.Height = this.Height - 68;
            richTextBoxBody.Location = new Point(1, 40);

            buttonBack.Left = this.Width - 100;
            buttonGo.Left = this.Width - 150;
            textBoxUrl.Width = this.Width - 180;
        }

        private void textBoxUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gogogo();
            }
        }*/
    }
}
