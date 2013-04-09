namespace Googler
{
    partial class FrmGoogler
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.webBrowserSecond = new System.Windows.Forms.WebBrowser();
            this.buttonBack = new System.Windows.Forms.Button();
            this.webBrowserBody = new System.Windows.Forms.WebBrowser();
            this.buttonGo = new System.Windows.Forms.Button();
            this.textBoxUrl = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 18);
            this.label1.TabIndex = 14;
            this.label1.Text = "Search:";
            // 
            // webBrowserSecond
            // 
            this.webBrowserSecond.Location = new System.Drawing.Point(21, 41);
            this.webBrowserSecond.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserSecond.Name = "webBrowserSecond";
            this.webBrowserSecond.Size = new System.Drawing.Size(784, 474);
            this.webBrowserSecond.TabIndex = 13;
            this.webBrowserSecond.Visible = false;
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(793, 5);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(43, 23);
            this.buttonBack.TabIndex = 12;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // webBrowserBody
            // 
            this.webBrowserBody.Location = new System.Drawing.Point(10, 34);
            this.webBrowserBody.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserBody.Name = "webBrowserBody";
            this.webBrowserBody.Size = new System.Drawing.Size(819, 481);
            this.webBrowserBody.TabIndex = 11;
            this.webBrowserBody.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.webBrowserBody_Navigating);
            // 
            // buttonGo
            // 
            this.buttonGo.Location = new System.Drawing.Point(744, 5);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(43, 23);
            this.buttonGo.TabIndex = 10;
            this.buttonGo.Text = "Go";
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
            // 
            // textBoxUrl
            // 
            this.textBoxUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUrl.Location = new System.Drawing.Point(79, 5);
            this.textBoxUrl.Name = "textBoxUrl";
            this.textBoxUrl.Size = new System.Drawing.Size(639, 23);
            this.textBoxUrl.TabIndex = 9;
            this.textBoxUrl.Text = "http://2das.net/jay";
            this.textBoxUrl.TextChanged += new System.EventHandler(this.textBoxUrl_TextChanged);
            this.textBoxUrl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxUrl_KeyDown);
            // 
            // FrmGoogler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 673);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.webBrowserSecond);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.webBrowserBody);
            this.Controls.Add(this.buttonGo);
            this.Controls.Add(this.textBoxUrl);
            this.Name = "FrmGoogler";
            this.Text = "Googler";
            this.Load += new System.EventHandler(this.Googler_Load);
            this.Resize += new System.EventHandler(this.FrmGoogler_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.WebBrowser webBrowserSecond;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.WebBrowser webBrowserBody;
        private System.Windows.Forms.Button buttonGo;
        private System.Windows.Forms.TextBox textBoxUrl;
    }
}