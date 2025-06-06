using System;
using System.Data;
using System.Windows.Forms;
using System.Xml.Linq;
using Npgsql;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        //Connection z postgres baza adanych
        string connectionString = "Host=localhost;Username=postgres;Password=qwer1234;Database=mydatabase";
        //Przechowywanie danych podczas filtrowania
        private DataTable originalTable;


        public Form1()
        {
            InitializeComponent();
        }

        //£adowanie i wyswietanie datagridview
        private void LoadData()
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT                                 
                                c.name AS customer_name,
                                c.email,
                                c.phone,
                                c.address,
                                c.registered_at,
                                o.order_date,
                                o.status,
                                o.total_amount,
                                o.note
                                FROM customers c
                                JOIN orders o ON c.id = o.customer_id
                                ORDER BY o.order_date DESC";
                //c.id AS customer_id,
                //o.id AS order_id,
                var cmd = new NpgsqlCommand(query, conn);
                var reader = cmd.ExecuteReader();

                originalTable = new DataTable(); //ladujemy dane do tabeli
                originalTable.Load(reader);

                dataGridView1.DataSource = originalTable;

                dataGridView1.ReadOnly = true;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.MultiSelect = false;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;
            }
        }
        //formatowanie datagridview
        private void FormatDataGridView()
        {
            //dataGridView1.Columns["customer_id"].HeaderText = "ID klienta";
            dataGridView1.Columns["customer_name"].HeaderText = "Imiê i nazwisko";
            dataGridView1.Columns["email"].HeaderText = "Email";
            dataGridView1.Columns["phone"].HeaderText = "Telefon";
            dataGridView1.Columns["address"].HeaderText = "Adres";
            dataGridView1.Columns["registered_at"].HeaderText = "Zarejestrowany";
            //dataGridView1.Columns["order_id"].HeaderText = "ID zamówienia";
            dataGridView1.Columns["order_date"].HeaderText = "Data zamówienia";
            dataGridView1.Columns["status"].HeaderText = "Status";
            dataGridView1.Columns["total_amount"].HeaderText = "Kwota";
            dataGridView1.Columns["note"].HeaderText = "Notatka";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        //filtracja przez wpisanie
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            //filterText -> [txtfilter] -> Trim (kasujemy spacje/taby) ->  Replace (zamieniamy ' na '' zeby nie bylo bledu w skladni sql) -> DataView -> RowFilter
            string filterText = txtFilter.Text.Trim().Replace("'", "''"); 

            if (originalTable == null)
                return;

            DataView view = new DataView(originalTable);
            view.RowFilter = $"customer_name LIKE '%{filterText}%'";
            dataGridView1.DataSource = view;
        }



        //Podstawowe ladowanie danych na start
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData(); //dane z bazy
            FormatDataGridView(); //formatka kolumn
        }

        
private void BtnEdit_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }
    }
}
