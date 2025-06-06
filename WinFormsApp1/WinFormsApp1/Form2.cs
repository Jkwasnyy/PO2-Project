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
                                c.id AS customer_id,
                                o.id AS order_id,
                                o.order_date,
                                o.status,
                                o.total_amount,
                                o.note
                                FROM customers c
                                JOIN orders o ON c.id = o.customer_id
                                ORDER BY o.order_date DESC";

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
            LoadStatusFilter(); //lista statusow do filtrowania przez comboboxa
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

                int customerId = (int)cmd.ExecuteScalar(); //pobieramy id dla klienta

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

        private int selectedCustomerId = -1;
        private int selectedOrderId = -1;

        //rekord -> pola formularza
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                selectedCustomerId = Convert.ToInt32(row.Cells["customer_id"].Value);
                selectedOrderId = Convert.ToInt32(row.Cells["order_id"].Value);

                txtName.Text = row.Cells["customer_name"].Value.ToString();
                txtEmail.Text = row.Cells["email"].Value.ToString();
                txtPhone.Text = row.Cells["phone"].Value.ToString();
                txtAddress.Text = row.Cells["address"].Value.ToString();
                dtRegisteredAt.Value = Convert.ToDateTime(row.Cells["registered_at"].Value);

                dateTimePicker.Value = Convert.ToDateTime(row.Cells["order_date"].Value);
                cmbStatus.Text = row.Cells["status"].Value.ToString();
                numericUpDown.Value = Convert.ToDecimal(row.Cells["total_amount"].Value);
                txtNote.Text = row.Cells["note"].Value.ToString();
            }
        }

        //update danych
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedCustomerId == -1 || selectedOrderId == -1)
            {
                MessageBox.Show("Wybierz rekord do edycji.");
                return;
            }

            string name = txtName.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;
            string address = txtAddress.Text;
            DateTime registeredAt = dtRegisteredAt.Value;

            DateTime orderDate = dateTimePicker.Value;
            decimal totalAmount = numericUpDown.Value;
            string status = cmbStatus.Text;
            string note = txtNote.Text;

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                string updateCustomer = @"UPDATE customers 
                                          SET name = @name, email = @email, phone = @phone, address = @address, registered_at = @registered_at 
                                          WHERE id = @customerId";
                var cmd = new NpgsqlCommand(updateCustomer, conn);
                cmd.Parameters.AddWithValue("name", name);
                cmd.Parameters.AddWithValue("email", email);
                cmd.Parameters.AddWithValue("phone", phone);
                cmd.Parameters.AddWithValue("address", address);
                cmd.Parameters.AddWithValue("registered_at", registeredAt);
                cmd.Parameters.AddWithValue("customerId", selectedCustomerId);
                cmd.ExecuteNonQuery();

                string updateOrder = @"UPDATE orders 
                                       SET order_date = @orderDate, status = @status, total_amount = @totalAmount, note = @note 
                                       WHERE id = @orderId";
                var orderCmd = new NpgsqlCommand(updateOrder, conn);
                orderCmd.Parameters.AddWithValue("orderDate", orderDate);
                orderCmd.Parameters.AddWithValue("status", status);
                orderCmd.Parameters.AddWithValue("totalAmount", totalAmount);
                orderCmd.Parameters.AddWithValue("note", note);
                orderCmd.Parameters.AddWithValue("orderId", selectedOrderId);
                orderCmd.ExecuteNonQuery();

                MessageBox.Show("Zaktualizowano dane.");
            }

            LoadData();
        }

        //delete rekordow
        private void button1_Click(object sender, EventArgs e)
        {
            if (selectedCustomerId == -1 || selectedOrderId == -1)
            {
                MessageBox.Show("Wybierz rekord do edycji.");
                return;
            }

            string name = txtName.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;
            string address = txtAddress.Text;
            DateTime registeredAt = dtRegisteredAt.Value;

            DateTime orderDate = dateTimePicker.Value;
            decimal totalAmount = numericUpDown.Value;
            string status = cmbStatus.Text;
            string note = txtNote.Text;

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                string updateCustomer = @"DELETE FROM customers WHERE id = @customerId";
                var cmd = new NpgsqlCommand(updateCustomer, conn);
                cmd.Parameters.AddWithValue("name", name);
                cmd.Parameters.AddWithValue("email", email);
                cmd.Parameters.AddWithValue("phone", phone);
                cmd.Parameters.AddWithValue("address", address);
                cmd.Parameters.AddWithValue("registered_at", registeredAt);
                cmd.Parameters.AddWithValue("customerId", selectedCustomerId);
                cmd.ExecuteNonQuery();

                string updateOrder = @"DELETE FROM orders WHERE id = @orderId";
                var orderCmd = new NpgsqlCommand(updateOrder, conn);
                orderCmd.Parameters.AddWithValue("orderDate", orderDate);
                orderCmd.Parameters.AddWithValue("status", status);
                orderCmd.Parameters.AddWithValue("totalAmount", totalAmount);
                orderCmd.Parameters.AddWithValue("note", note);
                orderCmd.Parameters.AddWithValue("orderId", selectedOrderId);
                orderCmd.ExecuteNonQuery();

                MessageBox.Show("Rekord został usunięty.");
            }

            LoadData();
        }

        //combobox do filracji - pobieramy sobie statusy i dajemy do combobx
        private void LoadStatusFilter()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Wszystkie");

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new NpgsqlCommand("SELECT DISTINCT status FROM orders", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader.GetString(0));
                }
            }

            comboBox1.SelectedIndex = 0; //default wszystkie wyswietlamy
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedStatus = comboBox1.SelectedItem?.ToString();

            if (selectedStatus == "Wszystkie")
            {
                LoadData();
                return;
            }

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT
                            c.name AS customer_name,
                            c.email,
                            c.phone,
                            c.address,
                            c.registered_at,
                            c.id AS customer_id,
                            o.id AS order_id,
                            o.order_date,
                            o.status,
                            o.total_amount,
                            o.note
                         FROM customers c
                         JOIN orders o ON c.id = o.customer_id
                         WHERE o.status = @status
                         ORDER BY o.order_date DESC";

                var cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("status", selectedStatus);
                var reader = cmd.ExecuteReader();
                var table = new DataTable();
                table.Load(reader);
                dataGridView1.DataSource = table;
            }

            FormatDataGridView();
        }


    }
}
