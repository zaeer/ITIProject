using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SelectExam
{

    public partial class SelectExam : Form
    {
        //SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=ExamSys;integrated security=true");

        //SqlCommand cmd;
        //SqlDataReader dr;


        //string ConnectionString = @"Data Source=.;Initial Catalog=Course;Integrated Security=True";
        //SqlConnection con;
        public int student_id { get; set; }
        public SelectExam(int _student_id)
        {
            InitializeComponent();
            student_id = _student_id;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //con.Open();

            //cmd = new SqlCommand("Select Crs_Name From Course", con);


            //dr = cmd.ExecuteReader();


            //while (dr.Read())

            //{
            //    comboBox1.Items.Add(dr[0]).ToString();
            //}

            //SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-GKCNC8V\SS17;Initial Catalog=ExamSys;integrated security=true");
            //SqlCommand cmd = new SqlCommand("Select Crs_ID, Crs_Name From Course", conn);
            //cmd.CommandType = CommandType.Text;
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //da.SelectCommand = cmd;
            //DataTable table1 = new DataTable();
            //da.Fill(table1);
            ////DataSet ds = new DataSet();
            ////da.Fill(ds);


            //comboBox1.DataSource = table1;
            //comboBox1.DisplayMember = "Crs_Name";
            //comboBox1.ValueMember = "Crs_ID"; 
            //    comboBox1.DataTextField = "company_name";
            //    comboBox1.DataValueField = "Company_ID";
            //    comboBox1.DataBind();
            //    comboBox1.Items.Insert(0, new ListItem("--Select--", "0"));
            //}
            //SqlDataAdapter dr = new SqlDataAdapter(Query_, ConnectionString);
            //DataSet ds = new DataSet();
            //dr.Fill(ds);
            //object dataum = ds.Tables[0];
            //return dataum;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-GKCNC8V\SS17;Initial Catalog=ExamSys2;integrated security=true");
            SqlCommand cmd = new SqlCommand("Select Crs_ID, Crs_Name From Course", conn);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand = cmd;
            DataTable table1 = new DataTable();
            da.Fill(table1);
            //DataSet ds = new DataSet();
            //da.Fill(ds);


            comboBox1.DataSource = table1;
            comboBox1.DisplayMember = "Crs_Name";
            comboBox1.ValueMember = "Crs_ID";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (student_id != 0)
            {
                var cours_name = comboBox1.Text.ToString();
                var examQuestions = new ExamQuestions(student_id, cours_name);
                examQuestions.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Student.");
                this.Close();
            }
        }
    }
}
