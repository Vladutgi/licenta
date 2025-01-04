using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using MongoDB.Driver;
using MongoDB.Bson;

namespace incercarea1
{
    public partial class CreateAccount : Form
    {
        ConnectionStringForm connectionStringForm = ConnectionStringForm.Instanta();
        private IMongoCollection<Audit> auditCollection;
        private IMongoCollection<UsersModel> collection;
        private string EncryptedAnswer = String.Empty;

        public CreateAccount()
        {
            InitializeComponent();


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

        public string PasswordHash(string Pasword)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashedPassword = sha256.ComputeHash(Encoding.UTF8.GetBytes(Pasword));
                return Convert.ToBase64String(hashedPassword);
            }

        }

        private void CreateBTN_Click(object sender, EventArgs e)
        {
            if (createPasswordTB.Text.ToString() == repeatPasswordTB.Text.ToString() && string.IsNullOrEmpty(createPasswordTB.Text) == false && string.IsNullOrEmpty(usernameTB.Text) == false && string.IsNullOrEmpty(emailTB.Text) == false && string.IsNullOrEmpty(secretQuestionTB.Text) == false && string.IsNullOrEmpty(questionAnswerTB.Text) == false)
            {
                if (!AlreadyExists(emailTB.Text))
                {
                    if (questionAnswerTB.Text == repeatAnswerTB.Text)
                    {
                        try
                        {

                            EncryptedAnswer = PasswordHash(questionAnswerTB.Text);
                            AddOneInsert();
                            MessageBox.Show("Contul a fost adaugat!");
                            SwitchForm();


                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Raspunsurile nu se potrivesc!");

                    }
                }
                else
                {
                    MessageBox.Show("Acest cont exista deja!");
                }
            }
            else if (string.IsNullOrEmpty(createPasswordTB.Text) == true || string.IsNullOrEmpty(questionAnswerTB.Text) || string.IsNullOrEmpty(secretQuestionTB.Text) || string.IsNullOrEmpty(usernameTB.Text) || string.IsNullOrEmpty(emailTB.Text))
            {
                MessageBox.Show("Completati campurile!");
            }
            else if (createPasswordTB.Text.ToString() != repeatPasswordTB.Text.ToString())
            {
                MessageBox.Show("Parolele nu se potrivesc!");
            }
            else
            {
                MessageBox.Show("Parola este prea scurta!");
            }
        }

        private bool AlreadyExists(string email)
        {
            return collection.Find(x => x.Email == email).Any();
        }

        private async void AddOneInsert()
        {
            if (await AnyAdmins())
            {
                var raport = new UsersModel
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Username = usernameTB.Text,
                    Email = emailTB.Text,
                    HashedPassword = PasswordHash(createPasswordTB.Text),
                    LastModified = System.DateTime.UtcNow.ToString(),
                    Created = System.DateTime.UtcNow.ToString(),
                    Role = String.Empty,
                    VerificationQuestion = secretQuestionTB.Text,
                    VerificationAnswer = EncryptedAnswer
                };
                await collection.InsertOneAsync(raport);
            }
            else if (await AnyAdmins() == false)
            {
                var raport = new UsersModel
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Username = usernameTB.Text,
                    Email = emailTB.Text,
                    HashedPassword = PasswordHash(createPasswordTB.Text),
                    LastModified = System.DateTime.UtcNow.ToString(),
                    Created = System.DateTime.UtcNow.ToString(),
                    Role = "Admin",
                    VerificationQuestion = secretQuestionTB.Text,
                    VerificationAnswer = EncryptedAnswer
                };
                await collection.InsertOneAsync(raport);
            }
            AddToAudit($"{System.DateTime.UtcNow}: Userul {emailTB.Text} s-a alaturat!");
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
        private async Task<bool> AnyAdmins()
        {
            var countAdmins = await collection.CountDocumentsAsync(Builders<UsersModel>.Filter.Eq("Role", "Admin"));
            return countAdmins > 0;

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
