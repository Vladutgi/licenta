namespace incercarea1.Forms
{
    partial class ChangePasswordForm
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
            this.completeBTN = new System.Windows.Forms.Button();
            this.closeBTN = new System.Windows.Forms.Button();
            this.repeatPasswordTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.newPasswordTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.questionAnswerTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.emailTB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // completeBTN
            // 
            this.completeBTN.Location = new System.Drawing.Point(330, 195);
            this.completeBTN.Name = "completeBTN";
            this.completeBTN.Size = new System.Drawing.Size(85, 30);
            this.completeBTN.TabIndex = 25;
            this.completeBTN.Text = "Complete";
            this.completeBTN.UseVisualStyleBackColor = true;
            this.completeBTN.Click += new System.EventHandler(this.CompleteBTN_Click);
            // 
            // closeBTN
            // 
            this.closeBTN.Location = new System.Drawing.Point(235, 195);
            this.closeBTN.Name = "closeBTN";
            this.closeBTN.Size = new System.Drawing.Size(85, 30);
            this.closeBTN.TabIndex = 24;
            this.closeBTN.Text = "Close";
            this.closeBTN.UseVisualStyleBackColor = true;
            this.closeBTN.Click += new System.EventHandler(this.CloseBTN_Click);
            // 
            // repeatPasswordTB
            // 
            this.repeatPasswordTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repeatPasswordTB.Location = new System.Drawing.Point(235, 125);
            this.repeatPasswordTB.Name = "repeatPasswordTB";
            this.repeatPasswordTB.PasswordChar = '*';
            this.repeatPasswordTB.Size = new System.Drawing.Size(369, 24);
            this.repeatPasswordTB.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(29, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(203, 25);
            this.label4.TabIndex = 27;
            this.label4.Text = "Repeat Password:";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(55, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(562, 40);
            this.label1.TabIndex = 31;
            this.label1.Text = "Insert your new password in the fields.";
            // 
            // newPasswordTB
            // 
            this.newPasswordTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newPasswordTB.Location = new System.Drawing.Point(235, 95);
            this.newPasswordTB.MaxLength = 30;
            this.newPasswordTB.Name = "newPasswordTB";
            this.newPasswordTB.PasswordChar = '*';
            this.newPasswordTB.Size = new System.Drawing.Size(369, 24);
            this.newPasswordTB.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 25);
            this.label2.TabIndex = 33;
            this.label2.Text = "New Password:";
            // 
            // questionAnswerTB
            // 
            this.questionAnswerTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.questionAnswerTB.Location = new System.Drawing.Point(235, 155);
            this.questionAnswerTB.Name = "questionAnswerTB";
            this.questionAnswerTB.PasswordChar = '*';
            this.questionAnswerTB.Size = new System.Drawing.Size(369, 24);
            this.questionAnswerTB.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 25);
            this.label3.TabIndex = 35;
            this.label3.Text = "Question Answer:";
            // 
            // emailTB
            // 
            this.emailTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailTB.Location = new System.Drawing.Point(235, 61);
            this.emailTB.MaxLength = 30;
            this.emailTB.Name = "emailTB";
            this.emailTB.PasswordChar = '*';
            this.emailTB.Size = new System.Drawing.Size(369, 24);
            this.emailTB.TabIndex = 36;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(29, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 25);
            this.label5.TabIndex = 37;
            this.label5.Text = "Email Address:";
            // 
            // ChangePasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 266);
            this.Controls.Add(this.emailTB);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.questionAnswerTB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.newPasswordTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.completeBTN);
            this.Controls.Add(this.closeBTN);
            this.Controls.Add(this.repeatPasswordTB);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChangePasswordForm";
            this.Text = "ChangePasswordForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button completeBTN;
        private System.Windows.Forms.Button closeBTN;
        private System.Windows.Forms.TextBox repeatPasswordTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox newPasswordTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox questionAnswerTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox emailTB;
        private System.Windows.Forms.Label label5;
    }
}