
namespace JobPortal
{
    partial class applicant_save_jobs
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
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.job_search = new Guna.UI2.WinForms.Guna2TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(12, 6);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(111, 26);
            this.guna2HtmlLabel1.TabIndex = 4;
            this.guna2HtmlLabel1.Text = "Saved Jobs";
            // 
            // job_search
            // 
            this.job_search.BorderRadius = 5;
            this.job_search.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.job_search.DefaultText = "";
            this.job_search.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.job_search.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.job_search.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.job_search.DisabledState.Parent = this.job_search;
            this.job_search.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.job_search.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.job_search.FocusedState.Parent = this.job_search;
            this.job_search.ForeColor = System.Drawing.Color.Black;
            this.job_search.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.job_search.HoverState.Parent = this.job_search;
            this.job_search.IconRight = global::JobPortal.Properties.Resources.search;
            this.job_search.Location = new System.Drawing.Point(12, 33);
            this.job_search.Name = "job_search";
            this.job_search.PasswordChar = '\0';
            this.job_search.PlaceholderText = "Search Job Name";
            this.job_search.SelectedText = "";
            this.job_search.ShadowDecoration.Parent = this.job_search;
            this.job_search.Size = new System.Drawing.Size(329, 33);
            this.job_search.TabIndex = 5;
            this.job_search.TextChanged += new System.EventHandler(this.search_txt_change);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 72);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(799, 432);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // applicant_save_jobs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Beige;
            this.ClientSize = new System.Drawing.Size(815, 505);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.job_search);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Name = "applicant_save_jobs";
            this.Text = "applicant_save_jobs";
            this.Load += new System.EventHandler(this.save_jobs_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2TextBox job_search;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}