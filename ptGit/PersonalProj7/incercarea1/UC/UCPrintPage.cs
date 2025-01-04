using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Documents;
using System.Windows.Forms;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using Section = MigraDoc.DocumentObjectModel.Section;
using PdfSharp.Pdf.IO;
using PdfSharp.Pdf.Advanced;
using Paragraph = MigraDoc.DocumentObjectModel.Paragraph;
using System.Diagnostics;
using MySqlX.XDevAPI.Relational;
using Row = MigraDoc.DocumentObjectModel.Tables.Row;
using System.Data;
using MongoDB.Bson;
using MongoDB.Driver;

namespace incercarea1
{
    public partial class UCPrintPage : UserControl
    {
        private IMongoCollection<Audit> auditCollection;
        ConnectionStringForm connectionStringForm = ConnectionStringForm.Instanta();


        public UCPrintPage()
        {
            InitializeComponent();
            dataGridView1.CellPainting += DataGridView1_CellPainting;
            try
            {
                var client = new MongoClient(connectionStringForm.ConnectionString);
                var db = client.GetDatabase(connectionStringForm.DatabaseName);
                auditCollection = db.GetCollection<Audit>(connectionStringForm.AuditCollectionName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }




        private void Form3_Load(object sender, EventArgs e)
        {
            dataGridView1.Height = 403;

            /////////////////////////////////////////////////////////////

            //dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AllowUserToResizeColumns = false;

            /////////////////////////////////////////////

            dataGridView1.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SkyBlue;

            /////////////////////////////////////////
            //dataGridView2.Location = new System.Drawing.Point(dataGridView2.Location.X, dataGridView1.Location.Y + dataGridView1.Height);
            dataGridView1.Location = new System.Drawing.Point(dataGridView1.Location.X, dataGridView1.Location.Y);
            //dataGridView4.Location = new System.Drawing.Point(dataGridView4.Location.X, dataGridView3.Location.Y + dataGridView3.Height);
            //dataGridView5.Location = new System.Drawing.Point(dataGridView5.Location.X, dataGridView4.Location.Y + dataGridView4.Height);
            dataGridView6.Location = new System.Drawing.Point(dataGridView6.Location.X, dataGridView1.Bottom);
            //dataGridView7.Location = new System.Drawing.Point(dataGridView7.Location.X, dataGridView5.Location.Y + dataGridView5.Height);

            gestionarSemnatura.Location = new System.Drawing.Point(gestionarSemnatura.Location.X, dataGridView6.Location.Y + dataGridView6.Height + 20);
            verificat.Location = new System.Drawing.Point(verificat.Location.X, dataGridView6.Location.Y + dataGridView6.Height + 20);

            PrintBTN.Location = new System.Drawing.Point(ClientRectangle.Width / 2 - PrintBTN.Width / 2, verificat.Bottom - 20 + PrintBTN.Height / 2);

            emitatorLBL.Location = new System.Drawing.Point(emitator.Location.X + emitator.Width + 13 / 2, emitator.Location.Y);




            for (int i = 1; i < 19; i++)
            {



                dataGridView1.Rows.Add("", "", "", "", "", "", "");


            }


        }
        public void UpdateCells(DataGridView sourceGridView1,DataGridView sourceGridView2)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = sourceGridView1.Rows[i].Cells[j].Value;
                }
            }
            dataGridView6.Columns[1].HeaderText = sourceGridView2.Columns[1].HeaderText;

        }



