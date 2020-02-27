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
    public partial class administration : Form
    {
        public administration()
        {
            InitializeComponent();
            transcript = new Transcript();
            memberinfo = new memberinfor();
            myobject = new MyObjectClass();
            mydate = DateTime.Today;
            
        }

        Transcript transcript;
        memberinfor memberinfo;
        MyObjectClass myobject;
        DateTime mydate;
        String NameOfFile;

        private void btnclearStu_Click(object sender, EventArgs e)
        {
            txtnameStu.Text = txtsurnameStu.Text = txtcountryStu.Text = txtcityStu.Text = txtzipcodeStu.Text
                = listboxStu.Text = labelparticipant.Text = lnumber.Text = lEmail.Text = labelYearofadmition.Text =
                lStatusRegistration.Text="";
            rdbfemaleStu.Checked = rdbmaleStu.Checked = false;
            listboxStu.Items.Clear();
            comboBoxfacultyStu.SelectedIndex = comboBoxparticipant.SelectedIndex = comboboxdepartmentStu.SelectedIndex = -1;
            PictureBox4_Click(null,null);
        }
        public bool notempty()
        {
            if (
            txtnameStu.Text != "" & txtsurnameStu.Text != "" && txtcityStu.Text != "" && txtcountryStu.Text != ""
                && txtzipcodeStu.Text != "" && comboboxdepartmentStu.SelectedIndex != -1 &&
                comboBoxfacultyStu.SelectedIndex != -1 && comboBoxparticipant.SelectedIndex != -1 && rdbfemaleStu.Checked != false ||
                rdbmaleStu.Checked != false)
                return true;

            return false;
        }

        private void btnregisterStu_Click(object sender, EventArgs e)
        {

            listboxStu.Items.Clear();
            if (notempty())
            {
                myobject.firstname = txtnameStu.Text;
                myobject.surname = txtsurnameStu.Text;

                if (rdbfemaleStu.Checked)
                {
                    String genderfemale = "FEMALE";

                    myobject.gender = genderfemale;
                }
                else if (rdbmaleStu.Checked)
                {
                    String gendermale = "MALE";
                    myobject.gender = gendermale;
                }
                object combodepart = comboboxdepartmentStu.SelectedItem;
                object combofaculty = comboBoxfacultyStu.SelectedItem;
                object participantfied = comboBoxparticipant.SelectedItem;
                myobject.country = txtcountryStu.Text;
                myobject.city = txtcityStu.Text;
                myobject.zipcode = txtzipcodeStu.Text;
                myobject.faculty = combofaculty.ToString();
                myobject.department = combodepart.ToString();
                myobject.participationField = participantfied.ToString();
                lnumber.Text = myobject.studentEmployeenumber;
                myobject.myemail();
                myobject.myusername();
                lEmail.Text = myobject.email;
                listboxStu.Items.Add(myobject.firstname + "\t" + myobject.surname + " number: " + myobject.studentEmployeenumber);
                labelYearofadmition.Text = myobject.dateofadministration;
                lStatusRegistration.ForeColor = System.Drawing.Color.DarkGreen;
                lStatusRegistration.Text = "member registered";

                NameOfFile = myobject.studentEmployeenumber + ".txt";

                if (!File.Exists(NameOfFile))
                {
                    StreamWriter sw = new StreamWriter(NameOfFile);
                    sw.WriteLine(myobject.myTostring());
                    sw.Close();
                }
                else
                {
                    return;
                }

            }
            else
            {
                lStatusRegistration.ForeColor = System.Drawing.Color.Maroon;
                lStatusRegistration.Text = "fill all fields";
            }
           
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxparticipant.SelectedIndex == 0)
            {
                labelparticipant.Text = "EMPOYEE NUMBER";
            }
                
            else if (comboBoxparticipant.SelectedIndex == 1)
            {
                labelparticipant.Text = "STUDENT NUMBER";
            }
                
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            panelDesplay.Controls.Clear();
        }

        private void ComboBoxfacultyStu_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboboxdepartmentStu.Items.Clear();
            String[] engineering = { "Software engineering", "Electric and electronics engineering", "Civil enginnering" };
            
            if (comboBoxfacultyStu.SelectedIndex == 0)
            {
                comboboxdepartmentStu.Items.AddRange(engineering);
            }
                
            else if (comboBoxfacultyStu.SelectedIndex == 1)
            {
                String[] economics = { "Economics and finance", "Logistics and management", "Psychology" };
                comboboxdepartmentStu.Items.AddRange(economics);
            }
            else if (comboBoxfacultyStu.SelectedIndex == 2)
            {
                String[] comunic = { "Advertising", "Public relations", "Cinema and television" };
                comboboxdepartmentStu.Items.AddRange(comunic);
            }

        }

        private void VIEWTRANSCRIPTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelDesplay.Controls.Clear();
            readonfile(txtsearchStu.Text);
            transcript.Fname.Text = myobject.firstname;
            transcript.Lname.Text = myobject.surname;
            transcript.UniName.Text = myobject.universityname;
            transcript.Snumber.Text = myobject.studentEmployeenumber;
            transcript.label22.Text = myobject.dateofadministration;
            transcript.label26.Text = mydate.ToString();
            transcript.NDepartment.Text = myobject.department;
            if (myobject.gender.Equals("MALE"))
            {
                transcript.lblTitle.Text = "MR";
            }
            else if (myobject.gender.Equals("FEMALE"))
            {
                transcript.lblTitle.Text = "MRS|MISS";
            }

            readFile("PHY1002.txt");
            readFile("EEE1002.txt");
            readFile("MAT1006.txt");
            readFile("ENG1004.txt");

            panelDesplay.Controls.Add(transcript);
        }

        public void readFile(string filename)
        {
            try
            {
                StreamReader sr = new StreamReader(filename);
                String[] line;
                while (true)
                {
                    line = sr.ReadLine().Split('-');
                    if (line[0].Equals(txtsearchStu.Text)) break;
                    else if (line == null) break;
                    ;
                }
                sr.Close();
                ListViewItem lvi = new ListViewItem(line[1]);
                lvi.SubItems.Add(line[6]);
                lvi.SubItems.Add(line[7]);
                transcript.listView1.Items.Add(lvi);

            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Student does not exist");
            }
        }

        private void MEMBERINFORMATIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelDesplay.Controls.Clear();
            try
            {
                readonfile(txtsearchStu.Text);
                memberinfo.password.Text = myobject.studentEmployeenumber;
                memberinfo.fname.Text = myobject.firstname.ToUpper();
                memberinfo.lname.Text = myobject.surname.ToUpper();
                memberinfo.gender.Text = myobject.gender;
                memberinfo.country.Text = myobject.country.ToUpper();
                memberinfo.city.Text = myobject.city.ToUpper();
                memberinfo.zipCode.Text = myobject.zipcode.ToUpper();
                memberinfo.faculty.Text = myobject.faculty.ToUpper();
                memberinfo.department.Text = myobject.department.ToUpper();
                memberinfo.email.Text = myobject.email.ToLower();
                memberinfo.lblunivesityname.Text = myobject.universityname;
                memberinfo.participationfield.Text = myobject.participationField.ToUpper();
                memberinfo.studentEmployeeNo.Text = myobject.studentEmployeenumber;
                memberinfo.labeladministration.Text = myobject.dateofadministration;
                panelDesplay.Controls.Add(memberinfo);
            }
            catch (NullReferenceException)
            {

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

        private void BtnsearchStu_Click_1(object sender, EventArgs e)
        {
            readonfile(txtsearchStu.Text.Trim());

            if (txtsearchStu.Text == myobject.studentEmployeenumber)
            {
                listboxStu.Items.Add(myobject.firstname + "\t" + myobject.surname + " number: " + myobject.studentEmployeenumber);
            }
            else
            {
                lStatusRegistration.ForeColor = System.Drawing.Color.MediumBlue;
                lStatusRegistration.Text = "member not found";
            }


        }
        
        private void PictureBoxminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void PictureBoxclose_Click(object sender, EventArgs e)
        {

            DialogResult r = MessageBox.Show("ARE YOU SURE YOU WANT TO LOG OUT ?", "LOGING OUT", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
                this.Hide();
            }
        }
        private void txtsearchStu_Click(object sender, EventArgs e)
        {
            lStatusRegistration.Text = "";
        }

        private void btnupdateStu_Click(object sender, EventArgs e)
        {
            listboxStu.Items.Clear();

            if (!File.Exists(txtsearchStu.Text + ".txt"))
            {
                return;
            }
            else
            {
                StreamReader sr = new StreamReader(txtsearchStu.Text + ".txt");
                while (true)
                {
                    String[] list;
                    string str;

                    str = sr.ReadLine();
                    if (str == null) break;
                    list = str.Split("-".ToCharArray());
                    txtnameStu.Text = list[0];
                    txtsurnameStu.Text = list[1];
                    String gender = list[2];
                    if (gender.Equals("MALE"))
                        rdbmaleStu.Checked = true;
                    else if (gender.Equals("FEMALE"))
                        rdbmaleStu.Checked = true;
                    txtcountryStu.Text = list[3];
                    txtcityStu.Text = list[4];
                    txtzipcodeStu.Text = list[5];
                    comboBoxfacultyStu.SelectedItem = list[6];
                    comboboxdepartmentStu.SelectedItem = list[7];
                    comboBoxparticipant.SelectedItem = list[8];
                    lnumber.Text = list[9];
                    lEmail.Text = list[10];
                    myobject.studentEmployeenumber = list[11];
                    label23.Text = list[12];
                    myobject.dateofadministration = list[13];
                    myobject.username = list[14];

                }
                sr.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (notempty())
            {
                myobject.firstname = txtnameStu.Text;
                myobject.surname = txtsurnameStu.Text;

                if (rdbfemaleStu.Checked)
                {
                    String genderfemale = "FEMALE";

                    myobject.gender = genderfemale;
                }
                else if (rdbmaleStu.Checked)
                {
                    String gendermale = "MALE";
                    myobject.gender = gendermale;
                }
                object combodepart = comboboxdepartmentStu.SelectedItem;
                object combofaculty = comboBoxfacultyStu.SelectedItem;
                object participantfied = comboBoxparticipant.SelectedItem;
                myobject.country = txtcountryStu.Text;
                myobject.city = txtcityStu.Text;
                myobject.zipcode = txtzipcodeStu.Text;
                myobject.faculty = combofaculty.ToString();
                myobject.department = combodepart.ToString();
                myobject.participationField = participantfied.ToString();
                lnumber.Text = myobject.studentEmployeenumber;
                myobject.myemail();
                lEmail.Text = myobject.email;
                listboxStu.Items.Add(myobject.firstname + "\t" + myobject.surname + " number: " + myobject.studentEmployeenumber);
                labelYearofadmition.Text = myobject.dateofadministration;
                lStatusRegistration.ForeColor = System.Drawing.Color.DarkGreen;
                lStatusRegistration.Text = "UPDATED";

                NameOfFile = myobject.studentEmployeenumber + ".txt";

                if (File.Exists(NameOfFile))
                {
                    StreamWriter sw = new StreamWriter(NameOfFile);
                    sw.WriteLine(myobject.myTostring());
                    sw.Close();
                }
                else
                {
                    return;
                }
            }
        }

        private void listboxStu_DoubleClick_1(object sender, EventArgs e)
        {
            MEMBERINFORMATIONToolStripMenuItem_Click(null, null);
        }
    }
}
