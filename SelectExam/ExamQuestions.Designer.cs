namespace SelectExam
{
    partial class ExamQuestions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btn_submit = new System.Windows.Forms.Button();
            this.lbl_course_name = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbl_timer = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_submit
            // 
            this.btn_submit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btn_submit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_submit.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_submit.Location = new System.Drawing.Point(1165, 85);
            this.btn_submit.Margin = new System.Windows.Forms.Padding(4);
            this.btn_submit.Name = "btn_submit";
            this.btn_submit.Size = new System.Drawing.Size(171, 70);
            this.btn_submit.TabIndex = 0;
            this.btn_submit.Text = "Submit";
            this.btn_submit.UseVisualStyleBackColor = false;
            this.btn_submit.Click += new System.EventHandler(this.btn_submit_Click);
            // 
            // lbl_course_name
            // 
            this.lbl_course_name.AutoSize = true;
            this.lbl_course_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_course_name.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_course_name.Location = new System.Drawing.Point(26, 143);
            this.lbl_course_name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_course_name.Name = "lbl_course_name";
            this.lbl_course_name.Size = new System.Drawing.Size(213, 29);
            this.lbl_course_name.TabIndex = 1;
            this.lbl_course_name.Text = "Exam for Course:";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            // 
            // lbl_timer
            // 
            this.lbl_timer.AutoSize = true;
            this.lbl_timer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_timer.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lbl_timer.Location = new System.Drawing.Point(587, 85);
            this.lbl_timer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_timer.Name = "lbl_timer";
            this.lbl_timer.Size = new System.Drawing.Size(67, 25);
            this.lbl_timer.TabIndex = 2;
            this.lbl_timer.Text = "00:00";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = global::SelectExam.Properties.Resources.iti_logo;
            this.pictureBox1.Location = new System.Drawing.Point(31, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(104, 140);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // ExamQuestions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1433, 977);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbl_timer);
            this.Controls.Add(this.lbl_course_name);
            this.Controls.Add(this.btn_submit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExamQuestions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExamQuestions";
            this.Load += new System.EventHandler(this.ExamQuestions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_submit;
        private System.Windows.Forms.Label lbl_course_name;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbl_timer;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}