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
    public partial class LoginForm : Form
    {
        private IMongoCollection<Audit> auditCollection;
        private IMongoCollection<UsersModel> collection;
        ConnectionStringForm connectionStringForm ;

        public LoginForm()
        {
            this.CenterToScreen();
            if (connectionStringForm == null)
            {
                connectionStringForm = ConnectionStringForm.Instanta();
                connectionStringForm.ShowDialog();

            }
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

        

        private void ConnectBTN_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(emailTB.Text) == false && string.IsNullOrEmpty(passwordTB.Text) == false)
            {
                var person = User(emailTB.Text);
                if (person != null)
                {
                    if (PasswordHash(passwordTB.Text) == person.HashedPassword)
                    {

                        AddToAudit($"{System.DateTime.UtcNow}: Userul {emailTB.Text} s-a conectat");
                        SwitchForm();
                    }
                    else
                    {
                        MessageBox.Show("Parola incorecta!");
                    }
                }
                else
                {
                    MessageBox.Show("Contul nu a fost gasit!");
                }
            }
            else
            {
                MessageBox.Show("Completati campurile!");
            }
        }
        private UsersModel User(string email)
        {
            return collection.Find(x => x.Email == email).FirstOrDefault();
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
            Form parentForm = this.FindForm();
            Meniu meniu = new Meniu();
            meniu.TopLevel = false;
            meniu.Dock = DockStyle.Fill;
            parentForm.Size = new Size(1003, 896);
            meniu.connectedUser = emailTB.Text;
            parentForm.Controls.Clear();
            parentForm.Controls.Add(meniu);
            meniu.Show();
        }

        private void SwitchToForgotPasswordForm()
        {
            Form parentForm = this.FindForm();
            ChangePasswordForm passwordForm = new ChangePasswordForm();
            passwordForm.TopLevel = false;
            passwordForm.Dock = DockStyle.Fill;
            parentForm.Size = new Size(646, 286);
            foreach (Control control in this.Controls)
            {
                control.Visible = false;
            }
            //parentForm.Controls.Clear();
            ChangeFormVisibility(passwordForm);
            parentForm.Controls.Add(passwordForm);
            passwordForm.Visible = true;
            passwordForm.Show();
        }

        private void ForgotPasswordLbl_Click(object sender, EventArgs e)
        {

            SwitchToForgotPasswordForm();

        }
        private void ChangeFormVisibility(Form form)
        {
            if (form != this.FindForm() && form != this.ParentForm)
            {
                form.Visible = false;
            }
        }

        private void CreateAccountLbl_Click(object sender, EventArgs e)
        {
            SwitchToCreateAccountForm();

        }
        private void SwitchToCreateAccountForm()
        {
            Form parentForm = this.FindForm();
            CreateAccount createAccount = new CreateAccount();
            createAccount.TopLevel = false;
            createAccount.Dock = DockStyle.Fill;
            parentForm.Size = new Size(646, 394);
            foreach (Control control in this.Controls)
            {
                control.Visible = false;
            }
            //parentForm.Controls.Clear();
            ChangeFormVisibility(createAccount);
            parentForm.Controls.Add(createAccount);
            createAccount.Visible = true;
            createAccount.Show();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

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
