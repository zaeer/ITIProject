using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

using System.Threading.Tasks;
using System.Windows.Forms;

namespace SelectExam
{
    public partial class Exam : Form
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-GKCNC8V\SS17;Initial Catalog=ExamSys2;Integrated Security=True");
        public Exam()
        {
            InitializeComponent();
        }

        private void Exam_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "select ID,Email,Password from dbo.System where Email='" + textBox1.Text + "'and Password= '" + textBox2.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows.Count == 1)
            {
                int student_id = Convert.ToInt32(dtbl.Rows[0].ItemArray[0]);
                Exam objlogin = new Exam();
                this.Hide();
                objlogin.Show();

                SelectExam cho = new SelectExam(student_id);
                cho.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Check Your User and Password");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

    }
}

