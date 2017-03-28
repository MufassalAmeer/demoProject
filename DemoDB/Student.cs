using DemoDB.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDB
{
    class Student
    {
        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private int _Age;

        public int Age
        {
            get { return _Age; }
            set { _Age = value; }
        }



        public Student() { }
        public Student(int Id)
        {
            _ID = Id;
            
        }

        public Student(int Id,string name,int age)
        {
            _ID = Id;
            _Name = name;
            _Age = age;
        }


        public bool addStudent()
        {
            string query = "insert into [dbo].[StudTB] values('"+ID+"','"+Name+"','"+Age+"')";
            bool res = new SystemDAL().executeNonQuerys(query);
            return res;
        }

        public bool UpdateStudent()
        {
            string query = "update [dbo].[StudTB] set [Name]='"+Name+"' ,[age]='"+Age+"' where [ID]='"+ID+"'";
            bool res = new SystemDAL().executeNonQuerys(query);
            return res;
        }

        public bool DeleteStudent()
        {
            string query = "delete from [dbo].[StudTB] where [ID]='"+ID+"'";
            bool res = new SystemDAL().executeNonQuerys(query);
            return res;
        }

        public List<Student> allStudents()
        {
            List<Student> stud = new List<Student>();
            string query = "select * from [dbo].[StudTB]";
            SqlDataReader reader = new SystemDAL().executeQuerys(query);
            while (reader.Read())
            {
                stud.Add(new Student(Convert.ToInt32(reader[0]), reader[1].ToString(), Convert.ToInt32(reader[2])));

            }
            return stud;
        }
    }
}
