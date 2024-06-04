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
    public partial class Applicant_Show_Jobs : Form
    {

        int id;
        public Applicant_Show_Jobs()
        {
            InitializeComponent();
        }

        public void getId(int id) {
            this.id = id;

        }

        public void Reload() {
            PopulateFlowLayoutPanel(null);
        }
        public void PopulateFlowLayoutPanel(string search)
        {

            try
            {
                string query;
                applicant_flow.Controls.Clear(); // Clear existing controls before loading new data

                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                if (string.IsNullOrEmpty(search))
                {
                    query = @"SELECT 
                            DATE(jobs.added_at) AS added_date, 
                            jobs.job_title, 
                            jobs.location, 
                            jobs.rate_per_hour, 
                            jobs.id AS jobs_id,
                            jobs.company_id,
                            user.name,
                            CASE 
                                WHEN save_jobs.jobs_id IS NOT NULL AND save_jobs.is_deleted = false THEN 2 
                                ELSE 1
                            END AS isBookMark,
                            CASE 
                                WHEN job_application.id IS NOT NULL THEN 1
                                ELSE 0
                            END AS InApply,
                            (SELECT COUNT(*) FROM job_application WHERE job_application.job_id = jobs.id) AS replies
                        FROM 
                            jobs
                        LEFT JOIN 
                            save_jobs ON jobs.id = save_jobs.jobs_id AND save_jobs.user_id = @id AND save_jobs.is_deleted = false
                        JOIN
                            user ON user.id = jobs.company_id
                        LEFT JOIN
                            job_application ON jobs.id = job_application.job_id AND job_application.user_id = @id
                        WHERE 
                            jobs.Job_status_id = 1 
                        GROUP BY 
                            jobs.id";


                }
                else {
                    query = @"SELECT 
                            DATE(jobs.added_at) AS added_date, 
                            jobs.job_title, 
                            jobs.location, 
                            jobs.rate_per_hour, 
                            jobs.id AS jobs_id,
                            jobs.company_id,
                            user.name,
                            CASE 
                                WHEN save_jobs.jobs_id IS NOT NULL AND save_jobs.is_deleted = false THEN 2 
                                ELSE 1
                            END AS isBookMark,
                            CASE 
                                WHEN job_application.id IS NOT NULL THEN 1
                                ELSE 0
                            END AS InApply,
                            (SELECT COUNT(*) FROM job_application WHERE job_application.job_id = jobs.id) AS replies
                        FROM 
                            jobs
                        LEFT JOIN 
                            save_jobs ON jobs.id = save_jobs.jobs_id AND save_jobs.user_id = @id AND save_jobs.is_deleted = false
                        JOIN
                            user ON user.id = jobs.company_id
                        LEFT JOIN
                            job_application ON jobs.id = job_application.job_id AND job_application.user_id = @id
                        WHERE 
                            jobs.Job_status_id = 1 AND jobs.job_title LIKE @search
                        GROUP BY 
                            jobs.id";

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
                            customerControl.company_id_method = Convert.ToInt32(reader["company_id"]);
                            customerControl.reply_method = Convert.ToInt32(reader["replies"]);
                            customerControl.job_role_method = reader["job_title"].ToString();
                            customerControl.rate_method = Convert.ToDouble(reader["rate_per_hour"]);
                            customerControl.date_method = Convert.ToDateTime(reader["added_date"]).ToString("yyyy/MM/dd");
                            customerControl.location_method = reader["location"].ToString();
                            customerControl.user_type_method = 1;
                            customerControl.isBookMark_method = Convert.ToInt32(reader["isBookMark"]);
                            customerControl.name_method = reader["name"].ToString();
                            customerControl.user_id_method = id;
                            customerControl.show_jobs_apply(this);
                            applicant_flow.Controls.Add(customerControl);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("MySQL Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void applicant_show_jobs_load(object sender, EventArgs e)
        {

            PopulateFlowLayoutPanel(null);
        }

        private void search_text_Changed(object sender, EventArgs e)
        {
            string search = job_search.Text;
            if (string.IsNullOrEmpty(search))
            {
                PopulateFlowLayoutPanel(null);
            }
            else {

                PopulateFlowLayoutPanel(search);
            }

        }
    }
}
