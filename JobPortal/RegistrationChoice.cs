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
    public partial class RegistrationChoice : Form
    {
        public RegistrationChoice()
        {
            InitializeComponent();
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.FormClosed += (s, args) => this.Close();

            login.Show();
            this.Hide();

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Applicant_Registration choice = new Applicant_Registration();
            choice.user_type(1);
            choice.FormClosed += (s, args) => this.Close();

            choice.Show();

            this.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Applicant_Registration choice = new Applicant_Registration();
            choice.user_type(2);
            choice.FormClosed += (s, args) => this.Close();

            choice.Show();

            this.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.FormClosed += (s, args) => this.Close();

            login.Show();
            this.Hide();
        }
    }
}
