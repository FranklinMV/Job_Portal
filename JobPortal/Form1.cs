using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JobPortal
{
    public partial class Dashboard : Form
    {
        private Form currentForm = null;
        private List<Guna2Button> sidebarButtons = new List<Guna2Button>();
        private int id;
        public Dashboard()
        {
            InitializeComponent();
            sidebarButtons.Add(jobs);
            sidebarButtons.Add(logout);
            sidebarButtons.Add(profile);
            sidebarButtons.Add(save);

        }

        public void GetApplicantId(int id) {
            this.id = id;
        }


        private void ShowForm(Form form)
        {
            if (currentForm == form)
            {
                return;
            }

            viewPanel.Controls.Clear();

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            viewPanel.Controls.Add(form);

            currentForm = form;

            form.Show();
        }
        private void ChangeColor(Guna2Button clickedButton)
        {
            clickedButton.FillColor = Color.FromArgb(218, 234, 255);
            // Set the background color of other buttons to transparent
            foreach (Guna2Button button in sidebarButtons)
            {
                if (button != clickedButton)
                {
                    button.FillColor = Color.Transparent;
                }
            }
        }

        private void OnLoad(object sender, EventArgs e)
        {
            Applicant_Show_Jobs applicant_jobs = new Applicant_Show_Jobs();
            applicant_jobs.getId(id);

            ShowForm(applicant_jobs);
        }

        private void carGarage_Click(object sender, EventArgs e)
        {
            Guna2Button clickedButton = (Guna2Button)sender;
            ChangeColor(clickedButton);
            Applicant_Profile profile = new Applicant_Profile();
            profile.getId(id);
            ShowForm(profile);
        }

        private void jobs_Click(object sender, EventArgs e)
        {
            Guna2Button clickedButton = (Guna2Button)sender;
            ChangeColor(clickedButton);
            Applicant_Show_Jobs applicant_jobs = new Applicant_Show_Jobs();
            applicant_jobs.getId(id);
            ShowForm(applicant_jobs);
        }

        private void logout_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.FormClosed += (s, args) => this.Close();

            login.Show();
            this.Hide();
        }

        private void save_Click(object sender, EventArgs e)
        {
            Guna2Button clickedButton = (Guna2Button)sender;
            ChangeColor(clickedButton);
            applicant_save_jobs applicant_save_jobs = new applicant_save_jobs();
            applicant_save_jobs.setId(id);
            ShowForm(applicant_save_jobs);
        }

        private void viewPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
