using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginSystem
{
     class MyObjectClass
    {
        public String firstname { get; set; }
        public String surname { get; set; }
        public String gender { get; set; }
        public String zipcode { get; set; }
        public String city { get; set; }
        public String faculty { get; set; }
        public String department { get; set; }
        public String country { get; set; }
        public String email { get; set; }
        public String participationField { get; set; }
        public String studentEmployeenumber { get; set; }
        public String password { get; set; }
        public String universityname { get; set; }
        public String coursename { get; set; }
        public String filepath { get; set; }
        public String filename { get; set; }
        public String username { get; set; }
        public String dateofadministration { get; set; }

        public MyObjectClass()
        {
            this.firstname = null;
            this.surname = null;
            this.gender = null;
            this.country = null;
            this.city = null;
            this.zipcode = null;
            this.faculty = null;
            this.department = null;
            this.participationField=null;
            this.email = null;
            this.universityname = "UNISA";
            myusername();
            this.studentEmployeenumber=null;
            myStudentEmployerNumber();
            date();
            
        }
       
       public string date()
        {
           DateTime mydateofAdmin= DateTime.Today;
            dateofadministration = mydateofAdmin.ToString();
            return dateofadministration;
        }


        public MyObjectClass(String coursename,String filepath,String filename)
        {
            this.coursename = coursename;
            this.filepath = filepath;
            this.filename = filename;
        }
        
        Random r = new Random();
        public String myemail()
        {
            email = firstname + "." + surname + "@" + universityname + ".com";
            return email;
        }
        public String myStudentEmployerNumber()
        {
            int number = r.Next(10000,200000);
            return studentEmployeenumber = number.ToString();
        }
        
        public override string ToString()
        {
            return coursename + "\t" + filename + "\t" + filepath;
        }
        public String myusername()
        {
            username = firstname + "." + surname;
            return username;
        }
        public string myTostring()
        {
            return firstname + "-"+surname + "-" +gender+
                 "-" + country + "-" + city + "-" + zipcode + "-" + faculty + "-" +
                 department + "-" + participationField + "-" + studentEmployeenumber + "-" +
                  email + "-" + studentEmployeenumber + "-" + universityname 
                  + "-" + dateofadministration + "-" + username;
        }

    }
}
