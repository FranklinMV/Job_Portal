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
    public partial class applicant_save_jobs : Form
    {
        private int id;
        public applicant_save_jobs()
        {
            InitializeComponent();

        }

        public void setId(int id)
        {

            this.id = id;

        }
        public void Reload() {
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
                    query = @"SELECT 
                        save_jobs.jobs_id,
                        DATE(jobs.added_at) AS added_date,
                        jobs.job_title,
                        jobs.location,
                        jobs.rate_per_hour,
                        jobs.id AS job_id,
                        jobs.company_id,
                        2 AS isBookMark,
                        CASE 
                            WHEN EXISTS (SELECT 1 FROM job_application WHERE job_application.job_id = jobs.id AND job_application.user_id = @id) THEN 1
                            ELSE 0
                        END AS InApply,
                        (SELECT COUNT(*) FROM job_application WHERE job_application.job_id = jobs.id AND job_application.user_id = @id) AS replies
                    FROM 
                        save_jobs 
                    JOIN 
                        jobs ON jobs.id = save_jobs.jobs_id 
                    WHERE 
                        save_jobs.is_deleted = false 
                        AND save_jobs.user_id = @id
                            ";
                }
                else {
                    query = @"SELECT 
                        save_jobs.jobs_id,
                        DATE(jobs.added_at) AS added_date,
                        jobs.job_title,
                        jobs.location,
                        jobs.rate_per_hour,
                        jobs.id AS job_id,
                        jobs.company_id,
                        2 AS isBookMark,
                        CASE 
                            WHEN EXISTS (SELECT 1 FROM job_application WHERE job_application.job_id = jobs.id AND job_application.user_id = @id) THEN 1
                            ELSE 0
                        END AS InApply,
                        (SELECT COUNT(*) FROM job_application WHERE job_application.job_id = jobs.id AND job_application.user_id = @id) AS replies
                    FROM 
                        save_jobs 
                    JOIN 
                        jobs ON jobs.id = save_jobs.jobs_id 
                    WHERE 
                        save_jobs.is_deleted = false 
                        AND save_jobs.user_id = @id AND jobs.job_title LIKE @search
                            ";

                }
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", id);
                    if (!string.IsNullOrEmpty(search)) {
                        command.Parameters.AddWithValue("@search", $"%{search}%");

                    }
                    connection.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customer_job_control customerControl = new customer_job_control();
                            customerControl.job_id_method = Convert.ToInt32(reader["jobs_id"]);
                            customerControl.isApply_Method = Convert.ToInt32(reader["InApply"]);
                            customerControl.reply_method = Convert.ToInt32(reader["replies"]);
                            customerControl.company_id_method = Convert.ToInt32(reader["company_id"]);
                            customerControl.job_role_method = reader["job_title"].ToString();
                            customerControl.rate_method = Convert.ToDouble(reader["rate_per_hour"]);
                            customerControl.date_method = Convert.ToDateTime(reader["added_date"]).ToString("yyyy/MM/dd");
                            customerControl.location_method = reader["location"].ToString();
                            customerControl.user_type_method = 1;
                            customerControl.isBookMark_method = Convert.ToInt32(reader["isBookMark"]);
                            customerControl.user_id_method = id;
                            customerControl.isSave_method = 1;
                            customerControl.save_setup(this);
                            flowLayoutPanel1.Controls.Add(customerControl);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("MySQL Error: " + ex.Message +ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void save_jobs_Load(object sender, EventArgs e)
        {
            PopulateFlowLayoutPanel(null);
        }

        private void search_txt_change(object sender, EventArgs e)
        {
            string search = job_search.Text;
            if (!string.IsNullOrEmpty(search)) {
                PopulateFlowLayoutPanel(search);
                return;
            }
            PopulateFlowLayoutPanel(null);

        }
    }
}
