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

namespace incercarea1
{
    public partial class ConnectionStringForm : Form
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string AuditCollectionName { get; set; }
        public string ProiecteCollectionName { get; set; }
        public string UsersCollectionName { get; set; }



        bool conectat = false;
        private static ConnectionStringForm instantaUniversala;


        public ConnectionStringForm()
        {
            InitializeComponent();
        }

        public static ConnectionStringForm Instanta()
        {
            if(instantaUniversala == null)
            {
                instantaUniversala = new ConnectionStringForm();
            }
            return instantaUniversala;
        }

        private void SaveBTN_Click(object sender, EventArgs e)
        {
            ConnectionString = connectionStringTB.Text;
            DatabaseName = "licenta";
            AuditCollectionName = "audit";
            ProiecteCollectionName = "proiecte";
            UsersCollectionName = "users";
            try
            {

                var client = new MongoClient(ConnectionString);
                var db = client.GetDatabase(DatabaseName);
                var collection = db.GetCollection<Audit>(AuditCollectionName);
                conectat = true;

                

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                conectat = false;

            }
            if (conectat == true)
            {
                this.Close();
            }
        }

        private void ConnectionStringForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing&&conectat==false)
            {
                Application.Exit();
            }
        }

        private void ConnectionStringForm_Load(object sender, EventArgs e)
        {

        }
    }
}
