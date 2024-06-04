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
    public partial class Employer_Jobs : Form
    {

        private int id;
        public Employer_Jobs()
        {
            InitializeComponent();
        }


        public void setId(int id) {
            this.id = id;
        }

        public void ReloadJobs() {
            PopulateFlowLayoutPanel(null);
        }

        public void PopulateFlowLayoutPanel(string search)
        {

            try
            {
                flowLayoutPanel1.Controls.Clear();
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                string query;

                if (string.IsNullOrEmpty(search))
                {
                    query = @"
                                SELECT 
                                    jobs.*, 
                                    job_status.status,
                                    DATE(jobs.added_at) AS added_date,
                                    (SELECT COUNT(*) FROM job_application WHERE job_application.job_id = jobs.id) AS replies
                                FROM 
                                    jobs
                                JOIN job_status ON job_status.id = jobs.job_status_id
                                WHERE 
                                    jobs.company_id = @id";

                }
                else {
                    query = @"
                                SELECT 
                                    jobs.*, 
                                    job_status.status,
                                    DATE(jobs.added_at) AS added_date,
                                    (SELECT COUNT(*) FROM job_application WHERE job_application.job_id = jobs.id) AS replies
                                FROM 
                                    jobs
                                JOIN job_status ON job_status.id = jobs.job_status_id
                                WHERE 
                                    jobs.company_id = @id AND jobs.job_title LIKE @search";
                }
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", id);
                    if (!string.IsNullOrEmpty(search))
                    {
                        command.Parameters.AddWithValue("@search", $"%{search}%");

                    }
                    connection.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customer_job_control customerControl = new customer_job_control();
                            customerControl.job_role_method = reader["job_title"].ToString();
                            customerControl.location_method = reader["location"].ToString();
                            customerControl.reply_method = Convert.ToInt32(reader["replies"]);
                            customerControl.rate_method = Convert.ToDouble(reader["rate_per_hour"]);
                            customerControl.job_id_method = Convert.ToInt32(reader["id"]);
                            customerControl.date_method = Convert.ToDateTime(reader["added_date"]).ToString("yyyy/MM/dd");
                            customerControl.user_type_method = 2;
                            customerControl.job_status_method = reader["status"].ToString();
                            customerControl.employer_show_jobs(this);
                            flowLayoutPanel1.Controls.Add(customerControl);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("MySQL Error: " + ex.Message + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            AddJobs add =new AddJobs(this);
            add.setId(id);
            add.Show();
        }

        private void employer_jobs_load(object sender, EventArgs e)
        {
            PopulateFlowLayoutPanel(null);
        }

        private void search_text_change(object sender, EventArgs e)
        {
            string search = job_search.Text;
            if (string.IsNullOrEmpty(search))
            {
                PopulateFlowLayoutPanel(null);
            }
            else
            {

                PopulateFlowLayoutPanel(search);
            }
        }
    }
}
