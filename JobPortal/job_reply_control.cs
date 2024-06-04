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

namespace JobPortal
{
    public partial class job_reply_control : UserControl
    {
        public job_reply_control()
        {
            InitializeComponent();
        }


        #region Properties
        [Category("Custom Props")]
        private int reply_id;

        public int reply_id_method
        {
            get { return reply_id; }
            set { reply_id = value; }
        }
        [Category("Custom Props")]
        private string file_name;

        public string file_name_method
        {
            get { return file_name; }
            set { file_name = value; }
        }
        [Category("Custom Props")]
        private string remark;

        public string remarks_method
        {
            get { return remark; }
            set { remark = value;
                if (string.IsNullOrEmpty(value))
                {
                    remarks.Text = "N/A";
                }
                else {
                    remarks.Text = value;

                }
                
                }
        }

        [Category("Custom Props")]
        private string name_;

        public string name_method
        {
            get { return name_; }
            set { name_ = value; name.Text = value; }
        }





        #endregion

        private void guna2Button1_Click(object sender, EventArgs e)

        {
            if (!string.IsNullOrEmpty(file_name))
            {
                // Create a SaveFileDialog object
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = name_ + "-Resume - "+ file_name; // Set the default file name
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf|Word documents (*.doc;*.docx)|*.doc;*.docx|All files (*.*)|*.*";
                saveFileDialog.Title = "Save Resume";

                // Show the SaveFileDialog and check if the user clicked the OK button
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string destinationFilePath = saveFileDialog.FileName;

                    string sourceFilePath = Path.Combine(@"C:\Users\Dell\source\repos\JobPortal\JobPortal\Files", file_name);

                    try
                    {
                        File.Copy(sourceFilePath, destinationFilePath, true);

                        MessageBox.Show("File saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while saving the file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("File name not provided.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
