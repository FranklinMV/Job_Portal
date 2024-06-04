using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace JobPortal
{
    public partial class employer_view_job : Form
    {

        private int job_id;
        private int job_status;
        private int new_status;
        private Employer_Jobs employe_jobs_show;
        public employer_view_job()
        {
            InitializeComponent();
        }

        public void setJobId(int id) {
            this.job_id = id;
        }

        public void show_employer_jobs(Employer_Jobs employe_jobs_show) {
            this.employe_jobs_show = employe_jobs_show;


        }

        private void view_job_load(object sender, EventArgs e)
        {
            FetchReplies();
            FetchStatusCombo();
            FetchJobData();

        }


        private void FetchStatusCombo() {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            string sql = "SELECT status FROM job_status";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand(sql, connection);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        status_combo.Items.Clear();

                        while (reader.Read())
                        {
                            string jobStatus = reader.GetString("status");
                            status_combo.Items.Add(jobStatus);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching job statuses: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        private void FetchJobData() {

            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            // SQL query to retrieve job data
            string sql = "SELECT jobs.job_title, job_application.job_id, job_status.status,jobs.job_status_id " +
                         "FROM job_application " +
                         "JOIN jobs ON jobs.id = job_application.job_id " +
                         "JOIN job_status ON job_status.id = jobs.job_status_id " +
                         "WHERE jobs.id = @id";

            // Create a MySqlConnection object
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    MySqlCommand command = new MySqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@id", job_id);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Access data from the reader
                            string jobTitle = reader.GetString("job_title");
                            int jobIdResult = reader.GetInt32("job_id");
                            string jobStatus = reader.GetString("status");
                            job_status = reader.GetInt32("job_status_id");

                            guna2TextBox1.Text = jobTitle;
                            status_combo.SelectedIndex = job_status - 1;
                            //Console.WriteLine("Job Title: " + jobTitle);
                            //Console.WriteLine("Job ID: " + jobIdResult);
                            //Console.WriteLine("Job Status: " + jobStatus);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }


        }

        private void FetchReplies() {


            flowLayoutPanel1.Controls.Clear();
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            string sql = "SELECT file_name, user_id, job_id, remarks, user.name FROM job_application JOIN user ON user.id = job_application.user_id WHERE job_id = @job_id";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // Create a MySqlCommand object
                    MySqlCommand command = new MySqlCommand(sql, connection);

                    // Assuming job_id is a parameter, set its value
                    command.Parameters.AddWithValue("@job_id", job_id);

                    // Execute the query and retrieve data
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string fileName = reader.GetString("file_name");
                            int userId = reader.GetInt32("user_id");
                            int jobId = reader.GetInt32("job_id");
                            string remarks = reader.GetString("remarks");
                            string userName = reader.GetString("name");
                            job_reply_control reply = new job_reply_control();
                            reply.name_method = userName;
                            reply.file_name_method = fileName;
                            reply.remarks_method = remarks;
                            flowLayoutPanel1.Controls.Add(reply);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions by displaying an error message
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
           
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (job_status != new_status) {
                string sql = "UPDATE `jobs` SET `job_status_id` = @value WHERE jobs.id = @id";
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        MySqlCommand command = new MySqlCommand(sql, connection);

                        command.Parameters.AddWithValue("@value", new_status);
                        command.Parameters.AddWithValue("@id", job_id);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Job status updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            employe_jobs_show.ReloadJobs();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("No rows were updated.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle any exceptions
                        MessageBox.Show("Error updating job status: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }


            }
        }


        private void Status_Changed(object sender, EventArgs e)
        {
            new_status = status_combo.SelectedIndex + 1;
        }
    }
}
