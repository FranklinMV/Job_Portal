using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Configuration;
using MySql.Data.MySqlClient;
namespace JobPortal
{
    public partial class customer_job_control : UserControl
    {
        private bool isBookmarkFilled = false;
        private applicant_save_jobs save;
        private Applicant_Show_Jobs show_jobs;
        private Employer_Jobs employer_jobs;
        public customer_job_control()
        {
            InitializeComponent();
            remove.Hide();
        }

        public void save_setup(applicant_save_jobs save) {

            this.save = save;    
        }

        public void show_jobs_apply(Applicant_Show_Jobs show_jobs) {

            this.show_jobs = show_jobs;
        }

        public void employer_show_jobs(Employer_Jobs employer_jobs) {
            this.employer_jobs = employer_jobs;
        
        }

        #region Properties
        [Category("Custom Props")]
        private string job_status;

        public string job_status_method
        {
            get { return job_status; }
            set { job_status = value; status_state.Text = value; }
        }

        [Category("Custom Props")]
        private  int company_id;

        public  int company_id_method 
        {
            get { return company_id; }
            set { company_id = value; }
        }

        [Category("Custom Props")]
        private int isApply;

        public int isApply_Method
        {
            get { return isApply; }
            set { isApply = value; }
        }

        [Category("Custom Props")]
        private string name;

        public string name_method
        {
            get { return name; }
            set { name = value;
    
         
                    company_text.Text = value;
                
               }
        }

        [Category("Custom Props")]
        private int isSave;

        public int isSave_method
        {
            get { return isSave; }
            set { isSave = value;
                if (value == 1)
                {
                    remove.Show();
                }
            }
        

        }

        [Category("Custom Props")]
        private int user_id;

        public int user_id_method
        {
            get { return user_id; }
            set { user_id = value; }
        }




        [Category("Custom Props")]
        private int isBookMark;

        public int isBookMark_method
        {
            get { return isBookMark; }
            set { isBookMark = value;
                if (isBookMark != 1) {
                    guna2PictureBox1.BackgroundImage = JobPortal.Properties.Resources.bookmark_fill;
                    isBookmarkFilled = true;
                    guna2PictureBox1.Enabled = false;
                }
            }
        }
        [Category("Custom Props")]
        private int user_type;

        public int user_type_method
        {
            get { return user_type; }
            set { user_type = value;
                if (user_type == 2) {
                    guna2PictureBox1.Hide();
                    company_text.Hide();
                }
            
            }
        }


        [Category("Custom Props")]
        private int job_id;

        public int job_id_method
        {
            get { return job_id; }
            set { job_id = value; }
        }

        [Category("Custom Props")]
        private string date;

        public string date_method
        {
            get
            {
                return date; 
            }
            set
            {
                date = value; 

                if (DateTime.TryParseExact(date, "yyyy/MM/dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                {
                    date_text.Text = parsedDate.ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                }
                else
                {
                    date_text.Text = "Invalid Date";
                }
            }
        }
        [Category("Custom Props")]
        private string job_role;

        public string job_role_method
        {
            get { return  job_role; }
            set { job_role = value; job_role_text.Text = value.Length > 20 ? value.Substring(0, 20)+"..." : value; }
        }
        [Category("Custom Props")]
        private int reply;

        public int reply_method
        {
            get { return reply; }
            set { reply = value; reply_text.Text = $"{value.ToString("D2")} Replies"; }
        }
        [Category("Custom Props")]
        private string location;

        public  string location_method
        {
            get { return  location; }
            set {  location = value; location_text.Text = value; }
        }
        [Category("Custom Props")]
        private double rate;

        public double rate_method
        {
            get { return rate; }
            set { rate = value; rate_text.Text = $"Php {value.ToString()} / Per Hour"; }
        }



        #endregion

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (user_type != 2)
            {
                if (isApply != 1)
                {
                    ApplyJob apply = new ApplyJob();
                    apply.set_job_id(job_id, user_id,company_id);
                    apply.ReloadOnSave(show_jobs);
                    apply.Show();

                }
            }
            else {
                employer_view_job view = new employer_view_job();
                view.setJobId(job_id);
                view.show_employer_jobs(employer_jobs);
                view.Show();

            }



        }

        private void userLoad(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(job_status)) {
                status_state.Hide();
            }

            if (user_type != 1)
            {
                guna2Button1.Text = "View";
            }
            if (isApply == 1)
            {
                guna2Button1.Text = "Applied";
                guna2Button1.Cursor = default;
                guna2Button1.HoverState.FillColor = Color.White;
                guna2Button1.PressedColor = Color.White;


            }
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

            if (isBookmarkFilled)
            {
                guna2PictureBox1.BackgroundImage = JobPortal.Properties.Resources.bookmark_line;

            }
            else
            {
                insertToSave();
                guna2PictureBox1.BackgroundImage = JobPortal.Properties.Resources.bookmark_fill;
                guna2PictureBox1.Enabled = false;

            }

            isBookmarkFilled = !isBookmarkFilled;
        }

        private void insertToSave() {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

                string sql = "INSERT INTO `save_jobs` (`user_id`, `jobs_id`) VALUES (@user_id, @jobs_id)";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@user_id", user_id);
                        command.Parameters.AddWithValue("@jobs_id", job_id);
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Job saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("MySQL Error: " + ex.Message + ex.StackTrace, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void remove_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

                string sql = "UPDATE save_jobs SET is_deleted = true WHERE user_id = @user_id AND jobs_id = @jobs_id";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@user_id", user_id);
                        command.Parameters.AddWithValue("@jobs_id", job_id);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Job removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            save.Reload();

                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("MySQL Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
