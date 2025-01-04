namespace incercarea1
{
    partial class UCAddProject
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.colorBTN = new System.Windows.Forms.Button();
            this.titleTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.descriptionTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.closeBTN = new System.Windows.Forms.Button();
            this.saveBTN = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.assignToUserCLB = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // colorBTN
            // 
            this.colorBTN.Location = new System.Drawing.Point(495, 41);
            this.colorBTN.Name = "colorBTN";
            this.colorBTN.Size = new System.Drawing.Size(116, 63);
            this.colorBTN.TabIndex = 0;
            this.colorBTN.Text = "Pick a color";
            this.colorBTN.UseVisualStyleBackColor = true;
            this.colorBTN.Click += new System.EventHandler(this.ColorBTN_Click);
            // 
            // titleTB
            // 
            this.titleTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleTB.Location = new System.Drawing.Point(84, 41);
            this.titleTB.Name = "titleTB";
            this.titleTB.Size = new System.Drawing.Size(405, 24);
            this.titleTB.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Titlu:";
            // 
            // descriptionTB
            // 
            this.descriptionTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionTB.Location = new System.Drawing.Point(139, 80);
            this.descriptionTB.MaxLength = 300;
            this.descriptionTB.Multiline = true;
            this.descriptionTB.Name = "descriptionTB";
            this.descriptionTB.Size = new System.Drawing.Size(350, 24);
            this.descriptionTB.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "Descriere:";
            // 
            // closeBTN
            // 
            this.closeBTN.Location = new System.Drawing.Point(164, 200);
            this.closeBTN.Name = "closeBTN";
            this.closeBTN.Size = new System.Drawing.Size(116, 31);
            this.closeBTN.TabIndex = 10;
            this.closeBTN.Text = "Close";
            this.closeBTN.UseVisualStyleBackColor = true;
            this.closeBTN.Click += new System.EventHandler(this.CloseBTN_Click);
            // 
            // saveBTN
            // 
            this.saveBTN.Location = new System.Drawing.Point(304, 200);
            this.saveBTN.Name = "saveBTN";
            this.saveBTN.Size = new System.Drawing.Size(116, 31);
            this.saveBTN.TabIndex = 11;
            this.saveBTN.Text = "Save";
            this.saveBTN.UseVisualStyleBackColor = true;
            this.saveBTN.Click += new System.EventHandler(this.SaveBTN_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 25);
            this.label3.TabIndex = 12;
            this.label3.Text = "Assign to:";
            // 
            // assignToUserCLB
            // 
            this.assignToUserCLB.FormattingEnabled = true;
            this.assignToUserCLB.Location = new System.Drawing.Point(139, 118);
            this.assignToUserCLB.Name = "assignToUserCLB";
            this.assignToUserCLB.Size = new System.Drawing.Size(346, 64);
            this.assignToUserCLB.TabIndex = 13;
            // 
            // UCAddProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.assignToUserCLB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.saveBTN);
            this.Controls.Add(this.closeBTN);
            this.Controls.Add(this.descriptionTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.titleTB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.colorBTN);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "UCAddProject";
            this.Size = new System.Drawing.Size(617, 244);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button colorBTN;
        private System.Windows.Forms.TextBox titleTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox descriptionTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button closeBTN;
        private System.Windows.Forms.Button saveBTN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckedListBox assignToUserCLB;
    }
}
