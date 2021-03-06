﻿using System;
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
    public partial class Lecture : Form
    {
        ListBox list;
        OpenFileDialog ofd;
        public Lecture(ListBox list)
        {
            InitializeComponent();
            this.list = list;
            this.BackColor = Color.FromArgb(60, 60, 60);
            this.ForeColor = Color.FromArgb(128, 128, 128);
        }
        public Lecture()
        {
            InitializeComponent();
            stu = new StudentWindow();
            this.BackColor = Color.FromArgb(60, 60, 60);
            this.ForeColor = Color.FromArgb(128, 128, 128);
        }
        StudentWindow stu;
        private void Button7_Click(object sender, EventArgs e)
        {
            MyObjectClass myobject = new MyObjectClass(txtcoursename.Text,txtFileBrowse.Text,txtFilePath.Text);
            myobject.coursename = txtcoursename.Text;
            myobject.filename = txtFileBrowse.Text;
            myobject.filepath = txtFilePath.Text;

            StreamWriter sw = new StreamWriter("ResourseList.txt", true);
            sw.WriteLine(myobject.ToString());
            sw.Close();
            txtcoursename.Clear();
            txtFileBrowse.Clear();
            txtFilePath.Clear();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            this.Refresh();

        }

        private void PictureBoxExit_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("ARE YOU SURE YOU WANT TO LOG OUT ?", "LOGING OUT", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
            }
        }

        private void BtnClearStuInfo_Click(object sender, EventArgs e)
        {
            cmbCourseCode.SelectedIndex = cmbSymbol.SelectedIndex = -1;
            txtExam.Clear();
            txtFgrade.Clear();
            txtID.Clear();
            txtMidterm.Clear();
            txtQuiz1.Clear();
            txtQuiz2.Clear();
        }

        private void BtnClearMessage_Click(object sender, EventArgs e)
        {
            richTxtAnoucements.Clear();
        }
        
        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            ofd = new OpenFileDialog();
            ofd.Filter = "PDF only|*.pdf";
            if (ofd.ShowDialog()== DialogResult.OK)
            {
                txtFilePath.Text = ofd.FileName;
                txtFileBrowse.Text = ofd.SafeFileName;
            }
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("Anouncements.txt", true);
            sw.WriteLine(richTxtAnoucements.Text);
            sw.WriteLine("--------------------------------------------------------------");
            richTxtAnoucements.Clear();
            sw.Close();
        }

        private void cmbCourseCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbCourseCode.SelectedIndex == 0)
            {
                txtCourseN.Text = "Intro to Electrical";
            }
            else if (cmbCourseCode.SelectedIndex == 1)
            {
                txtCourseN.Text = "Communication skills";
            }
            else if (cmbCourseCode.SelectedIndex == 2)
            {
                txtCourseN.Text = "Engineering maths";
            }
            else if (cmbCourseCode.SelectedIndex == 3)
            {
                txtCourseN.Text = "Physics";
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = new ListViewItem(txtCourseN.Text);
            lvi.SubItems.Add(txtID.Text);
            lvi.SubItems.Add(txtQuiz1.Text);
            lvi.SubItems.Add(txtQuiz2.Text);
            lvi.SubItems.Add(txtMidterm.Text);
            lvi.SubItems.Add(txtExam.Text);
            lvi.SubItems.Add(txtFgrade.Text);

            bool status =true;
            while (status)
            {
                status = false;
                if (cmbSymbol.SelectedIndex == -1)
                    MessageBox.Show("please choose grade symbol");
                else if (cmbCourseCode.SelectedIndex == -1)
                    MessageBox.Show("choose course");
                else if(String.IsNullOrEmpty(txtQuiz1.Text) || txtQuiz1.Text.Any(c => !char.IsNumber(c))
                    || String.IsNullOrEmpty(txtQuiz2.Text) || txtQuiz2.Text.Any(c => !char.IsNumber(c))
                    || String.IsNullOrEmpty(txtMidterm.Text) || txtMidterm.Text.Any(c => !char.IsNumber(c))
                    || String.IsNullOrEmpty(txtExam.Text) || txtExam.Text.Any(c => !char.IsNumber(c))
                    || String.IsNullOrEmpty(txtFgrade.Text) || txtFgrade.Text.Any(c => !char.IsNumber(c))
                    || String.IsNullOrEmpty(txtID.Text) || txtID.Text.Any(c => !char.IsNumber(c)))
                {
                    return;
                }
               
            }status = false;
            if (cmbSymbol.SelectedIndex != -1 && cmbCourseCode.SelectedIndex !=-1)
            { 
                lvi.SubItems.Add(cmbSymbol.SelectedItem.ToString());
                listView1.Items.Add(lvi);
                StreamWriter sw = new StreamWriter(cmbCourseCode.SelectedItem.ToString() + ".txt", true);
                String line = txtID.Text + "-" + txtCourseN.Text + "-" + txtQuiz1.Text + "-" + txtQuiz2.Text + "-" +
                               txtMidterm.Text + "-" + txtExam.Text + "-" + txtFgrade.Text + "-" + cmbSymbol.SelectedItem.ToString();
                sw.WriteLine(line);
                sw.Close();
            }
            
        }

        
    }
}

