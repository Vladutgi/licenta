namespace incercarea1
{
    partial class CreateAccount
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
            this.emailTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.usernameTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.closeBTN = new System.Windows.Forms.Button();
            this.createBTN = new System.Windows.Forms.Button();
            this.repeatPasswordTB = new System.Windows.Forms.TextBox();
            this.createPasswordTB = new System.Windows.Forms.TextBox();
            this.secretQuestionTB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.questionAnswerTB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.repeatAnswerTB = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // emailTB
            // 
            this.emailTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailTB.Location = new System.Drawing.Point(246, 78);
            this.emailTB.Name = "emailTB";
            this.emailTB.Size = new System.Drawing.Size(355, 24);
            this.emailTB.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 25);
            this.label1.TabIndex = 15;
            this.label1.Text = "E-mail Address:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 25);
            this.label2.TabIndex = 17;
            this.label2.Text = "Create Password:";
            // 
            // usernameTB
            // 
            this.usernameTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameTB.Location = new System.Drawing.Point(246, 42);
            this.usernameTB.Name = "usernameTB";
            this.usernameTB.Size = new System.Drawing.Size(355, 24);
            this.usernameTB.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(32, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 25);
            this.label3.TabIndex = 19;
            this.label3.Text = "Account Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(32, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(203, 25);
            this.label4.TabIndex = 21;
            this.label4.Text = "Repeat Password:";
            // 
            // closeBTN
            // 
            this.closeBTN.Location = new System.Drawing.Point(235, 303);
            this.closeBTN.Name = "closeBTN";
            this.closeBTN.Size = new System.Drawing.Size(85, 30);
            this.closeBTN.TabIndex = 5;
            this.closeBTN.Text = "Close";
            this.closeBTN.UseVisualStyleBackColor = true;
            this.closeBTN.Click += new System.EventHandler(this.CloseBTN_Click);
            // 
            // createBTN
            // 
            this.createBTN.Location = new System.Drawing.Point(330, 303);
            this.createBTN.Name = "createBTN";
            this.createBTN.Size = new System.Drawing.Size(85, 30);
            this.createBTN.TabIndex = 6;
            this.createBTN.Text = "Create";
            this.createBTN.UseVisualStyleBackColor = true;
            this.createBTN.Click += new System.EventHandler(this.CreateBTN_Click);
            // 
            // repeatPasswordTB
            // 
            this.repeatPasswordTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repeatPasswordTB.Location = new System.Drawing.Point(246, 150);
            this.repeatPasswordTB.Name = "repeatPasswordTB";
            this.repeatPasswordTB.PasswordChar = '*';
            this.repeatPasswordTB.Size = new System.Drawing.Size(355, 24);
            this.repeatPasswordTB.TabIndex = 4;
            // 
            // createPasswordTB
            // 
            this.createPasswordTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createPasswordTB.Location = new System.Drawing.Point(246, 114);
            this.createPasswordTB.MaxLength = 30;
            this.createPasswordTB.Name = "createPasswordTB";
            this.createPasswordTB.PasswordChar = '*';
            this.createPasswordTB.Size = new System.Drawing.Size(355, 24);
            this.createPasswordTB.TabIndex = 3;
            // 
            // secretQuestionTB
            // 
            this.secretQuestionTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.secretQuestionTB.Location = new System.Drawing.Point(246, 186);
            this.secretQuestionTB.Name = "secretQuestionTB";
            this.secretQuestionTB.Size = new System.Drawing.Size(355, 24);
            this.secretQuestionTB.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(32, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(188, 25);
            this.label5.TabIndex = 27;
            this.label5.Text = "Secret Question:";
            // 
            // questionAnswerTB
            // 
            this.questionAnswerTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.questionAnswerTB.Location = new System.Drawing.Point(246, 222);
            this.questionAnswerTB.Name = "questionAnswerTB";
            this.questionAnswerTB.PasswordChar = 'o';
            this.questionAnswerTB.Size = new System.Drawing.Size(355, 24);
            this.questionAnswerTB.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(32, 222);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(197, 25);
            this.label6.TabIndex = 29;
            this.label6.Text = "Question Answer:";
            // 
            // repeatAnswerTB
            // 
            this.repeatAnswerTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repeatAnswerTB.Location = new System.Drawing.Point(246, 258);
            this.repeatAnswerTB.Name = "repeatAnswerTB";
            this.repeatAnswerTB.PasswordChar = 'o';
            this.repeatAnswerTB.Size = new System.Drawing.Size(355, 24);
            this.repeatAnswerTB.TabIndex = 30;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(32, 258);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(178, 25);
            this.label7.TabIndex = 31;
            this.label7.Text = "Repeat Answer:";
            // 
            // CreateAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 374);
            this.Controls.Add(this.repeatAnswerTB);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.questionAnswerTB);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.secretQuestionTB);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.createBTN);
            this.Controls.Add(this.closeBTN);
            this.Controls.Add(this.repeatPasswordTB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.usernameTB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.createPasswordTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.emailTB);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CreateAccount";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox emailTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox usernameTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button closeBTN;
        private System.Windows.Forms.Button createBTN;
        private System.Windows.Forms.TextBox repeatPasswordTB;
        private System.Windows.Forms.TextBox createPasswordTB;
        private System.Windows.Forms.TextBox secretQuestionTB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox questionAnswerTB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox repeatAnswerTB;
        private System.Windows.Forms.Label label7;
    }
}