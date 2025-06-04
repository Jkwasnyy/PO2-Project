namespace WinFormsApp1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            BtnEdit = new Button();
            txtFilter = new TextBox();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 99);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1028, 517);
            dataGridView1.TabIndex = 0;
            // 
            // BtnEdit
            // 
            BtnEdit.BackColor = Color.Khaki;
            BtnEdit.Location = new Point(223, 69);
            BtnEdit.Name = "BtnEdit";
            BtnEdit.Size = new Size(75, 23);
            BtnEdit.TabIndex = 11;
            BtnEdit.Text = "Edit";
            BtnEdit.UseVisualStyleBackColor = false;
            BtnEdit.Click += BtnEdit_Click;
            // 
            // txtFilter
            // 
            txtFilter.Location = new Point(12, 70);
            txtFilter.Name = "txtFilter";
            txtFilter.Size = new Size(205, 23);
            txtFilter.TabIndex = 12;
            txtFilter.TextChanged += txtFilter_TextChanged;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.White;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Georgia", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            textBox1.Location = new Point(12, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(1028, 40);
            textBox1.TabIndex = 14;
            textBox1.Text = "System Zamówień – Podgląd Danych";
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // Form1
            // 
            BackColor = Color.White;
            ClientSize = new Size(1052, 628);
            Controls.Add(textBox1);
            Controls.Add(txtFilter);
            Controls.Add(BtnEdit);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Aplikacja do zarządzania zamówieniami";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.DataGridView dataGridView1;
        private Button BtnEdit;
        private TextBox txtFilter;
        private TextBox textBox1;
    }
}
