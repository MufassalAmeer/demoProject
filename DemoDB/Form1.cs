using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoDB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillDataGrid();
        }

        private void FillDataGrid()
        {
            dataGridView1.DataSource = new Student().allStudents();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool res = new Student(Convert.ToInt32(txtID.Text),txtName.Text,Convert.ToInt32(txtAge.Text)).addStudent();

            if (res == true)
            {
                MessageBox.Show("stuent added Successfully");
                FillDataGrid();
            }
            else
            {
                MessageBox.Show("FAILED TO  add Student");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool res = new Student(Convert.ToInt32(txtID.Text), txtName.Text, Convert.ToInt32(txtAge.Text)).UpdateStudent();

            if (res == true)
            {
                MessageBox.Show("stuent Updated Successfully");
                FillDataGrid();
            }
            else
            {
                MessageBox.Show("FAILED TO  Update Student");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool res = new Student(Convert.ToInt32(txtID.Text)).DeleteStudent();

            if (res == true)
            {
                MessageBox.Show("stuent Deleted Successfully");
                FillDataGrid();
            }
            else
            {
                MessageBox.Show("FAILED TO  Delete Student");
            }
        }
    }
}
