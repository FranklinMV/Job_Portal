
namespace JobPortal
{
    partial class Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.save = new Guna.UI2.WinForms.Guna2Button();
            this.logout = new Guna.UI2.WinForms.Guna2Button();
            this.profile = new Guna.UI2.WinForms.Guna2Button();
            this.jobs = new Guna.UI2.WinForms.Guna2Button();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.viewPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.save);
            this.guna2Panel1.Controls.Add(this.logout);
            this.guna2Panel1.Controls.Add(this.profile);
            this.guna2Panel1.Controls.Add(this.jobs);
            this.guna2Panel1.Controls.Add(this.guna2PictureBox1);
            this.guna2Panel1.Controls.Add(this.guna2HtmlLabel1);
            resources.ApplyResources(this.guna2Panel1, "guna2Panel1");
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            // 
            // save
            // 
            this.save.BackColor = System.Drawing.Color.Transparent;
            this.save.BorderRadius = 5;
            this.save.CheckedState.Parent = this.save;
            this.save.CustomImages.Parent = this.save;
            this.save.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(234)))), ((int)(((byte)(255)))));
            resources.ApplyResources(this.save, "save");
            this.save.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.save.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(234)))), ((int)(((byte)(255)))));
            this.save.HoverState.Parent = this.save;
            this.save.Image = global::JobPortal.Properties.Resources.bookmark_line1;
            this.save.ImageSize = new System.Drawing.Size(22, 22);
            this.save.Name = "save";
            this.save.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(234)))), ((int)(((byte)(255)))));
            this.save.ShadowDecoration.Parent = this.save;
            this.save.TextOffset = new System.Drawing.Point(5, 0);
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // logout
            // 
            this.logout.BackColor = System.Drawing.Color.Transparent;
            this.logout.BorderRadius = 5;
            this.logout.CheckedState.Parent = this.logout;
            this.logout.CustomImages.Parent = this.logout;
            this.logout.FillColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.logout, "logout");
            this.logout.ForeColor = System.Drawing.Color.Red;
            this.logout.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(234)))), ((int)(((byte)(255)))));
            this.logout.HoverState.Parent = this.logout;
            this.logout.Image = global::JobPortal.Properties.Resources.logout;
            this.logout.ImageOffset = new System.Drawing.Point(-5, 0);
            this.logout.ImageSize = new System.Drawing.Size(23, 23);
            this.logout.Name = "logout";
            this.logout.PressedColor = System.Drawing.Color.White;
            this.logout.ShadowDecoration.Parent = this.logout;
            this.logout.TextOffset = new System.Drawing.Point(-1, 0);
            this.logout.Click += new System.EventHandler(this.logout_Click);
            // 
            // profile
            // 
            this.profile.BackColor = System.Drawing.Color.Transparent;
            this.profile.BorderRadius = 5;
            this.profile.CheckedState.Parent = this.profile;
            this.profile.CustomImages.Parent = this.profile;
            this.profile.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(234)))), ((int)(((byte)(255)))));
            resources.ApplyResources(this.profile, "profile");
            this.profile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.profile.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(234)))), ((int)(((byte)(255)))));
            this.profile.HoverState.Parent = this.profile;
            this.profile.Image = global::JobPortal.Properties.Resources.user;
            this.profile.ImageOffset = new System.Drawing.Point(-6, 0);
            this.profile.ImageSize = new System.Drawing.Size(22, 22);
            this.profile.Name = "profile";
            this.profile.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(234)))), ((int)(((byte)(255)))));
            this.profile.ShadowDecoration.Parent = this.profile;
            this.profile.TextOffset = new System.Drawing.Point(-1, 0);
            this.profile.Click += new System.EventHandler(this.carGarage_Click);
            // 
            // jobs
            // 
            this.jobs.BackColor = System.Drawing.Color.Transparent;
            this.jobs.BorderRadius = 5;
            this.jobs.CheckedState.Parent = this.jobs;
            this.jobs.CustomImages.Parent = this.jobs;
            this.jobs.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(234)))), ((int)(((byte)(255)))));
            resources.ApplyResources(this.jobs, "jobs");
            this.jobs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.jobs.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(234)))), ((int)(((byte)(255)))));
            this.jobs.HoverState.Parent = this.jobs;
            this.jobs.Image = global::JobPortal.Properties.Resources.job;
            this.jobs.ImageOffset = new System.Drawing.Point(-8, 0);
            this.jobs.Name = "jobs";
            this.jobs.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(234)))), ((int)(((byte)(255)))));
            this.jobs.ShadowDecoration.Parent = this.jobs;
            this.jobs.TextOffset = new System.Drawing.Point(-2, 0);
            this.jobs.Click += new System.EventHandler(this.jobs_Click);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackgroundImage = global::JobPortal.Properties.Resources.Logo;
            resources.ApplyResources(this.guna2PictureBox1, "guna2PictureBox1");
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.ShadowDecoration.Parent = this.guna2PictureBox1;
            this.guna2PictureBox1.TabStop = false;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.guna2HtmlLabel1, "guna2HtmlLabel1");
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            // 
            // viewPanel
            // 
            resources.ApplyResources(this.viewPanel, "viewPanel");
            this.viewPanel.Name = "viewPanel";
            this.viewPanel.ShadowDecoration.Parent = this.viewPanel;
            this.viewPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.viewPanel_Paint);
            // 
            // Dashboard
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.Beige;
            this.Controls.Add(this.viewPanel);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Dashboard";
            this.Load += new System.EventHandler(this.OnLoad);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2Button logout;
        private Guna.UI2.WinForms.Guna2Button profile;
        private Guna.UI2.WinForms.Guna2Button jobs;
        private Guna.UI2.WinForms.Guna2Panel viewPanel;
        private Guna.UI2.WinForms.Guna2Button save;
    }
}

