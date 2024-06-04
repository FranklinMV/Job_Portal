
namespace JobPortal
{
    partial class Applicant_Show_Jobs
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
            this.applicant_flow = new System.Windows.Forms.FlowLayoutPanel();
            this.job_search = new Guna.UI2.WinForms.Guna2TextBox();
            this.SuspendLayout();
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(12, 6);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(77, 26);
            this.guna2HtmlLabel1.TabIndex = 0;
            this.guna2HtmlLabel1.Text = "All Jobs";
            // 
            // applicant_flow
            // 
            this.applicant_flow.AutoScroll = true;
            this.applicant_flow.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.applicant_flow.Location = new System.Drawing.Point(12, 71);
            this.applicant_flow.Name = "applicant_flow";
            this.applicant_flow.Size = new System.Drawing.Size(799, 432);
            this.applicant_flow.TabIndex = 2;
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
            this.job_search.Location = new System.Drawing.Point(12, 32);
            this.job_search.Name = "job_search";
            this.job_search.PasswordChar = '\0';
            this.job_search.PlaceholderText = "Search Job Name";
            this.job_search.SelectedText = "";
            this.job_search.ShadowDecoration.Parent = this.job_search;
            this.job_search.Size = new System.Drawing.Size(329, 33);
            this.job_search.TabIndex = 1;
            this.job_search.TextChanged += new System.EventHandler(this.search_text_Changed);
            // 
            // Applicant_Show_Jobs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Beige;
            this.ClientSize = new System.Drawing.Size(815, 505);
            this.Controls.Add(this.applicant_flow);
            this.Controls.Add(this.job_search);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Name = "Applicant_Show_Jobs";
            this.Text = "Applicant_Show_Jobs";
            this.Load += new System.EventHandler(this.applicant_show_jobs_load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2TextBox job_search;
        private System.Windows.Forms.FlowLayoutPanel applicant_flow;
    }
}