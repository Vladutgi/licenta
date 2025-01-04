namespace incercarea1
{
    partial class UCProject
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.personalProjectsTab = new System.Windows.Forms.TabPage();
            this.finishedProjectsTab = new System.Windows.Forms.TabPage();
            this.modifyRolesTab = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.personalProjectsTab);
            this.tabControl1.Controls.Add(this.finishedProjectsTab);
            this.tabControl1.Controls.Add(this.modifyRolesTab);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 804);
            this.tabControl1.TabIndex = 0;
            // 
            // personalProjectsTab
            // 
            this.personalProjectsTab.Location = new System.Drawing.Point(4, 22);
            this.personalProjectsTab.Name = "personalProjectsTab";
            this.personalProjectsTab.Padding = new System.Windows.Forms.Padding(3);
            this.personalProjectsTab.Size = new System.Drawing.Size(792, 778);
            this.personalProjectsTab.TabIndex = 1;
            this.personalProjectsTab.Text = "Personal Projects";
            this.personalProjectsTab.UseVisualStyleBackColor = true;
            // 
            // finishedProjectsTab
            // 
            this.finishedProjectsTab.Location = new System.Drawing.Point(4, 22);
            this.finishedProjectsTab.Name = "finishedProjectsTab";
            this.finishedProjectsTab.Padding = new System.Windows.Forms.Padding(3);
            this.finishedProjectsTab.Size = new System.Drawing.Size(792, 778);
            this.finishedProjectsTab.TabIndex = 1;
            this.finishedProjectsTab.Text = "Filter Projects";
            this.finishedProjectsTab.UseVisualStyleBackColor = true;
            // 
            // modifyRolesTab
            // 
            this.modifyRolesTab.Location = new System.Drawing.Point(4, 22);
            this.modifyRolesTab.Name = "modifyRolesTab";
            this.modifyRolesTab.Padding = new System.Windows.Forms.Padding(3);
            this.modifyRolesTab.Size = new System.Drawing.Size(792, 778);
            this.modifyRolesTab.TabIndex = 1;
            this.modifyRolesTab.Text = "Modify Roles";
            this.modifyRolesTab.UseVisualStyleBackColor = true;
            // 
            // UCProject
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UCProject";
            this.Size = new System.Drawing.Size(800, 804);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage personalProjectsTab;
        private System.Windows.Forms.TabPage finishedProjectsTab;
        private System.Windows.Forms.TabPage modifyRolesTab;

    }
}
