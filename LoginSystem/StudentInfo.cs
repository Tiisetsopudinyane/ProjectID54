using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginSystem
{
    public partial class StudentInfo : Form
    {
        public StudentInfo(String name, String surname, String studentno, String department, String faculty,
             String country, String city, String zipcode, String email)
        {
            InitializeComponent();
            this.lblFName.Text = name;
            this.lblLName.Text = surname;
            this.lblStudentNo.Text = studentno;
            this.lblDepartment.Text = department;
            this.lblFaculty.Text = faculty;
            this.lblCountry.Text = country;
            this.lblCity.Text = city;
            this.lblZipCode.Text = zipcode;
            this.txtEmail.Text = email;
        }
        public StudentInfo(StudentWindow learner)
        {
            InitializeComponent();
            this.learner = learner;
            
        }
        StudentWindow learner;
       
        private void PictureBoxClose_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("ARE YOU SURE YOU WANT TO LOG OUT ?", "LOGING OUT", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void PictureBoxBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("you cant enroll subjects at the moment", "MESSAGE", MessageBoxButtons.OK);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("there is no results to display at this moment", "MESSAGE", MessageBoxButtons.OK);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("there is no timetable to display at the moment", "MESSAGE", MessageBoxButtons.OK);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("webside is under maintanance at the moment", "MESSAGE", MessageBoxButtons.OK); ;
        }
    }
}
