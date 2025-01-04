using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;
using System.Windows;
using MigraDoc.DocumentObjectModel.Tables;
using System.CodeDom;
using System.Collections;
using incercarea1.Forms;
using System.Diagnostics.Metrics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Windows.Controls;

namespace incercarea1
{

    public partial class UCEdit : System.Windows.Forms.UserControl
    {
        public string Unitatea { get { return (emitatorTB.Text); } }
        public string Zile { get { return (zileTB.Text); } }
        //public string Gestionar { get { return (Gestionar_Text.Text); } }
        public string NrRaport { get { return (nrTB.Text); } }
        public string DataRaport { get { return (dataTB.Text); } }


        private static bool conectat = false;
        ConnectionStringForm connectionStringForm = ConnectionStringForm.Instanta();


        private IMongoCollection<Audit> collection;
        private IMongoCollection<MongoProiecte> proiecteCollection;

        public UCEdit()
        {

            InitializeComponent();

            dataGridView1.CellPainting += DataGridView1_CellPainting;
            dataGridView1.CellClick += DataGridView1_CellClick;
            dataGridView1.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SkyBlue;
            zileTB.TextChanged += NrZileModified;
        }



        private async void Form2_Load(object sender, EventArgs e)
        {

            if (conectat == false)
            {
                // connectionStringForm.ShowDialog();

                try
                {

                    var client = new MongoClient(connectionStringForm.ConnectionString);
                    var db = client.GetDatabase(connectionStringForm.DatabaseName);
                    collection = db.GetCollection<Audit>(connectionStringForm.AuditCollectionName);
                    proiecteCollection = db.GetCollection<MongoProiecte>(connectionStringForm.ProiecteCollectionName);
                    conectat = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            dataGridView1.Height = 406;

            gestionarSemnatura.Location = new System.Drawing.Point(gestionarSemnatura.Location.X, dataGridView6.Location.Y + dataGridView6.Height + 20);
            verificat.Location = new System.Drawing.Point(verificat.Location.X, dataGridView6.Location.Y + dataGridView6.Height + 20);

            for (int i = 1; i < 19; i++)
            {
                dataGridView1.Rows.Add("", "", "", "", "", "");


            }


        }

        private async void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {

                //ContextMenu contextMenu = new ContextMenu();

                //MenuItem dbSelect = new MenuItem("Select a document from the database");
                //MenuItem addNew = new MenuItem("Add new");

                //dbSelect.Click += SelectFromDatabaseClicked;
                //addNew.Click += AddNewClicked;

                //contextMenu.MenuItems.Add(dbSelect);
                //contextMenu.MenuItems.Add(addNew);


                //for (int i = 0; i < 200; i++)
                //{
                //    contextMenu.MenuItems.Add(new MenuItem(i.ToString()));

                //}
                //contextMenu.Show(dataGridView1, dataGridView1.PointToClient(Cursor.Position));


                DataGridView dataGrid = sender as DataGridView;
                int rowIndex = dataGrid.CurrentCell.RowIndex;

                RowValues rw = new RowValues();
                int nrCrtOut = 0;

                rw.ShowDialog();//Folosesc ShowDialog pentru a nu trece direct la liniile urmatoare
                var counter = 0;
                int data = 0;
                if (int.TryParse(zileTB.Text, out data))
                {

                }
                else
                {
                    data = 0;
                }
                if (rw.UsersList.Count > 0)
                {
                    foreach (var item in rw.UsersList)
                    {
                        if (rowIndex + counter >= dataGrid.RowCount)
                        {
                            break;
                        }
                        int aprobateCount = ProjectsCount(item, "Approved", data);
                        int respinseCount = ProjectsCount(item, "Rejected", data);
                        int inLucruCount = ProjectsCount(item, "In Progress", data);
                        int finishedCount = ProjectsCount(item, "Finished", data);
                        dataGrid.Rows[rowIndex + counter].Cells[0].Value = item;
                        dataGrid.Rows[rowIndex + counter].Cells[1].Value = aprobateCount;
                        dataGrid.Rows[rowIndex + counter].Cells[2].Value = respinseCount;
                        dataGrid.Rows[rowIndex + counter].Cells[3].Value = inLucruCount;
                        dataGrid.Rows[rowIndex + counter].Cells[4].Value = finishedCount;
                        dataGrid.Rows[rowIndex + counter].Cells[5].Value = aprobateCount + respinseCount + inLucruCount + finishedCount;
                        counter++;
                    }
                }
                else
                {
                    dataGrid.Rows[rowIndex + counter].Cells[0].Value = "";
                    dataGrid.Rows[rowIndex + counter].Cells[1].Value = "";
                    dataGrid.Rows[rowIndex + counter].Cells[2].Value = "";
                    dataGrid.Rows[rowIndex + counter].Cells[3].Value = "";
                    dataGrid.Rows[rowIndex + counter].Cells[4].Value = "";
                    dataGrid.Rows[rowIndex + counter].Cells[5].Value = "";
                }


            }
            int sumaTotala = 0;
            foreach(DataGridViewRow dataGridViewRow in dataGridView1.Rows)
            {
                if (dataGridViewRow.Cells[5].Value!=null && int.TryParse(dataGridViewRow.Cells[5].Value.ToString(),out int total)){
                    sumaTotala += total;
                }
            }
            dataGridView6.Columns[1].HeaderText = sumaTotala.ToString();



        }
        private void DataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex >= 0)//daca e header
            {
                e.PaintBackground(e.CellBounds, true);

                using (StringFormat sf = new StringFormat())
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;

                    using (Font headerFont = new Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular))
                    {
                        e.Graphics.DrawString(e.Value?.ToString(), headerFont, Brushes.Black, e.CellBounds, sf);
                    }

                    e.Handled = true;
                }
            }
        }


        private int ProjectsCount(string user, string projectStatus, int numarZie)
        {
            try
            {
                long count = 0;
                if (numarZie > 0)
                {
                    DateTime data = DateTime.Today.AddDays(-numarZie);
                    FilterDefinition<MongoProiecte> filter = Builders<MongoProiecte>.Filter.And(
                                        Builders<MongoProiecte>.Filter.AnyEq(x => x.AssignedTo, user),
                                        Builders<MongoProiecte>.Filter.Eq("Status", projectStatus),
                                        Builders<MongoProiecte>.Filter.Gt("LastUpdated", data)
                                    );
                    count = proiecteCollection.CountDocuments(filter);
                }
                else
                {
                    FilterDefinition<MongoProiecte> filter = Builders<MongoProiecte>.Filter.And(
                                        Builders<MongoProiecte>.Filter.AnyEq(x => x.AssignedTo, user),
                                        Builders<MongoProiecte>.Filter.Eq("Status", projectStatus)
                                    );
                    count = proiecteCollection.CountDocuments(filter);
                }

                return (int)count;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Ceva nu a mers!");
                return 0;
            }
        }

        private void NrZileModified(object sender,EventArgs e)
        {
            ClearCells();
        }
        private void ClearCells()
        {
            foreach(DataGridViewRow dataGridRow in dataGridView1.Rows)
            {
                foreach(DataGridViewCell dataGridCell in dataGridRow.Cells)
                {
                    dataGridCell.Value = String.Empty;
                }
            }
            dataGridView6.Columns[1].HeaderText = "";

        }
    }
}
