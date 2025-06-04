using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        string connectionString = "Host=localhost;Username=postgres;Password=qwer1234;Database=mydatabase";
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
                var table = new DataTable();
                table.Load(reader);
                dataGridView1.DataSource = table;
            }
        }
        private void FormatDataGridView()
        {
            //dataGridView1.Columns["customer_id"].HeaderText = "ID klienta";
            dataGridView1.Columns["customer_name"].HeaderText = "Imię i nazwisko";
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
        private void Form2_Load(object sender, EventArgs e)
        {
            LoadData();
            FormatDataGridView();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;
            string address = txtAddress.Text;
            DateTime registeredAt = dtRegisteredAt.Value;

            DateTime orderDate = dateTimePicker.Value;
            decimal totalAmount = numericUpDown.Value;
            string status = cmbStatus.Text;
            string note = txtNote.Text;

            // Walidacja
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || totalAmount <= 0)
            {
                MessageBox.Show("Wszystkie wymagane pola muszą być wypełnione.");
                return;
            }

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                string query = @"INSERT INTO customers (name, email, phone, address, registered_at)
                         VALUES (@name, @email, @phone, @address, @registered_at)
                         RETURNING id";

                var cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("name", name);
                cmd.Parameters.AddWithValue("email", email);
                cmd.Parameters.AddWithValue("phone", phone);
                cmd.Parameters.AddWithValue("address", address);
                cmd.Parameters.AddWithValue("registered_at", registeredAt);

                int customerId = (int)cmd.ExecuteScalar();

                string orderQuery = @"INSERT INTO orders (customer_id, order_date, status, total_amount, note)
                              VALUES (@customerId, @orderDate, @status, @totalAmount, @note)";
                var orderCmd = new NpgsqlCommand(orderQuery, conn);
                orderCmd.Parameters.AddWithValue("customerId", customerId);
                orderCmd.Parameters.AddWithValue("orderDate", orderDate);
                orderCmd.Parameters.AddWithValue("status", status);
                orderCmd.Parameters.AddWithValue("totalAmount", totalAmount);
                orderCmd.Parameters.AddWithValue("note", note);

                orderCmd.ExecuteNonQuery();
                MessageBox.Show("Zapisano dane.");
            }

            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
