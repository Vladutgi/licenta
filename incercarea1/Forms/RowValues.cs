using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace incercarea1
{

    public partial class RowValues : Form
    {
        private IMongoCollection<UsersModel> usersCollection;
        ConnectionStringForm connectionStringForm = ConnectionStringForm.Instanta();

        public List<string> UsersList { get { return selectedUsers; } set { selectedUsers = value; } }
        private List<string> selectedUsers;
        public RowValues()
        {
            InitializeComponent();

        }

        private void CloseBTN_Click(object sender, EventArgs e)
        {
            UsersList=SelectedUsers();
            Close();

        }

        private void RowValues_Load(object sender, EventArgs e)
        {
            try
            {

                var client = new MongoClient(connectionStringForm.ConnectionString);
                var db = client.GetDatabase(connectionStringForm.DatabaseName);
                usersCollection = db.GetCollection<UsersModel>(connectionStringForm.UsersCollectionName);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            SetCLB();
        }
        private void SetCLB()
        {
            FilterDefinition<UsersModel> users = Builders<UsersModel>.Filter.Ne("Role", "Admin");

            var usersInserts = usersCollection.Find(users).ToList();

            foreach (var items in usersInserts)
            {
                string EmailUser = items.Email;
                usersToBeAddedCLB.Items.Add(EmailUser);
            }
            selectedUsers = new List<String>();
        }
        private List<String> SelectedUsers()
        {
            selectedUsers.Clear();
            foreach(var item in usersToBeAddedCLB.CheckedItems)
            {
                selectedUsers.Add(item.ToString());
            }
            return selectedUsers;
        }
    }

}
