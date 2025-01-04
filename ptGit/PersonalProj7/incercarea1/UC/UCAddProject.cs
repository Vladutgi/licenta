using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace incercarea1
{
    public partial class UCAddProject : UserControl
    {
        private IMongoCollection<MongoProiecte> collection;
        private IMongoCollection<UsersModel> usersCollection;
        private IMongoCollection<Audit> auditCollection;

        private static bool conectat = false;


        public Color Color { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Created { get; set; }
        public string LastUpdated { get; set; }

        private Color colorPicked;

        private bool listaGoala = true;

        private string oldTitle = String.Empty;
        private string oldDescription = String.Empty;
        private List<string> oldAssignees = new List<string>();
        private string oldColor;

        public UCAddProject(string ConnectionString, string DatabaseName, string ProiecteCollectionName, string UsersCollectionName, string AuditCollectionName, string title)
        {
            InitializeComponent();



            try
            {

                var client = new MongoClient(ConnectionString);
                var db = client.GetDatabase(DatabaseName);
                collection = db.GetCollection<MongoProiecte>(ProiecteCollectionName);
                usersCollection = db.GetCollection<UsersModel>(UsersCollectionName);
                auditCollection = db.GetCollection<Audit>(AuditCollectionName);

                conectat = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            SetCLB();
            if (title != String.Empty)
            {
                SetFields(title);

            }

        }








        private void PickColor()
        {

            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                colorPicked = colorDialog.Color;
            }


        }

        private void CloseBTN_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            UCProject ucProject = this.FindForm().Controls.Find("ucProject1", true).FirstOrDefault() as UCProject;
            ucProject.Visible = true;

        }

        private void SaveBTN_Click(object sender, EventArgs e)
        {
            listaGoala = true;
            if (titleTB.Text.Length > 0 && descriptionTB.Text.Length > 0)
            {
                if (oldTitle == String.Empty)
                {
                    if (AlreadyExists(titleTB.Text) == false)
                    {
                        AddOneInsert();
                        if (listaGoala == false)
                        {
                            this.Visible = false;
                            AddToAudit($"{System.DateTime.UtcNow}: Userul {Settings1.Default.connectedUser1} a adaugat un proiect");

                            Meniu parentForm = this.FindForm() as Meniu;
                            if (parentForm != null)
                            {
                                UCProject ucProject = parentForm.Controls.Find("ucProject1", true).FirstOrDefault() as UCProject;
                                //if (ucProject != null) { }
                                ucProject.RefreshPage();


                                ucProject.ShowFinishedProjects();

                                ucProject.Visible = true;
                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("Exista deja un proiect cu acest titlu!");
                    }
                }
                else
                {
                    ForUpdate();
                    this.Visible = false;
                    AddToAudit($"{System.DateTime.UtcNow}: Userul {Settings1.Default.connectedUser1} a modificat un proiect");

                    Meniu parentForm = this.FindForm() as Meniu;
                    if (parentForm != null)
                    {
                        UCProject ucProject = parentForm.Controls.Find("ucProject1", true).FirstOrDefault() as UCProject;
                        //if (ucProject != null) { }
                        ucProject.RefreshPage();


                        ucProject.ShowFinishedProjects();

                        ucProject.Visible = true;
                    }
                }



            }
            else
            {
                MessageBox.Show("Completati campurile..");
            }
        }





        private async void AddOneInsert()
        {
            List<string> list = new List<string>();
            foreach (var item in assignToUserCLB.CheckedItems)
            {
                list.Add(item.ToString());
            }
            listaGoala = list.Count > 0 ? false : true;
            if (list.Count > 0)
            {
                var raport = new MongoProiecte
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Title = titleTB.Text,
                    Description = descriptionTB.Text,
                    Status = "Select Status",
                    Created = System.DateTime.UtcNow.ToString(),
                    LastUpdated = System.DateTime.UtcNow.ToString(),
                    Color = ColorTranslator.ToHtml(colorPicked),
                    AssignedTo = list,
                };
                await collection.InsertOneAsync(raport);
            }
            else { MessageBox.Show("Un ultilizator trebuie selectat!"); }

        }


        private void ColorBTN_Click(object sender, EventArgs e)
        {
            PickColor();
        }
        private bool AlreadyExists(string title)
        {
            return collection.Find(x => x.Title == title).Any();
        }
        private void SetCLB()
        {
            FilterDefinition<UsersModel> users = Builders<UsersModel>.Filter.Ne("Role", "Admin");

            var usersInserts = usersCollection.Find(users).ToList();

            foreach (var items in usersInserts)
            {
                string EmailUser = items.Email;
                assignToUserCLB.Items.Add(EmailUser);
            }
        }

        private void SetFields(String title)
        {
            FilterDefinition<MongoProiecte> filtruProiect = Builders<MongoProiecte>.Filter.Eq("Title", title);

            var usersInserts = collection.Find(filtruProiect).FirstOrDefault();


            oldTitle = usersInserts.Title;
            titleTB.Text = usersInserts.Title;

            oldDescription = usersInserts.Description;
            descriptionTB.Text = usersInserts.Description;

            oldColor = usersInserts.Color;

            oldAssignees = usersInserts.AssignedTo;
            SetCLB();
            foreach (var users in usersInserts.AssignedTo)
            {
                int index = assignToUserCLB.Items.IndexOf(users);
                if (index != -1)
                {
                    assignToUserCLB.SetItemChecked(index, true);
                }
            }

        }

        private void ForUpdate()
        {
            if ((String.IsNullOrEmpty(titleTB.Text) == false && AlreadyExists(titleTB.Text) == false) || titleTB.Text == oldTitle)
            {
                string updatedColor;
                if (colorPicked != Color.Empty)
                {
                    updatedColor = ColorTranslator.ToHtml(colorPicked);
                }
                else
                {
                    updatedColor = oldColor;
                }
                var lastModified = System.DateTime.UtcNow.ToString();
                List<string> list = new List<string>();
                foreach (var item in assignToUserCLB.CheckedItems)
                {
                    list.Add(item.ToString());
                }
                FilterDefinition<MongoProiecte> filtruProiect = Builders<MongoProiecte>.Filter.Eq("Title", oldTitle);

                var update = Builders<MongoProiecte>.Update.Set("Title", titleTB.Text).Set("Description", descriptionTB.Text).Set("LastUpdated", lastModified).Set("Color", updatedColor).Set("AssignedTo", list);

                collection.UpdateOne(filtruProiect, update);
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
