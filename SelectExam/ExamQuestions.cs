using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SelectExam
{
    public partial class ExamQuestions : Form
    {
        public int student_id { get; set; }
        public int exam_id { get; set; }
        public string cours_name { get; set; }
        public double sumOfPoints { get; set; }
        static string connectionstring = @"Data Source=DESKTOP-GKCNC8V\SS17;Initial Catalog=ExamSys2;integrated security=true";
        private int counter = 600;//600=10MINUTS
        public ExamQuestions(int _student_id, string _cours_name)
        {
            InitializeComponent();
            this.student_id = _student_id;
            this.cours_name = _cours_name;

        }

        private void ExamQuestions_Load(object sender, EventArgs e)
        {
            if (student_id == 0 || string.IsNullOrEmpty(cours_name))
            {
                MessageBox.Show("Invalid Exam Session Paramteres.");
                this.Close();
                return;
            }
            lbl_course_name.Text = cours_name + " Exam";
            SqlConnection con = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand("ExamGeneration", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Crs_Name", SqlDbType.VarChar).Value = cours_name;
            //TODO:randamize no of tfq and mcq.
            int noOfTFQ = 3, noOfMCQ = 7;
            GetRandominteger(out noOfMCQ, out noOfTFQ);
            cmd.Parameters.Add("@NoOfTFQ", SqlDbType.Int).Value = noOfTFQ;
            cmd.Parameters.Add("@NoOfMCQ", SqlDbType.Int).Value = noOfMCQ;
            con.Open();
            SqlDataAdapter sqldataAdapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sqldataAdapter.Fill(ds);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    try
                    {
                        exam_id = (int)ds.Tables[0].Rows[0].ItemArray[0];
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error : Check Name Of The Course");
                        //SelectExam cho = new SelectExam(student_id);
                        //cho.ShowDialog();
                        this.Close();
                    }
                }
                int offset_Y = 130;
                for (int i = 1; i < ds.Tables.Count; i++)
                {
                    if (ds.Tables[i].Rows.Count > 0)
                    {
                        this.Controls.Add(new Label()
                        {
                            Name = "Quize_" + i,
                            Text = "Q" + i + ") " + ds.Tables[i]?.Rows[0]?.ItemArray[0]?.ToString(),
                            Location = new Point(35, (75 + (i * offset_Y))),
                            Size = new Size(830, 13),
                            AutoSize = true,


                        });
                        this.Controls.Add(new Label()
                        {
                            Name = "Choise1_" + i,
                            Text = ds.Tables[i]?.Rows[0]?.ItemArray[1]?.ToString(),
                            Location = new Point(77, 112 + (i * offset_Y)),
                            Size = new Size(35, 13),
                            AutoSize = true
                        });
                        this.Controls.Add(new Label()
                        {
                            Name = "Choise2_" + i,
                            Text = ds.Tables[i]?.Rows[0]?.ItemArray[2]?.ToString(),
                            Location = new Point(442, 112 + (i * offset_Y)),
                            Size = new Size(35, 13),
                            AutoSize = true
                        });
                        //if (ds.Tables[i]?.Rows[0]?.ItemArray[3]?.ToString() == null)
                        this.Controls.Add(new Label()
                        {
                            Name = "Choise3_" + i,
                            Text = ds.Tables[i]?.Rows[0]?.ItemArray[3]?.ToString(),
                            Location = new Point(77, 149 + (i * offset_Y)),
                            Size = new Size(35, 13),
                            AutoSize = true
                        });
                        //                        if (ds.Tables[i]?.Rows[0]?.ItemArray[4]?.ToString() == null)
                        this.Controls.Add(new Label()
                        {
                            Name = "Choise4_" + i,
                            Text = ds.Tables[i]?.Rows[0]?.ItemArray[4]?.ToString(),
                            Location = new Point(442, 149 + (i * offset_Y)),
                            Size = new Size(35, 13),
                            AutoSize = true
                        });
                        this.Controls.Add(new TextBox()
                        {
                            Name = "txt_" + i.ToString(),
                            Location = new Point(957, 112 + (i * offset_Y)),
                            Size = new Size(85, 20),
                            AutoSize = true
                        });
                        this.Controls.Add(new Label()
                        {
                            Text = "_________________________________________________________________________________" +
            "___________________________________________",
                            Location = new Point(35, 176 + (i * offset_Y)),
                            Size = new Size(751, 13),
                            AutoSize = true
                        });
                    }
                }
            }

            con.Close();

            timer1.Interval = 1000;
            timer1.Start();
            timer1.Tick += new EventHandler(aTimer_Tick);
            timer1.Interval = 1000; // 1 second
            timer1.Start();

        }

        private void GetRandominteger(out int noOfMCQ, out int noOfTFQ)
        {
            try
            {
                do
                {
                    Random r = new Random();
                    noOfTFQ = r.Next(1, 10);
                    noOfMCQ = r.Next(1, 10);
                } while ((noOfMCQ + noOfTFQ) != 10);

            }
            catch
            {
                noOfTFQ = 3;
                noOfMCQ = 7;
            }
        }

        private void aTimer_Tick(object sender, EventArgs e)
        {
            counter--;
            if (counter == 0)
            {
                MessageBox.Show("The Time Elapsed.");
                timer1.Stop();
                SubmitExam();
            }
            TimeSpan time = TimeSpan.FromSeconds(counter);
            lbl_timer.Text = time.ToString(@"mm\:ss");
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            SubmitExam();

        }

        private void SubmitExam()
        {
            if (exam_id == 0 || student_id == 0 || string.IsNullOrEmpty(cours_name))
            {
                MessageBox.Show("Invalid Exam Session Paramteres. while submitting exam.");
                this.Close();
                return;
            }
            //[ExamAnswer] @St_ID INT , @Ex_ID INT , @Ans1 NVARCHAR(1) , @Ans2 NVARCHAR(1), @Ans3 NVARCHAR(1), @Ans4 NVARCHAR(1), @Ans5 NVARCHAR(1), @Ans6 NVARCHAR(1), @Ans7 NVARCHAR(1), @Ans8 NVARCHAR(1), @Ans9 NVARCHAR(1), @Ans10 NVARCHAR(1)
            SqlConnection con = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand("ExamAnswer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@St_ID", SqlDbType.Int).Value = student_id;
            cmd.Parameters.Add("@Ex_ID", SqlDbType.Int).Value = exam_id;

            cmd.Parameters.Add("@Ans1", SqlDbType.VarChar).Value = this.Controls.Find("txt_1", false).FirstOrDefault().Text.ToString();
            cmd.Parameters.Add("@Ans2", SqlDbType.VarChar).Value = this.Controls.Find("txt_2", false).FirstOrDefault().Text.ToString();
            cmd.Parameters.Add("@Ans3", SqlDbType.VarChar).Value = this.Controls.Find("txt_3", false).FirstOrDefault().Text.ToString();
            cmd.Parameters.Add("@Ans4", SqlDbType.VarChar).Value = this.Controls.Find("txt_4", false).FirstOrDefault().Text.ToString();
            cmd.Parameters.Add("@Ans5", SqlDbType.VarChar).Value = this.Controls.Find("txt_5", false).FirstOrDefault().Text.ToString();
            cmd.Parameters.Add("@Ans6", SqlDbType.VarChar).Value = this.Controls.Find("txt_6", false).FirstOrDefault().Text.ToString();
            cmd.Parameters.Add("@Ans7", SqlDbType.VarChar).Value = this.Controls.Find("txt_7", false).FirstOrDefault().Text.ToString();
            cmd.Parameters.Add("@Ans8", SqlDbType.VarChar).Value = this.Controls.Find("txt_8", false).FirstOrDefault().Text.ToString();
            cmd.Parameters.Add("@Ans9", SqlDbType.VarChar).Value = this.Controls.Find("txt_9", false).FirstOrDefault().Text.ToString();
            cmd.Parameters.Add("@Ans10", SqlDbType.VarChar).Value = this.Controls.Find("txt_10", false).FirstOrDefault().Text.ToString();

            con.Open();
            cmd.ExecuteNonQuery();

            //ALTER PROC [dbo].[ExamCorrection] @St_ID INT , @Ex_ID INT
            cmd = new SqlCommand("ExamCorrection", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@St_ID", SqlDbType.Int).Value = student_id;
            cmd.Parameters.Add("@Ex_ID", SqlDbType.Int).Value = exam_id;
            object result = cmd.ExecuteScalar();
            if (result != null)
            {
                sumOfPoints = Convert.ToDouble(result);
            }
            con.Close();
            if (sumOfPoints != 0d)
            {
                MessageBox.Show("Your Grad is: " + sumOfPoints);
                this.Close();
            }
            else
            {
                MessageBox.Show("Your Grad is not availabel.");
                this.Close();
            }
        }
    }
}
