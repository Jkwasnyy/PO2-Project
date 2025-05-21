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
                string query = "SELECT c.id, c.name, c.email, o.order_date, o.total_amount FROM customers c JOIN orders o ON c.id = o.customer_id";
                var cmd = new NpgsqlCommand(query, conn);
                var reader = cmd.ExecuteReader();
                var table = new DataTable();
                table.Load(reader);
                dataGridView1.DataSource = table;
            }
        }

        //Zapis danych do bazy danuch
        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string email = txtEmail.Text;
            DateTime orderDate = dateTimePicker.Value;
            decimal totalAmount = numericUpDown.Value;
            numericUpDown.Minimum = 0;
            numericUpDown.Maximum = 10000; //Dodane tez w designer bo idk czemu nie dziala - limit max 100 ZROBIC!!!!!!

            //Validacja
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || totalAmount <= 0)
            {
                MessageBox.Show("Wszystkie pola musz¹ byæ wype³nione poprawnie.");
                return;
            }

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO customers (name, email) VALUES (@name, @email) RETURNING id";
                var cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("name", name);
                cmd.Parameters.AddWithValue("email", email);

                int customerId = (int)cmd.ExecuteScalar(); //Pobranie id klienta

                string orderQuery = "INSERT INTO orders (customer_id, order_date, total_amount) VALUES (@customerId, @orderDate, @totalAmount)";
                var orderCmd = new NpgsqlCommand(orderQuery, conn);
                orderCmd.Parameters.AddWithValue("customerId", customerId);
                orderCmd.Parameters.AddWithValue("orderDate", orderDate);
                orderCmd.Parameters.AddWithValue("totalAmount", totalAmount);

                orderCmd.ExecuteNonQuery();
                MessageBox.Show("Zapisano dane.");
            }

            LoadData(); //Zaladowanie danych po 'save'
        }

        //Podstawowe ladowanie danych na start
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        //Usuwanie rekordów
        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Wybierz rekord do usuniêcia.");
                return;
            }

            var result = MessageBox.Show("Czy na pewno chcesz usun¹æ wybrany rekord?", "Potwierdzenie", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes)
                return;

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                if (!row.IsNewRow)
                {
                    int id = Convert.ToInt32(row.Cells["id"].Value);
                    DeleteRecord(id);
                }
            }

            LoadData();
        }

        private void DeleteRecord(int id)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                //Usuwanie zamowien powi¹zanych z klientem
                var cmdOrder = new NpgsqlCommand("DELETE FROM orders WHERE customer_id = @id", conn);
                cmdOrder.Parameters.AddWithValue("id", id);
                cmdOrder.ExecuteNonQuery();

                //Usuwanie klienta
                var cmdCustomer = new NpgsqlCommand("DELETE FROM customers WHERE id = @id", conn);
                cmdCustomer.Parameters.AddWithValue("id", id);
                cmdCustomer.ExecuteNonQuery();
            }
        }

    }
}