        public void UpdateValues(string emitatorValue, string rapNrValue, string zile, string dataValue)
        {

            emitatorLBL.Text = emitatorValue;
            zileLBL.Text = zile;
            rapNrLBL.Text = rapNrValue;
            string textZileString = String.Empty;
            string textNrZile = String.Empty;
            if (String.IsNullOrEmpty(zileLBL.Text) == false && zileLBL.Text == "1")
            {
                textNrZile = "1";
                textZileString = "zi";
            }
            else if (String.IsNullOrEmpty(zileLBL.Text) == false && zileLBL.Text == "0")
            {
                textNrZile = "\u00A0\u00A0\u00A0";
                textZileString = "zile";
                MessageBox.Show("Numarul de zile trebuie sa fie diferit de 0 sau nespecificat");
                // return;
            }
            else if (String.IsNullOrEmpty(zileLBL.Text) == false && zileLBL.Text != "0" && zileLBL.Text != "1" && zileLBL.Text.Contains("-") == false && zileLBL.Text.Contains(".") == false)
            {
                textNrZile = zileLBL.Text;

                textZileString = "zile";
            }
            else if (zileLBL.Text.Contains("-") == true || zileLBL.Text.Contains(".") == true)
            {
                textNrZile = "\u00A0\u00A0\u00A0";
                textZileString = "zile";
                MessageBox.Show("Numarul zilelor trebuie sa fie pozitiv si intreg");
                //return;
            }
            else if (String.IsNullOrEmpty(zileLBL.Text))
            {

                textNrZile = "\u00A0\u00A0\u00A0";
                textZileString = "zile";
            }
            zileLBL.Text = textNrZile;
            zilePlusNrLBL.Text = $"{textZileString} nr.";
            if (dataValue != String.Empty)
            {
                dataLBL.Text = dataValue;
            }
            else
            {
                dataLBL.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
        }

        private void PrintBTN_Click(object sender, EventArgs e)
        {
            try
            {
                string locatie = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string nume = "v" + ".pdf";
                string path = Path.Combine(locatie, nume);
                ///
                Document document = new Document();
                Section section = document.AddSection();
                Paragraph paragraph = section.AddParagraph();

                paragraph.Format.Font.Color = MigraDoc.DocumentObjectModel.Colors.Black;
                paragraph.Format.Font.Size = 12;
                paragraph.AddFormattedText("EMITATOR  ", TextFormat.Bold);
                paragraph.AddText(emitatorLBL.Text);

                section.AddParagraph("\n\n\n");
                string textZile = String.Empty;
                string textNrZile = String.Empty;
                if (String.IsNullOrEmpty(zileLBL.Text) == false && zileLBL.Text == "1")
                {
                    textNrZile = "1";
                    textZile = "zi nr.";
                }
                else if (String.IsNullOrEmpty(zileLBL.Text) == false && zileLBL.Text != "0" && zileLBL.Text != "1" && zileLBL.Text.Contains("-") == false && zileLBL.Text.Contains(".") == false)
                {
                    textNrZile = zileLBL.Text;

                    textZile = "zile nr.";
                }
                else if (String.IsNullOrEmpty(zileLBL.Text))
                {

                    textNrZile = "\u00A0\u00A0\u00A0";
                    textZile = "zile nr.";
                }


                Paragraph paragraph1 = section.AddParagraph($"Raport de gestiune pe " + textNrZile + " " + textZile + rapNrLBL.Text);
                Paragraph paragraph2 = section.AddParagraph("Data  " + dataLBL.Text);

                if (textNrZile == "\u00A0\u00A0\u00A0" && rapNrLBL.Text.Length < 3)
                {
                    paragraph1.Format.LeftIndent = Unit.FromCentimeter(2);
                }
                else if (textNrZile == "\u00A0\u00A0\u00A0" && rapNrLBL.Text.Length < 6)
                {
                    paragraph1.Format.LeftIndent = Unit.FromCentimeter(1.5);
                }
                else if (textNrZile == "\u00A0\u00A0\u00A0" && rapNrLBL.Text.Length < 8)
                {
                    paragraph1.Format.LeftIndent = Unit.FromCentimeter(1);
                }

                else if (textNrZile == "\u00A0\u00A0\u00A0" && rapNrLBL.Text.Length >= 8)
                {
                    paragraph1.Format.LeftIndent = Unit.FromCentimeter(0.5);
                }
                else if (textNrZile =="1") 
                {
                    paragraph1.Format.LeftIndent = Unit.FromCentimeter(2);
                }
                else if (textNrZile.Length==1)
                {
                    paragraph1.Format.LeftIndent = Unit.FromCentimeter(0.25*9-(rapNrLBL.Text.Length*0.25)+0.5);
                }
                else if (textNrZile.Length == 2)
                {
                    paragraph1.Format.LeftIndent = Unit.FromCentimeter(0.25 * 9 - (rapNrLBL.Text.Length * 0.25) + 0.25);
                }
                else if (textNrZile.Length == 3)
                {
                    paragraph1.Format.LeftIndent = Unit.FromCentimeter(0.25 * 9 - (rapNrLBL.Text.Length * 0.25));
                }
                else if (textNrZile.Length == 4)
                {
                    paragraph1.Format.LeftIndent = Unit.FromCentimeter(0.25 * 9 - (rapNrLBL.Text.Length * 0.25)-0.25);
                }
                paragraph1.Format.Font.Size = 22;
                paragraph2.Format.LeftIndent = Unit.FromCentimeter(5.25);
                paragraph2.Format.Font.Size = 22;
                section.AddParagraph("\n\n");



                MigraDoc.DocumentObjectModel.Tables.Table table = section.AddTable();
                table.Borders.Width = 0.75;
                for (int col = 0; col < dataGridView1.ColumnCount; col++)
                {
                    if (col == 0)
                    {
                        table.AddColumn(Unit.FromCentimeter(5));
                    }
                    if (col == 1) { table.AddColumn(Unit.FromCentimeter(2.25)); }
                    if (col == 2) { table.AddColumn(Unit.FromCentimeter(2.25)); }
                    if (col == 3) { table.AddColumn(Unit.FromCentimeter(2.25)); }
                    if (col == 4) { table.AddColumn(Unit.FromCentimeter(2.25)); }
                    if (col == 5) { table.AddColumn(Unit.FromCentimeter(2.25)); }
                    if (col == 6) { table.AddColumn(Unit.FromCentimeter(2.25)); }
                }

                Row header = table.AddRow();
                header.Shading.Color = Colors.LightGray;
                header.Height = Unit.FromCentimeter(0.5);
                for (int col = 0; col < dataGridView1.ColumnCount; col++)
                {
                    header.Cells[col].AddParagraph(dataGridView1.Columns[col].HeaderText);
                }
                ////


                for (int row = 0; row < dataGridView1.RowCount; row++)
                {
                    Row dataRow = table.AddRow();
                    for (int col = 0; col < dataGridView1.ColumnCount; col++)
                    {
                        dataRow.Height = Unit.FromCentimeter(0.5);
                        dataRow.Cells[col].AddParagraph(dataGridView1.Rows[row].Cells[col].Value.ToString());
                    }
                }

                ///////////////////////////////////

                /////////////////

                //
                //
                MigraDoc.DocumentObjectModel.Tables.Table table6 = section.AddTable();
                table6.Borders.Width = 0.75;
                for (int col = 0; col < dataGridView6.ColumnCount; col++)
                {
                    if (col == 0)
                    {
                        table6.AddColumn(Unit.FromCentimeter(14));
                    }
                    if (col == 1) { table6.AddColumn(Unit.FromCentimeter(2.25)); }
                    //if (col == 2) { table6.AddColumn(Unit.FromCentimeter(3.17)); }
                }

                Row header6 = table6.AddRow();
                header6.Shading.Color = Colors.LightGray;
                header6.Height = Unit.FromCentimeter(0.5);
                for (int col = 0; col < dataGridView6.ColumnCount; col++)
                {
                    header6.Cells[col].AddParagraph(dataGridView6.Columns[col].HeaderText);

                }

                for (int row = 0; row < dataGridView6.RowCount; row++)
                {
                    //Row dataRow = table.AddRow();
                    for (int col = 0; col < dataGridView6.ColumnCount; col++)
                    {
                        //dataRow.Cells[col].AddParagraph(dataGridView3.Rows[row].Cells[col].Value.ToString());
                    }
                }
                ////
                ///
                section.AddParagraph("\n\n");

                MigraDoc.DocumentObjectModel.Tables.Table table7 = section.AddTable();
                for (int col = 0; col < 5; col++)
                {
                    if (col == 0)
                    {
                        table7.AddColumn(Unit.FromCentimeter(3.3));
                    }
                    if (col == 1) { table7.AddColumn(Unit.FromCentimeter(3.3)); }
                    if (col == 2) { table7.AddColumn(Unit.FromCentimeter(3.3)); }
                    if (col == 3) { table7.AddColumn(Unit.FromCentimeter(3.3)); }
                    if (col == 4) { table7.AddColumn(Unit.FromCentimeter(3.3)); }
                }
                Paragraph paragraph3 = section.AddParagraph();


                for (int row = 0; row < 1; row++)
                {
                    Row dataRow = table7.AddRow();
                    for (int col = 0; col < 5; col++)
                    {
                        if (col == 0)
                        {
                            paragraph3 = dataRow.Cells[0].AddParagraph("Gestionar,");
                            paragraph3.Format.Font.Size = 26;
                        }
                        if (col == 1)
                        {
                            dataRow.Cells[1].AddParagraph();


                        }
                        if (col == 2) { dataRow.Cells[2].AddParagraph(); }
                        if (col == 3) { paragraph3 = dataRow.Cells[3].AddParagraph("Verificat,"); paragraph3.Format.Font.Size = 26; }
                        if (col == 4) { dataRow.Cells[4].AddParagraph(); }
                    }
                }
                ////
                PdfDocumentRenderer pdfDocumentRenderer = new PdfDocumentRenderer(false, PdfFontEmbedding.Always);
                pdfDocumentRenderer.Document = document;
                pdfDocumentRenderer.RenderDocument();
                pdfDocumentRenderer.PdfDocument.Save(path);

                AddToAudit($"{System.DateTime.UtcNow}: Userul \'{Settings1.Default.connectedUser1}\' a salvat un raport");


                Process.Start(path);

                ///
                MessageBox.Show("saved at: " + path);
            }
            catch (Exception ex)
            {
                MessageBox.Show("error: " + ex.Message);
            }
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

                    using (System.Drawing.Font headerFont = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular))
                    {
                        e.Graphics.DrawString(e.Value?.ToString(), headerFont, Brushes.Black, e.CellBounds, sf);
                    }

                    e.Handled = true;
                }
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
