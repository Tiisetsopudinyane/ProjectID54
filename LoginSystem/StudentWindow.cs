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

namespace LoginSystem
{
    public partial class StudentWindow : Form
    {
        public StudentWindow()
        {
            InitializeComponent();
            stu = new StudentInfo(this);
            read();
          
            myobject=new MyObjectClass();
        }
        MyObjectClass myobject;
        public StudentWindow(String name, String surname, String faculty, String department, String studentnumber, String country,
            String city, String zipcode, String email)
       {
            InitializeComponent();
            this.lblFName.Text = name;
            this.lblLName.Text = surname;
            this.lblFaculty.Text = faculty;
            this.lblDepartment.Text = department;
            this.lblstudentnumber.Text = studentnumber;
            this.scountry = country;
            this.scity = city;
            this.szipcode = zipcode;
            this.semail = email;
            myobject = new MyObjectClass();
            
       }
        String scountry = "",scity = "", szipcode = "", semail = "";
        
        //PLEASE CHECK THIS WINDOW.REPLACE TEXTBOX WITH LABELS.STUDENTS CANT FILL THEIR OWN QUIZS

         StudentInfo stu;
        private void StudentInfoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            stu = new StudentInfo(lblFName.Text,lblLName.Text, lblstudentnumber.Text,lblDepartment.Text,lblFaculty.Text
                ,scountry,scity,szipcode,semail);
            stu.ShowDialog();
        }

        
        private void PictureBoxRefreshPage_Click(object sender, EventArgs e)
        {
            this.Refresh();
            read();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            richTextBoxSetup.Text = " ";
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Object Reminder = "";
            Reminder = richTextBoxSetup.Text;
            checkedListBoxReminder.Items.Add(Reminder);
        }

        private void BlueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackColor = System.Drawing.Color.FromArgb(135,206,235);
        }

        private void RedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackColor = System.Drawing.Color.FromArgb(253,99,71);
        }

        private void GreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackColor = System.Drawing.Color.FromArgb(152,251,152);
        }

        private void NavaWhiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackColor = System.Drawing.Color.FromArgb(255,222,173);
        }

        private void MistyRoseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackColor = System.Drawing.Color.FromArgb(255,228,225);
        }

        private void OldLiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackColor = System.Drawing.Color.FromArgb(253,245,230);
        }

        private void GrayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackColor = System.Drawing.Color.FromArgb(128,128,128);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader sr = new StreamReader(txtCourseCode.Text+".txt");
                String[] line;
                while (true)
                {
                    line = sr.ReadLine().Split('-');
                    if (line[0].Equals(lblstudentnumber.Text)) break;
                    else if (line == null) break;
                    ;
                }
                sr.Close();
                txtCourseName.Text = line[1];
                txtQuiz1.Text = line[2];
                txtQuiz2.Text = line[3];
                txtMdterm.Text = line[4];
                txtFinalExam.Text = line[5];
                txtFinalGrade.Text = line[6];
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Course does not exist");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            checkedListBoxReminder.Items.Add(richTextBoxSetup.Text);
        }

        private void txtCourseCode_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtCourseCode.Text.Equals("<Enter course code>"))
                txtCourseCode.Clear();
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string[] list = listBox1.SelectedItem.ToString().Split("\t".ToCharArray());
            myobject = new MyObjectClass();
            myobject.filepath = list[1];

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = myobject.filepath;
            sfd.Filter= "PDF only|*.pdf";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Stream filestream = sfd.OpenFile();
                
                filestream.Close();
            }
        }

        private void PictureBoxminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void PictureBoxClose_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("ARE YOU SURE YOU WANT TO LOG OUT ?", "LOGING OUT", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
            {
                 Application.Exit();
            }
        }

        public void read()
        {
            listBox1.Items.Clear();
            listBoxAnnouncements.Items.Clear();

            StreamReader sr = new StreamReader("ResourseList.txt");
            while (true)
            {
                String line = sr.ReadLine();

                if (line == null) break;
                   listBox1.Items.Add(line);
            }
            sr.Close();



            StreamReader sr2 = new StreamReader("Anouncements.txt");
            while (true)
            {
                String line = sr2.ReadLine();
                if (line == null) break;
                listBoxAnnouncements.Items.Add(line);
            }
            sr2.Close();
        }
    }
}
