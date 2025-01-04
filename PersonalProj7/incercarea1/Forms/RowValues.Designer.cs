namespace incercarea1
{
    partial class RowValues
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
            this.label1 = new System.Windows.Forms.Label();
            this.closeBTN = new System.Windows.Forms.Button();
            this.usersToBeAddedCLB = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(160, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(494, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select the users to be added:";
            // 
            // closeBTN
            // 
            this.closeBTN.Location = new System.Drawing.Point(346, 390);
            this.closeBTN.Name = "closeBTN";
            this.closeBTN.Size = new System.Drawing.Size(125, 30);
            this.closeBTN.TabIndex = 10;
            this.closeBTN.Text = "CLOSE";
            this.closeBTN.UseVisualStyleBackColor = true;
            this.closeBTN.Click += new System.EventHandler(this.CloseBTN_Click);
            // 
            // usersToBeAddedCLB
            // 
            this.usersToBeAddedCLB.FormattingEnabled = true;
            this.usersToBeAddedCLB.Location = new System.Drawing.Point(72, 69);
            this.usersToBeAddedCLB.Name = "usersToBeAddedCLB";
            this.usersToBeAddedCLB.Size = new System.Drawing.Size(671, 274);
            this.usersToBeAddedCLB.TabIndex = 11;
            // 
            // RowValues
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.usersToBeAddedCLB);
            this.Controls.Add(this.closeBTN);
            this.Controls.Add(this.label1);
            this.Name = "RowValues";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.RowValues_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button closeBTN;
        private System.Windows.Forms.CheckedListBox usersToBeAddedCLB;
    }
}