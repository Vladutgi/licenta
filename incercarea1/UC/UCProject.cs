using Google.Protobuf.Compiler;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace incercarea1
{
    public partial class UCProject : UserControl
    {
        ConnectionStringForm connectionStringForm = ConnectionStringForm.Instanta();
        private IMongoCollection<MongoProiecte> collection;
        private IMongoCollection<UsersModel> usersCollection;
        private IMongoCollection<Audit> auditCollection;
        private static bool conectat = false;
        private int counter = 0;
        private int btnLocation = 0;
        public string ConnectedUser { get; set; }
        private string filterStatus;

        public UCProject()
        {
            InitializeComponent();
            this.Name = "ucProject1";
            if (conectat == false)
            {
                try
                {
                    var client = new MongoClient(connectionStringForm.ConnectionString);
                    var db = client.GetDatabase(connectionStringForm.DatabaseName);
                    collection = db.GetCollection<MongoProiecte>(connectionStringForm.ProiecteCollectionName);
                    usersCollection = db.GetCollection<UsersModel>(connectionStringForm.UsersCollectionName);
                    auditCollection = db.GetCollection<Audit>(connectionStringForm.AuditCollectionName);
                    conectat = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void SetConnectedUser(string connectedUser)
        {
            this.ConnectedUser = connectedUser;
        }
        private void AddProjectButton_Click(object sender, EventArgs e)
        {
            AddOneInsert();
        }
        private void AddOneInsert()
        {
            UCAddProject ucAddProject = new UCAddProject(connectionStringForm.ConnectionString, connectionStringForm.DatabaseName, connectionStringForm.ProiecteCollectionName, connectionStringForm.UsersCollectionName, connectionStringForm.AuditCollectionName, String.Empty);
            ucAddProject.Size = this.Parent.ClientSize;
            ucAddProject.Location = new Point(200, 0);
            this.Visible = false;
            ucAddProject.Visible = true;

            this.Parent.Controls.Add(ucAddProject);
        }
        public void RefreshPage()
        {
            finishedProjectsTab.Controls.Clear();
            this.Controls.Clear();
            counter = 0;
            btnLocation = 0;
            if (IsAdmin(ConnectedUser) == false)
            {
                ShowPersonalProjects();
                finishedProjectsTab.Visible = false;
                modifyRolesTab.Visible = false;
            }
            else
            {
                personalProjectsTab.Visible = false;
                ModifyUserRoles();
                ShowFinishedProjects();
            }

        }
        public void ShowPersonalProjects()
        {
            //MessageBox.Show(ConnectedUser);

            var person = Builders<MongoProiecte>.Filter.Eq("AssignedTo", ConnectedUser);

            Panel panels = new Panel();
            panels.Dock = DockStyle.Fill;
            panels.AutoScroll = true;

            var inserts1 = collection.Find(person).ToList();

            var counters = 0;
            foreach (var items in inserts1)
            {
                string Ids = items.Id;
                string Titles = items.Title;
                string Descriptions = items.Description;
                string Statuss = items.Status;
                string Createds = items.Created;
                string LastUpdateds = items.LastUpdated;
                string ItemColors = items.Color;

                GroupBox groupBoxs = new GroupBox();
                groupBoxs.Size = new Size(700, 120);
                groupBoxs.AutoSize = false;

                groupBoxs.Location = new Point(10, counters * groupBoxs.Height + 10);



                Label indexLabels = new Label();
                indexLabels.Text = $"{counters + 1}";
                indexLabels.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Bold);
                indexLabels.AutoSize = false;
                indexLabels.Size = new Size(60, groupBoxs.Height - 6);
                indexLabels.Location = new Point(0, 5);
                indexLabels.TextAlign = ContentAlignment.MiddleCenter;
                if (string.IsNullOrEmpty(ItemColors) == false)
                {
                    try
                    {
                        Color translatedColor = ColorTranslator.FromHtml(ItemColors);
                        indexLabels.BackColor = translatedColor;
                    }
                    catch { }

                }


                Label titleLabels = new Label();
                titleLabels.Text = $"{Titles}";
                titleLabels.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
                titleLabels.BackColor = Color.Transparent;
                titleLabels.AutoSize = true;
                titleLabels.Location = new Point(indexLabels.Right + 10, 0 + 10);

                Label datesLabels = new Label();
                datesLabels.Text = $"Created:{Createds}\t\t Updated:{LastUpdateds}";
                datesLabels.Font = new Font("Microsoft Sans Serif", 8f, FontStyle.Regular);
                datesLabels.ForeColor = Color.Gray;
                datesLabels.AutoSize = true;
                datesLabels.Location = new Point(indexLabels.Right + 10, 0 + titleLabels.Bottom + 10);



                Label descriptionLabels = new Label();
                descriptionLabels.Text = $"{Descriptions}";
                descriptionLabels.Font = new Font("Microsoft Sans Serif", 8f, FontStyle.Bold);
                descriptionLabels.Width = 100;
                descriptionLabels.Height = 20;
                descriptionLabels.Location = new Point(indexLabels.Right + 10, 0 + datesLabels.Bottom);

                ComboBox statusComboBoxs = new ComboBox();
                statusComboBoxs.Tag = titleLabels.Text;

                statusComboBoxs.DropDownStyle = ComboBoxStyle.DropDownList;
                statusComboBoxs.Items.Add("In Progress");
                statusComboBoxs.Items.Add("Rejected");
                statusComboBoxs.Items.Add("Approved");
                statusComboBoxs.Items.Add("Finished");

                statusComboBoxs.Text = Statuss;

                statusComboBoxs.Width = 140;
                statusComboBoxs.Height = 20;
                statusComboBoxs.Location = new Point(indexLabels.Right + 10, 0 + descriptionLabels.Bottom);
                statusComboBoxs.SelectedIndexChanged += PersonalProjectStatusComboBox_SelectedIndexChanged;

                groupBoxs.Controls.Add(indexLabels);

                groupBoxs.Controls.Add(titleLabels);
                groupBoxs.Controls.Add(datesLabels);
                groupBoxs.Controls.Add(descriptionLabels);
                groupBoxs.Controls.Add(statusComboBoxs);


                btnLocation = groupBoxs.Bottom + 10;

                counters += 1;
                Label statusLabels = new Label();
                statusLabels.Text = "";
                statusLabels.Size = new Size(20, groupBoxs.Height - 6);
                statusLabels.Location = new Point(groupBoxs.Width - statusLabels.Width + 1, 5);
                statusLabels.TextAlign = ContentAlignment.MiddleCenter;
                //statusComboBoxs.Tag = statusLabels;

                if (statusComboBoxs.Text == "Finished")
                {
                    statusLabels.BackColor = Color.DarkGreen;
                }
                else if (statusComboBoxs.Text == "Rejected")
                {
                    statusLabels.BackColor = Color.IndianRed;
                }
                else if (statusComboBoxs.Text == "In Progress")
                {
                    statusLabels.BackColor = Color.Gold;
                }
                else if (statusComboBoxs.Text == "Approved")
                {
                    statusLabels.BackColor = Color.LightGreen;
                }
                else if (statusComboBoxs.Text == "Select Status")
                {
                    statusLabels.BackColor = Color.GhostWhite;
                }
                groupBoxs.Controls.Add(statusLabels);

                panels.Controls.Add(groupBoxs);

            }


            personalProjectsTab.Controls.Add(panels);
            this.Controls.Add(tabControl1);
        }
        private void PersonalProjectStatusComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            string status = comboBox.SelectedItem.ToString();
            string project = comboBox.Tag as string;
            UpdateFinishedInTheDB(status, project);
            personalProjectsTab.Controls.Clear();
            AddToAudit($"{System.DateTime.UtcNow}: Userul {Settings1.Default.connectedUser1} a modificat statusul unui proiect");


            ShowPersonalProjects();


        }
        public void ShowFinishedProjects()
        {



            Panel panelFinished = new Panel();
            panelFinished.Dock = DockStyle.Fill;
            panelFinished.AutoScroll = true;

            ComboBox pickStatusComboBoxFinished = new ComboBox();
            //pickStatusComboBoxFinished.SelectedItem = filterStatus;

            pickStatusComboBoxFinished.DropDownStyle = ComboBoxStyle.DropDownList;
            pickStatusComboBoxFinished.SelectedIndexChanged += FillterStatusComboBox_SelectedIndexChanged;
            pickStatusComboBoxFinished.Items.Add("In Progress");
            pickStatusComboBoxFinished.Items.Add("Rejected");
            pickStatusComboBoxFinished.Items.Add("Approved");
            pickStatusComboBoxFinished.Items.Add("Finished");
            pickStatusComboBoxFinished.Items.Add("All");
            panelFinished.Controls.Add(pickStatusComboBoxFinished);



            FilterDefinition<MongoProiecte> finishedProjects = Builders<MongoProiecte>.Filter.Empty;
            if (filterStatus == "Finished")
            {
                finishedProjects = Builders<MongoProiecte>.Filter.Eq("Status", "Finished");
            }
            else if (filterStatus == "Rejected")
            {
                finishedProjects = Builders<MongoProiecte>.Filter.Eq("Status", "Rejected");
            }
            else if (filterStatus == "In Progress")
            {
                finishedProjects = Builders<MongoProiecte>.Filter.Eq("Status", "In Progress");
            }
            else if (filterStatus == "Approved")
            {
                finishedProjects = Builders<MongoProiecte>.Filter.Eq("Status", "Approved");
            }
            var insertsFinished = collection.Find(finishedProjects).ToList();

            var counterFinished = 0;
            foreach (var items in insertsFinished)
            {
                string IdFinished = items.Id;
                string TitleFinished = items.Title;
                string DescriptionFinished = items.Description;
                string StatusFinished = items.Status;
                string CreatedFinished = items.Created;
                string LastUpdatedFinished = items.LastUpdated;
                string ItemColorFinished = items.Color;
                List<string> AssignedTo = new List<string>();
                if (items.AssignedTo.Count > 0)
                {
                    AssignedTo = items.AssignedTo;

                }

                GroupBox groupBoxFinished = new GroupBox();
                groupBoxFinished.Size = new Size(700, 120);
                groupBoxFinished.AutoSize = false;

                groupBoxFinished.Location = new Point(10, counterFinished * (groupBoxFinished.Height+5) + 25);



                Label indexLabelFinished = new Label();
                indexLabelFinished.Text = $"{counterFinished + 1}";
                indexLabelFinished.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Bold);
                indexLabelFinished.AutoSize = false;
                indexLabelFinished.Size = new Size(56, groupBoxFinished.Height - 8);
                indexLabelFinished.Location = new Point(4, 4);
                indexLabelFinished.TextAlign = ContentAlignment.MiddleCenter;
                if (string.IsNullOrEmpty(ItemColorFinished) == false)
                {
                    try
                    {
                        Color translatedColor = ColorTranslator.FromHtml(ItemColorFinished);
                        indexLabelFinished.BackColor = translatedColor;
                    }
                    catch { }

                }


                Label titleLabelFinished = new Label();
                titleLabelFinished.Text = $"{TitleFinished}";
                titleLabelFinished.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
                titleLabelFinished.BackColor = Color.Transparent;
                titleLabelFinished.AutoSize = true;
                titleLabelFinished.Location = new Point(indexLabelFinished.Right + 10, 0 + 10);

                Label datesLabelFinished = new Label();
                datesLabelFinished.Text = $"Created:{CreatedFinished}\t\t Updated:{LastUpdatedFinished}";
                datesLabelFinished.Font = new Font("Microsoft Sans Serif", 8f, FontStyle.Regular);
                datesLabelFinished.ForeColor = Color.Gray;
                datesLabelFinished.AutoSize = true;
                datesLabelFinished.Location = new Point(indexLabelFinished.Right + 10, 0 + titleLabelFinished.Bottom + 10);



                Label descriptionLabelFinished = new Label();
                descriptionLabelFinished.Text = $"{DescriptionFinished}";
                descriptionLabelFinished.Font = new Font("Microsoft Sans Serif", 8f, FontStyle.Bold);
                descriptionLabelFinished.Width = 100;
                descriptionLabelFinished.Height = 20;
                descriptionLabelFinished.Location = new Point(indexLabelFinished.Right + 10, 0 + datesLabelFinished.Bottom);

                ComboBox statusComboBoxFinished = new ComboBox();
                statusComboBoxFinished.Tag = titleLabelFinished.Text;
                statusComboBoxFinished.DropDownStyle = ComboBoxStyle.DropDownList;
                statusComboBoxFinished.Items.Add("In Progress");
                statusComboBoxFinished.Items.Add("Rejected");
                statusComboBoxFinished.Items.Add("Approved");
                statusComboBoxFinished.Items.Add("Finished");

                statusComboBoxFinished.Text = StatusFinished;

                //statusComboBox.Font = new Font("Microsoft Sans Serif", 8f, FontStyle.Bold);
                statusComboBoxFinished.Width = 140;
                statusComboBoxFinished.Height = 20;
                statusComboBoxFinished.Location = new Point(indexLabelFinished.Right + 10, 0 + descriptionLabelFinished.Bottom);
                statusComboBoxFinished.SelectedIndexChanged += FinishedProjectStatusComboBox_SelectedIndexChanged;

                groupBoxFinished.Controls.Add(indexLabelFinished);

                groupBoxFinished.Controls.Add(titleLabelFinished);
                groupBoxFinished.Controls.Add(datesLabelFinished);
                groupBoxFinished.Controls.Add(descriptionLabelFinished);
                groupBoxFinished.Controls.Add(statusComboBoxFinished);


                btnLocation = groupBoxFinished.Bottom + 10;

                counterFinished += 1;
                Label statusLabelFinished = new Label();
                statusLabelFinished.Text = "";
                statusLabelFinished.Size = new Size(20, groupBoxFinished.Height - 8);
                statusLabelFinished.Location = new Point(groupBoxFinished.Width - statusLabelFinished.Width -3, 4);
                statusLabelFinished.TextAlign = ContentAlignment.MiddleCenter;


                if (statusComboBoxFinished.Text == "Finished")
                {
                    statusLabelFinished.BackColor = Color.DarkGreen;
                }
                else if (statusComboBoxFinished.Text == "Rejected")
                {
                    statusLabelFinished.BackColor = Color.IndianRed;
                }
                else if (statusComboBoxFinished.Text == "In Progress")
                {
                    statusLabelFinished.BackColor = Color.Gold;
                }
                else if (statusComboBoxFinished.Text == "Approved")
                {
                    statusLabelFinished.BackColor = Color.LightGreen;
                }
                else if (statusComboBoxFinished.Text == "Select Status")
                {
                    statusLabelFinished.BackColor = Color.GhostWhite;
                }
                groupBoxFinished.Controls.Add(statusLabelFinished);




                ComboBox assignedToComboBox = new ComboBox();


                assignedToComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                if (AssignedTo.Any())
                {
                    assignedToComboBox.Items.Add("Click here to view the list");
                    assignedToComboBox.SelectedItem = "Click here to view the list";
                    foreach (string assigned in AssignedTo)
                    {
                        assignedToComboBox.Items.Add(assigned);
                    }
                }
                else
                {
                    assignedToComboBox.Items.Add("Assign a person");
                    assignedToComboBox.SelectedItem = "Assign a person";
                }


                assignedToComboBox.Width = 140;
                assignedToComboBox.Height = datesLabelFinished.Height;
                assignedToComboBox.Location = new Point(groupBoxFinished.Width - assignedToComboBox.Width - statusLabelFinished.Width - 10, datesLabelFinished.Location.Y - 5);
                groupBoxFinished.Controls.Add(assignedToComboBox);

                Label assignedToLabel = new Label();
                assignedToLabel.Text = "Assigned to:";
                assignedToLabel.Size = new Size(70, 20);
                assignedToLabel.Location = new Point(assignedToComboBox.Location.X - assignedToLabel.Width, assignedToComboBox.Location.Y);
                assignedToLabel.TextAlign = ContentAlignment.MiddleRight;

                groupBoxFinished.Controls.Add(assignedToLabel);

                LinkLabel assignedToLinkLabel = new LinkLabel();
                assignedToLinkLabel.Text = "Edit Project";
                assignedToLinkLabel.AutoSize = true;
                assignedToLinkLabel.Location = new Point(assignedToComboBox.Location.X, assignedToComboBox.Location.Y + assignedToLinkLabel.Height);
                assignedToLinkLabel.Tag = TitleFinished;
                assignedToLinkLabel.Click += new EventHandler(AssignedToLinkLabel_Clicked);

                groupBoxFinished.Controls.Add(assignedToLinkLabel);

                groupBoxFinished.Paint += new PaintEventHandler(GroupBox_Paint);

                panelFinished.Controls.Add(groupBoxFinished);

            }
            Button addProjectButton = new Button();
            addProjectButton.Click += new EventHandler(AddProjectButton_Click);
            addProjectButton.Height = 30;
            addProjectButton.Width = 60;
            addProjectButton.Location = new Point(10, btnLocation);
            addProjectButton.Text = "Add";
            panelFinished.Controls.Add(addProjectButton);

            finishedProjectsTab.Controls.Add(panelFinished);
            this.Controls.Add(tabControl1);
        }
        private void SetFilterStatus(string oldStatusFilter)
        {
            filterStatus = oldStatusFilter;
        }
        private void FillterStatusComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            {

                string newStatus = comboBox.SelectedItem.ToString();
                finishedProjectsTab.Controls.Clear();

                SetFilterStatus(newStatus);

                RefreshPage();


            }
        }

        private void FinishedProjectStatusComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            string status = comboBox.SelectedItem.ToString();
            string project = comboBox.Tag as string;
            UpdateFinishedInTheDB(status, project);
            finishedProjectsTab.Controls.Clear();
            AddToAudit($"{System.DateTime.UtcNow}: Userul {Settings1.Default.connectedUser1} a modificat statusul unui proiect");
            ShowFinishedProjects();
        }

        public void ModifyUserRoles()
        {
            Panel usersPanel = new Panel();
            usersPanel.Dock = DockStyle.Fill;
            usersPanel.AutoScroll = true;

            FilterDefinition<UsersModel> users = Builders<UsersModel>.Filter.Empty;

            var usersInserts = usersCollection.Find(users).ToList();

            var userCounter = 0;
            foreach (var items in usersInserts)
            {
                string IdUser = items.Id;
                string EmailUser = items.Email;
                string RoleUser = items.Role;


                GroupBox groupBoxUser = new GroupBox();
                groupBoxUser.Size = new Size(700, 120);
                groupBoxUser.AutoSize = false;

                groupBoxUser.Location = new Point(10, userCounter * (groupBoxUser.Height+5) + 20);
                groupBoxUser.Paint += new PaintEventHandler(GroupBox_Paint);

                Label emailLabel = new Label();
                emailLabel.Text = $"{EmailUser}";
                emailLabel.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
                emailLabel.Width = groupBoxUser.Width - 8;
                emailLabel.Height = groupBoxUser.Height / 3;
                emailLabel.Location = new Point(4, 4);
                emailLabel.Paint += new PaintEventHandler(Label_Paint);
                emailLabel.Padding = new Padding(5);


                groupBoxUser.Controls.Add(emailLabel);

                Label blackLine = new Label();
                blackLine.BackColor = Color.Black;
                blackLine.Width = groupBoxUser.Width;
                blackLine.Height = 4;
                blackLine.Location =new Point(0,emailLabel.Bottom);
                groupBoxUser.Controls.Add(blackLine);

                Label projectsCount = new Label();
                projectsCount.Text = $"Numar de Proiecte: {UserProjectsNumber(EmailUser)}";
                projectsCount.Width = 200;
                projectsCount.Height = 20;
                projectsCount.Location = new Point(10, (groupBoxUser.Height - blackLine.Bottom)/2+blackLine.Bottom -projectsCount.Height/2+3/2);

                groupBoxUser.Controls.Add(projectsCount);

                if (IsAdmin(emailLabel.Text) == false)
                {
                    Button adminButton = new Button();
                    adminButton.Click += new EventHandler(MakeAdminButton_Click);
                    adminButton.Height = 30;
                    adminButton.Width = 60;
                    adminButton.Location = new Point(groupBoxUser.Width - adminButton.Width * 2, (groupBoxUser.Height - blackLine.Bottom) / 2  + adminButton.Height +1);
                    adminButton.Text = "Make Admin";
                    adminButton.Tag = EmailUser;

                    groupBoxUser.Controls.Add(adminButton);
                }

                btnLocation = groupBoxUser.Bottom + 10;
                userCounter += 1;
                usersPanel.Controls.Add(groupBoxUser);
            }


            modifyRolesTab.Controls.Add(usersPanel);
            this.Controls.Add(tabControl1);
        }

        void Label_Paint(object sender, PaintEventArgs e)
        {
            Label label = sender as Label;
            if (label != null)
            {
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(0xED, 0x1C, 0x24), 6), 0, 0, label.Width-1 , label.Height - 1);
            }
        }

        void GroupBox_Paint(object sender, PaintEventArgs e)
        {
            GroupBox groupBox = sender as GroupBox;
            if (groupBox != null)
            {
                e.Graphics.DrawRectangle(new Pen(Color.Black, 7), 0, 0, groupBox.Width - 1, groupBox.Height - 1);
            }
        }

        private int UserProjectsNumber(string email)
        {
            long count = 0;
            var filter = Builders<MongoProiecte>.Filter.AnyEq(x => x.AssignedTo, email);
            count = collection.CountDocuments(filter);
            return (int)count;
        }

        private bool IsAdmin(string user)
        {
            var filter = Builders<UsersModel>.Filter.And
                (
                Builders<UsersModel>.Filter.Eq("Role", "Admin"),
                Builders<UsersModel>.Filter.Eq("Email", user)
                );
            bool amI = usersCollection.Find(filter).Any();
            return amI;
        }
        public void HideAdminTabs()
        {
            finishedProjectsTab.Visible = false;
            tabControl1.Controls.Remove(finishedProjectsTab);
            modifyRolesTab.Visible = false;
            tabControl1.Controls.Remove(modifyRolesTab);
            

        }
        public void HideUserTabs()
        {
            personalProjectsTab.Visible = false;
            tabControl1.Controls.Remove(personalProjectsTab);

        }
        private void MakeAdminInTheDB(string person) 
        {



            try
            {
                var lastModified = System.DateTime.UtcNow.ToString();


                var filter = Builders<UsersModel>.Filter.Eq("Email", person);

                var update = Builders<UsersModel>.Update.Set("Role", "Admin").Set("LastModified", lastModified);

                usersCollection.UpdateOne(filter, update);
                AddToAudit($"{System.DateTime.UtcNow}: Userul {person} a devenit admin datorita adminului '{Settings1.Default.connectedUser1}'");

                modifyRolesTab.Controls.Clear();
                ModifyUserRoles();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Modificarea nu a functionat.");
            }


        }
        private void MakeAdminButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            string mail = button.Tag as String;
            if (string.IsNullOrEmpty(mail) == false)
            {
                MakeAdminInTheDB(mail);
            }
            else
            {
                MessageBox.Show("Ceva nu a mers!");
            }

        }
        private void UpdateFinishedInTheDB(string status, string title)
        {
            var lastModified = System.DateTime.UtcNow.ToString();

            var filter = Builders<MongoProiecte>.Filter.Eq("Title", title);

            var update = Builders<MongoProiecte>.Update.Set("Status", status).Set("LastUpdated", lastModified);

            collection.UpdateOne(filter, update);


        }
        private void AssignedToLinkLabel_Clicked(object sender, EventArgs e)
        {
            if (sender is LinkLabel linkLabel && linkLabel.Tag != null)
            {
                UCAddProject ucAddProject = new UCAddProject(connectionStringForm.ConnectionString, connectionStringForm.DatabaseName, connectionStringForm.ProiecteCollectionName, connectionStringForm.UsersCollectionName,connectionStringForm.AuditCollectionName, linkLabel.Tag.ToString());
                ucAddProject.Size = this.Parent.ClientSize;
                ucAddProject.Location = new Point(200, 0);
                this.Visible = false;
                ucAddProject.Visible = true;

                this.Parent.Controls.Add(ucAddProject);
            }
        }
        private async void AddToAudit(string descriere)
        {

            var audit = new Audit
            {
                Id = ObjectId.GenerateNewId().ToString(),

                Descriere = descriere
            };
            await auditCollection.InsertOneAsync(audit);


        }
    }

}
