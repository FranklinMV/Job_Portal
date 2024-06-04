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
    public partial class Employer_Dashboard : Form
    {

        private Form currentForm = null;
        private List<Guna2Button> sidebarButtons = new List<Guna2Button>();
        private int id;
        public Employer_Dashboard()
        {
            InitializeComponent();
            sidebarButtons.Add(jobs);
            sidebarButtons.Add(logout);
            sidebarButtons.Add(profile);
        }
        public void GetCompany(int id)
        {
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

        private void employer_load(object sender, EventArgs e)
        {
            Employer_Jobs Employer_Jobs = new Employer_Jobs();
            Employer_Jobs.setId(id);
            ShowForm(Employer_Jobs);
        }

        private void jobs_Click(object sender, EventArgs e)
        {
            Guna2Button clickedButton = (Guna2Button)sender;
            ChangeColor(clickedButton);
            Employer_Jobs Employer_Jobs = new Employer_Jobs();
            Employer_Jobs.setId(id);
            ShowForm(Employer_Jobs);
        }

        private void profile_Click(object sender, EventArgs e)
        {
            Guna2Button clickedButton = (Guna2Button)sender;
            ChangeColor(clickedButton);
            Employer_Profile profile = new Employer_Profile();
            profile.setId(id);
            ShowForm(profile);
        }

        private void logout_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.FormClosed += (s, args) => this.Close();

            login.Show();
            this.Hide();
        }
    }
}
