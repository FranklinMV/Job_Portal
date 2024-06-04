using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JobPortal
{
    public partial class AddJobs : Form
    {


        private Employer_Jobs employe_job;
        private int id;
        public AddJobs(Employer_Jobs employe_job)
        {
            InitializeComponent();
            this.employe_job = employe_job;
        }

        public void setId(int id) {
            this.id = id;
        }
        private void employment_type_txt_change(object sender, EventArgs e)
        {

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string query = "SELECT employment FROM employment_type";
                    MySqlCommand command = new MySqlCommand(query, connection);

                    connection.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();

                        while (reader.Read())
                        {
                            autoCompleteCollection.Add(reader["employment"].ToString());
                        }

                        employment_type.AutoCompleteCustomSource = autoCompleteCollection;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exp_textChange(object sender, EventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string query = "SELECT experience FROM experience_level";
                    MySqlCommand command = new MySqlCommand(query, connection);

                    connection.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();

                        while (reader.Read())
                        {
                            autoCompleteCollection.Add(reader["experience"].ToString());
                        }

                        experience_level.AutoCompleteCustomSource = autoCompleteCollection;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void work_arrangement_textChange(object sender, EventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string query = "SELECT work FROM work_arrangement";
                    MySqlCommand command = new MySqlCommand(query, connection);

                    connection.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();

                        while (reader.Read())
                        {
                            autoCompleteCollection.Add(reader["work"].ToString());
                        }

                        work_arrangement.AutoCompleteCustomSource = autoCompleteCollection;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void saveClick(object sender, EventArgs e)
        {
            byte[] skill_required = StringToBlob(skill.Text);
            byte[] job_description = StringToBlob(description.Text);
            List<string> fieldsToValidate = new List<string> { job.Text, employment_type.Text, experience_level.Text, required_work_exp.Text, education_level.Text, rate.Text, work_arrangement.Text, location.Text, skill.Text, description.Text };
            if (ValidateFields(fieldsToValidate,rate)) {
                try
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();

                        string query = "INSERT INTO jobs (company_id,job_title, employment_type, experience_level, required_work_experience, education_level, rate_per_hour, work_arrangement,location ,skill_preferred, job_description,job_status_id) VALUES (@id,@JobTitle, @EmploymentType, @ExperienceLevel, @RequiredWorkExperience, @EducationLevel, @RatePerHour, @WorkArrangement,@location ,@SkillPreferred, @JobDescription,@job_status_id)";

                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@id", id);
                            command.Parameters.AddWithValue("@JobTitle", fieldsToValidate[0].ToUpper());
                            command.Parameters.AddWithValue("@EmploymentType", fieldsToValidate[1].ToUpper());
                            command.Parameters.AddWithValue("@ExperienceLevel", fieldsToValidate[2].ToUpper());
                            command.Parameters.AddWithValue("@RequiredWorkExperience", fieldsToValidate[3].ToUpper());
                            command.Parameters.AddWithValue("@EducationLevel", fieldsToValidate[4].ToUpper());
                            command.Parameters.AddWithValue("@RatePerHour", fieldsToValidate[5].ToUpper());
                            command.Parameters.AddWithValue("@WorkArrangement", fieldsToValidate[6].ToUpper());
                            command.Parameters.AddWithValue("@location", fieldsToValidate[7].ToUpper());
                            command.Parameters.AddWithValue("@SkillPreferred", skill_required);
                            command.Parameters.AddWithValue("@JobDescription", job_description);
                            command.Parameters.AddWithValue("@job_status_id", 1);

                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Data saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                employe_job.ReloadJobs();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Failed to save data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        public static byte[] StringToBlob(string text)
        {
            return Encoding.UTF8.GetBytes(text);
        }

        public static bool ValidateFields(List<string> fields, Guna2TextBox rateTextBox)
        {
            foreach (string field in fields)
            {
                if (string.IsNullOrWhiteSpace(field))
                {
                    MessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            double rateValue;
            if (!Double.TryParse(rateTextBox.Text, out rateValue))
            {
                MessageBox.Show("Invalid Rate.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}
