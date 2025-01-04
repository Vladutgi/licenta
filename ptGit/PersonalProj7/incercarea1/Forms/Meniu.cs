using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using MongoDB.Driver.Core.Configuration;
using MongoDB.Bson;

namespace incercarea1
{
    public partial class Meniu : Form
    {
        private static bool conectat = false;
        private IMongoCollection<Audit> auditCollection;
        private IMongoCollection<UsersModel> usersCollection;

        ConnectionStringForm connectionStringForm = ConnectionStringForm.Instanta();

        public string connectedUser;
        private UCProject ucProject1;
        private Settings1 set;
        public Meniu()
        {
            this.CenterToScreen();


            //connectionStringForm.ShowDialog();

            InitializeComponent();
            ucEdit1.Visible = false;
            ucPrintPage1.Visible = false;
            ucProject1 = null;
            Console.WriteLine("s-a incarcat");
            set = new Settings1();
            
        }



        private void Edit_Click(object sender, EventArgs e)
        {


            ucEdit1.Visible = true;
            ucPrintPage1.Visible = false;
            if (ucProject1 != null)
            {
                ucProject1.Visible = false;
            }

        }

        private void PrintPage_Click(object sender, EventArgs e)
        {

            ucEdit1.Visible = true;
            ucEdit1.Visible = false;
            ucPrintPage1.Visible = true;
            if (ucProject1 != null)
            {
                ucProject1.Visible = false;
            }
            ucPrintPage1.UpdateCells(ucEdit1.dataGridView1,ucEdit1.dataGridView6);
            ucPrintPage1.UpdateValues(ucEdit1.Unitatea, ucEdit1.NrRaport, ucEdit1.Zile, ucEdit1.DataRaport);
            ucPrintPage1.Refresh();
            ucPrintPage1.Show();
        }



        private void Project_Click(object sender, EventArgs e)
        {
            ucPrintPage1.Visible = false;
            ucEdit1.Visible = false;
            if (ucProject1 == null)
            {
                ucProject1 = new UCProject();
                ucProject1.SetConnectedUser(this.connectedUser);
                if (IsAdmin() == false)
                {                    
                    ucProject1.HideAdminTabs();

                    ucProject1.ShowPersonalProjects();
                }
                else
                {
                    ucProject1.HideUserTabs();
                    ucProject1.ShowFinishedProjects();
                    ucProject1.ModifyUserRoles();
                }


                ucProject1.Location = new Point(166, 12);
                ucProject1.Visible = true;
                this.Controls.Add(ucProject1);
            }
            else
            {
                ucProject1.SetConnectedUser(this.connectedUser);
                ucProject1.Location = new Point(166, 12);

                ucProject1.Visible = true;
            }

            

        }

        private bool IsAdmin()
        {
            var client = new MongoClient(connectionStringForm.ConnectionString);
            var db = client.GetDatabase(connectionStringForm.DatabaseName);
            usersCollection = db.GetCollection<UsersModel>(connectionStringForm.UsersCollectionName);

            var filter = Builders<UsersModel>.Filter.And
                (
                Builders<UsersModel>.Filter.Eq("Role", "Admin"),
                Builders<UsersModel>.Filter.Eq("Email", connectedUser)
                );
            bool amI = usersCollection.Find(filter).Any();
            return amI;
        }

        private void Meniu_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = connectedUser.ToString();
            toolStripStatusLabel4.Text = IsAdmin() ? "Admin" : "";
            set.connectedUser1 = connectedUser;
            set.Save();
        }

        
    }
}
