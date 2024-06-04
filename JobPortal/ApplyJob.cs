using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using System.Configuration;



namespace JobPortal
{
    public partial class ApplyJob : Form
    {
        private string cvFilePath;
        private string cvFileName;
        private string uniqueFileName;
        private int job_id;
        private int user_id;
        private int company_id;
        private Applicant_Show_Jobs show_jobs;

        public ApplyJob()
        {
            InitializeComponent();
        }

        public void set_job_id(int id,int user_id,int company_id) {
            this.job_id = id;
            this.user_id = user_id;
            this.company_id = company_id;
            
        }

        public void ReloadOnSave(Applicant_Show_Jobs show_jobs) {
            this.show_jobs = show_jobs;
        
        }

        private void FetchJobData() {
            string query = "SELECT job_title, job_description, skill_preferred FROM jobs WHERE id = @id";

            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", job_id);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string jobTitle = reader["job_title"].ToString();
                                string description = BlobToString((byte[])reader["job_description"]);
                                string skillPreferred = BlobToString((byte[])reader["skill_preferred"]);
                                guna2TextBox3.Text = description;
                                guna2TextBox4.Text = skillPreferred;
                                guna2TextBox1.Text = jobTitle;

                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error");
                }
            }

        }
        private string BlobToString(byte[] blob)
        {
            return Encoding.UTF8.GetString(blob);
        }


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "PDF files (*.pdf)|*.pdf|Word files (*.doc;*.docx)|*.doc;*.docx|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.Title = "Select a CV file";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    cvFilePath = openFileDialog.FileName;
                    cvFileName = Path.GetFileName(cvFilePath);

                    if (IsValidCVFile(cvFilePath))
                    {
                        uniqueFileName = GenerateUniqueFileName(cvFileName);
                        cv_name.Text = uniqueFileName;
                    }
                    else
                    {
                        MessageBox.Show("Please select a valid CV file (PDF, DOC, or DOCX).", "Invalid File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cvFilePath) && !string.IsNullOrEmpty(uniqueFileName))
            {
                string remark = guna2TextBox2.Text;

                // Establish a connection to your database
                using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString))
                {
                    try
                    {
                        // Open the database connection
                        connection.Open();

                        // Prepare the SQL INSERT statement with parameters
                        string insertQuery = "INSERT INTO `job_application`(`file_name`, `user_id`,`company_id`, `job_id`, `remarks`) " +
                                             "VALUES (@file_name, @user_id, @company_id,@job_id, @remarks)";

                        // Create a command object with the SQL statement and connection
                        using (MySqlCommand command = new MySqlCommand(insertQuery, connection))
                        {
                            // Add parameters to the command
                            command.Parameters.AddWithValue("@file_name", uniqueFileName); // Assuming the column is named file_name
                            command.Parameters.AddWithValue("@user_id", user_id); // Provide the actual user ID
                            command.Parameters.AddWithValue("@job_id", job_id); // Provide the actual job ID
                            command.Parameters.AddWithValue("@remarks", remark);
                            command.Parameters.AddWithValue("@company_id", company_id);
                            // Execute the SQL command
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Job application submitted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                SaveCVFile(cvFilePath, uniqueFileName);
                                //show_jobs.Reload();

                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Failed to submit job application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

         
            }
            else
            {
                MessageBox.Show("No file selected or unique file name not generated.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveCVFile(string sourcePath, string uniqueFileName)
        {
            string destinationDirectory = @"C:\Users\Dell\source\repos\JobPortal\JobPortal\Files"; 
            string destinationPath = Path.Combine(destinationDirectory, uniqueFileName);

            if (!Directory.Exists(destinationDirectory))
            {
                Directory.CreateDirectory(destinationDirectory);
            }

            File.Copy(sourcePath, destinationPath, overwrite: true); 
        }

        private string GenerateUniqueFileName(string originalFileName)
        {
            string extension = Path.GetExtension(originalFileName);
            string uniqueName = Guid.NewGuid().ToString();
            return uniqueName + extension;
        }

        private bool IsValidCVFile(string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLower();
            return File.Exists(filePath) && (extension == ".pdf" || extension == ".doc" || extension == ".docx");
        }

        private void Apply_Load(object sender, EventArgs e)
        {
            FetchJobData();
        }
    }
}
