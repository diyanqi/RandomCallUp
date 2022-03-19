namespace RandomCallUp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.result = new System.Windows.Forms.Label();
            this.ranget = new System.Windows.Forms.Button();
            this.top = new System.Windows.Forms.Button();
            this.settings = new System.Windows.Forms.Button();
            this.about = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // result
            // 
            this.result.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.result.Font = new System.Drawing.Font("Microsoft YaHei UI", 79.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.result.Location = new System.Drawing.Point(12, -15);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(394, 170);
            this.result.TabIndex = 0;
            this.result.Text = "0";
            this.result.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.result.Click += new System.EventHandler(this.result_Click);
            // 
            // ranget
            // 
            this.ranget.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ranget.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ranget.Location = new System.Drawing.Point(121, 158);
            this.ranget.Name = "ranget";
            this.ranget.Size = new System.Drawing.Size(162, 53);
            this.ranget.TabIndex = 1;
            this.ranget.Text = "随机抽取 !";
            this.ranget.UseVisualStyleBackColor = true;
            this.ranget.Click += new System.EventHandler(this.ranget_Click);
            // 
            // top
            // 
            this.top.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.top.ForeColor = System.Drawing.SystemColors.ControlText;
            this.top.Location = new System.Drawing.Point(376, 12);
            this.top.Name = "top";
            this.top.Size = new System.Drawing.Size(30, 30);
            this.top.TabIndex = 2;
            this.top.Text = "📌";
            this.top.UseVisualStyleBackColor = true;
            this.top.Click += new System.EventHandler(this.top_Click);
            this.top.MouseHover += new System.EventHandler(this.top_MouseHover);
            // 
            // settings
            // 
            this.settings.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.settings.Location = new System.Drawing.Point(376, 48);
            this.settings.Name = "settings";
            this.settings.Size = new System.Drawing.Size(30, 30);
            this.settings.TabIndex = 3;
            this.settings.Text = "⚙";
            this.settings.UseVisualStyleBackColor = true;
            this.settings.Click += new System.EventHandler(this.settings_Click);
            // 
            // about
            // 
            this.about.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.about.Location = new System.Drawing.Point(376, 84);
            this.about.Name = "about";
            this.about.Size = new System.Drawing.Size(30, 30);
            this.about.TabIndex = 4;
            this.about.Text = "ℹ";
            this.about.UseVisualStyleBackColor = true;
            this.about.Click += new System.EventHandler(this.about_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 223);
            this.Controls.Add(this.about);
            this.Controls.Add(this.settings);
            this.Controls.Add(this.top);
            this.Controls.Add(this.ranget);
            this.Controls.Add(this.result);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "随机点号器";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private Label result;
        private Button ranget;
        private Button top;
        private Button settings;
        private Button about;
    }
}