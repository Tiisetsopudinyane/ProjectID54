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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ad = new administration();
            lec = new Lecture();
            myobject = new MyObjectClass();
            this.BackColor = Color.FromArgb(60, 60, 60);
            this.ForeColor = Color.FromArgb(128, 128,128);

            //  MessageBox.Show("first login as ADMIN username(newuser), password(0000) then register yourself as lecture or student \n,please check your username and password to login", "FOR TESTING ONLY", MessageBoxButtons.OK);
        }

        administration ad;
        MyObjectClass myobject;
        Lecture lec;
      
    private void btnlogin_Click(object sender, EventArgs e)
        {

            if (comboboxloginas.SelectedIndex == 0)
            {
                if (txtusername.Text.Trim().Equals("newuser") && txtpassword.Text.Trim().Equals("0000"))
                {
                    ad.Show();
                    this.Hide();
                }
            }
            
            else if (comboboxloginas.SelectedIndex == 1)
            {
                
                String filename = txtpassword.Text;
                readonfile(filename);
                if (txtusername.Text.Equals(myobject.username) && txtpassword.Text.Equals(myobject.studentEmployeenumber))
                {
                    lec.Show();
                    this.Hide();
                }

                else
                {
                    label4.ForeColor = System.Drawing.Color.BurlyWood;
                    label4.Text = "WRONG USER INPUTS";
                }
            }
            else if (comboboxloginas.SelectedIndex == 2)
            {
                
                String filename = txtpassword.Text;
                readonfile(filename);
                if (txtusername.Text.Equals(myobject.username) && txtpassword.Text.Equals(myobject.studentEmployeenumber))
                {
                    StudentWindow student = new StudentWindow(myobject.firstname.ToUpper(),myobject.surname.ToUpper()
                        ,myobject.faculty,myobject.department,myobject.studentEmployeenumber,
                        myobject.country.ToUpper(),myobject.city.ToUpper(),myobject.zipcode,myobject.email);
                    student.Show();
                    this.Hide();
                }
                else
                {
                    label4.ForeColor = System.Drawing.Color.BurlyWood;
                    label4.Text = "WRONG USER INPUTS";
                }
                
            }
           
        }
        public void readonfile(String number)
        {

            if (!File.Exists(number + ".txt"))
            {
                return;
            }
            else
            {
                StreamReader sr = new StreamReader(number + ".txt");
                while (true)
                {
                    String[] list;
                    string str;

                    str = sr.ReadLine();
                    if (str == null) break;
                    list = str.Split("-".ToCharArray());
                    myobject.firstname = list[0];
                    myobject.surname = list[1];
                    myobject.gender = list[2];
                    myobject.country = list[3];
                    myobject.city = list[4];
                    myobject.zipcode = list[5];
                    myobject.faculty = list[6];
                    myobject.department = list[7];
                    myobject.participationField = list[8];
                    myobject.studentEmployeenumber = list[9];
                    myobject.email = list[10];
                    myobject.password = list[11];
                    myobject.universityname = list[12];
                    myobject.dateofadministration = list[13];
                    myobject.username = list[14];

                }
                sr.Close();
            }
        }

        private void txtusername_Click(object sender, EventArgs e)
        {
            label4.Text = "forgot password ?";
            label4.ForeColor = System.Drawing.Color.Black;
        }

        private void txtpassword_Click(object sender, EventArgs e)
        {
            label4.Text = "forgot password ?";
            label4.ForeColor = System.Drawing.Color.Black;
        }

        private void Btnclear_Click_1(object sender, EventArgs e)
        {
            label4.Text = "forgot password ?";
            label4.ForeColor = System.Drawing.Color.Black;
            txtpassword.Text = txtusername.Text = "";
            comboboxloginas.SelectedIndex = -1;
        }

        private void Label4_Click_1(object sender, EventArgs e)
        {
            if(label4.Text.Equals("forgot password ?"))
            MessageBox.Show("USE THE DEFAULT PASSWORD", "MESSAGE !!!", MessageBoxButtons.OK);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
