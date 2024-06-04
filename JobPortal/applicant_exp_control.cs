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
    public partial class applicant_exp_control : UserControl
    {
        public applicant_exp_control()
        {
            InitializeComponent();
        }

        #region Properties
        [Category("Custom Props")]
        private int exp_id;

        public int exp_method
        {
            get { return exp_id; }
            set { exp_id = value; }
        }
        [Category("Custom Props")]
        private string job_title;

        public string job_title_method
        {
            get { return job_title; }
            set { job_title = value; job_title_text.Text = value; }
        }
        [Category("Custom Props")]
        private string company_name;

        public string company_name_method
        {
            get { return company_name; }
            set { company_name = value; duration_text.Text = value; }
        }
        [Category("Custom Props")]
        private string duration;

        public string duration_method
        {
            get { return duration; }
            set { duration = value; duration_text.Text = value; }
        }
        [Category("Custom Props")]
        private string contact_no;

        public string contact_no_method
        {
            get { return contact_no; }
            set { contact_no = value; contact_no_text.Text=value; }
        }




        #endregion
    }
}
