using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace incercarea1.Forms
{
    public partial class ChangePasswordForm : Form
    {
        public string UserEmail;
        ConnectionStringForm connectionStringForm = ConnectionStringForm.Instanta();
        private IMongoCollection<UsersModel> collection;
        private IMongoCollection<Audit> auditCollection;

        public ChangePasswordForm()
        {

            InitializeComponent();
            DB();

        }

        private async void CompleteBTN_Click(object sender, EventArgs e)
        {
            UserEmail = emailTB.Text;

            if (String.IsNullOrEmpty(UserEmail) == false)
            {
                var person = User(UserEmail);
                if (person != null)
                {
                    if (newPasswordTB.Text == repeatPasswordTB.Text && String.IsNullOrEmpty(newPasswordTB.Text) == false && PasswordHash(questionAnswerTB.Text) == person.VerificationAnswer)
                    {
                        //SwitchForm();

                        await ChangePassword();

                    }
                    else
                    {
                        MessageBox.Show("Campurile nu se potrivesc");
                    }
                }
                else
                {
                    MessageBox.Show("Contul nu a fost gasit!");
                }
            }
            else
            {
                MessageBox.Show("Completati campurile");
            }
        }

        private async Task ChangePassword()
        {
            try
            {
                string hashedPassword = PasswordHash(newPasswordTB.Text);
                var lastModified = System.DateTime.UtcNow.ToString();

                var person = Builders<UsersModel>.Filter.Eq("Email", UserEmail);
                var modify = Builders<UsersModel>.Update.Set("HashedPassword", hashedPassword);
                var modifyLastUpdated = Builders<UsersModel>.Update.Set("LastModified", lastModified);
                var updatePassword = await collection.UpdateOneAsync(person, modify);
                var updateLastUpdated = await collection.UpdateOneAsync(person, modifyLastUpdated);
                if (updatePassword.ModifiedCount > 0 || updateLastUpdated.ModifiedCount > 0)
                {
                    MessageBox.Show("Parola a fost schimbata");
                    SwitchForm();
                    AddToAudit($"{System.DateTime.UtcNow}: Userul {emailTB.Text} si-a schimbat parola");

                }
                else
                {
                    MessageBox.Show("Ceva nu a mers!");
                }

            }
            catch (Exception ex)
            {


            }


        }
        public string PasswordHash(string Pasword)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashedPassword = sha256.ComputeHash(Encoding.UTF8.GetBytes(Pasword));
                return Convert.ToBase64String(hashedPassword);
            }

        }
        private void SwitchForm()
        {
            Form parentForm = this.Parent.FindForm();

            Meniu meniu = new Meniu();
            meniu.TopLevel = false;
            meniu.Dock = DockStyle.Fill;
            parentForm.Size = new Size(1003, 896);
            meniu.connectedUser = emailTB.Text;

            parentForm.Controls.Clear();
            parentForm.Controls.Add(meniu);
            meniu.Show();





        }

        private UsersModel User(string email)
        {
            return collection.Find(x => x.Email == email).FirstOrDefault();
        }

        private void CloseBTN_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Parent.Controls)
            {
                if (control is Form == false)
                {
                    control.Visible = true;
                }
            }
            this.Visible = false;
            this.Parent.Size = new Size(662, 305);
        }
        private void DB()
        {
            try
            {

                var client = new MongoClient(connectionStringForm.ConnectionString);
                var db = client.GetDatabase(connectionStringForm.DatabaseName);
                collection = db.GetCollection<UsersModel>(connectionStringForm.UsersCollectionName);
                auditCollection = db.GetCollection<Audit>(connectionStringForm.AuditCollectionName);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
