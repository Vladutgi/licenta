namespace incercarea1
{
    partial class Meniu
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
            this.edit = new System.Windows.Forms.Button();
            this.printPage = new System.Windows.Forms.Button();
            this.ucPrintPage1 = new incercarea1.UCPrintPage();
            this.ucEdit1 = new incercarea1.UCEdit();
            this.project = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // edit
            // 
            this.edit.Location = new System.Drawing.Point(12, 103);
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(106, 36);
            this.edit.TabIndex = 1;
            this.edit.Text = "Edit Raport";
            this.edit.UseVisualStyleBackColor = true;
            this.edit.Click += new System.EventHandler(this.Edit_Click);
            // 
            // printPage
            // 
            this.printPage.Location = new System.Drawing.Point(12, 145);
            this.printPage.Name = "printPage";
            this.printPage.Size = new System.Drawing.Size(106, 36);
            this.printPage.TabIndex = 3;
            this.printPage.Text = "Print Page";
            this.printPage.UseVisualStyleBackColor = true;
            this.printPage.Click += new System.EventHandler(this.PrintPage_Click);
            // 
            // ucPrintPage1
            // 
            this.ucPrintPage1.Location = new System.Drawing.Point(166, 12);
            this.ucPrintPage1.Margin = new System.Windows.Forms.Padding(4);
            this.ucPrintPage1.Name = "ucPrintPage1";
            this.ucPrintPage1.Size = new System.Drawing.Size(760, 848);
            this.ucPrintPage1.TabIndex = 8;
            // 
            // ucEdit1
            // 
            this.ucEdit1.Location = new System.Drawing.Point(166, 12);
            this.ucEdit1.Margin = new System.Windows.Forms.Padding(4);
            this.ucEdit1.Name = "ucEdit1";
            this.ucEdit1.Size = new System.Drawing.Size(760, 848);
            this.ucEdit1.TabIndex = 7;
            // 
            // project
            // 
            this.project.Location = new System.Drawing.Point(12, 187);
            this.project.Name = "project";
            this.project.Size = new System.Drawing.Size(106, 36);
            this.project.TabIndex = 9;
            this.project.Text = "Projects";
            this.project.UseVisualStyleBackColor = true;
            this.project.Click += new System.EventHandler(this.Project_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4});
            this.statusStrip1.Location = new System.Drawing.Point(0, 835);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(987, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(86, 17);
            this.toolStripStatusLabel1.Text = "Esti logat ca ->";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(40, 17);
            this.toolStripStatusLabel3.Text = "Rol ->";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel4.Text = "toolStripStatusLabel4";
            // 
            // Meniu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 857);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.project);
            this.Controls.Add(this.ucPrintPage1);
            this.Controls.Add(this.ucEdit1);
            this.Controls.Add(this.printPage);
            this.Controls.Add(this.edit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Meniu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Meniu";
            this.Load += new System.EventHandler(this.Meniu_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button edit;
        private System.Windows.Forms.Button printPage;
        private UCEdit ucEdit1;
        private UCPrintPage ucPrintPage1;
        private System.Windows.Forms.Button project;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
    }
}