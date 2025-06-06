using System.Windows.Forms;
using System.Xml.Linq;

namespace WinFormsApp1
{
    partial class Form2
    {
        private System.ComponentModel.IContainer components = null;

        private void InitializeComponent()
        {
            button1 = new Button();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnSave = new Button();
            numericUpDown = new NumericUpDown();
            dateTimePicker = new DateTimePicker();
            txtEmail = new TextBox();
            txtName = new TextBox();
            dataGridView1 = new DataGridView();
            txtPhone = new TextBox();
            txtAddress = new TextBox();
            cmbStatus = new ComboBox();
            dtRegisteredAt = new DateTimePicker();
            lblPhone = new Label();
            lblAddress = new Label();
            lblReg = new Label();
            lblStatus = new Label();
            lblNote = new Label();
            txtNote = new TextBox();
            button2 = new Button();
            btnUpdate = new Button();
            comboBox1 = new ComboBox();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(255, 128, 128);
            button1.Location = new Point(165, 113);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 22;
            button1.Text = "Delete";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 87);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 21;
            label4.Text = "Price:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 61);
            label3.Name = "label3";
            label3.Size = new Size(66, 15);
            label3.TabIndex = 20;
            label3.Text = "Order date:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 35);
            label2.Name = "label2";
            label2.Size = new Size(44, 15);
            label2.TabIndex = 19;
            label2.Text = "E-mail:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 18;
            label1.Text = "Name:";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(128, 255, 128);
            btnSave.Location = new Point(84, 113);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 17;
            btnSave.Text = "Add";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // numericUpDown
            // 
            numericUpDown.Location = new Point(84, 84);
            numericUpDown.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDown.Name = "numericUpDown";
            numericUpDown.Size = new Size(120, 23);
            numericUpDown.TabIndex = 16;
            // 
            // dateTimePicker
            // 
            dateTimePicker.Location = new Point(84, 58);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(200, 23);
            dateTimePicker.TabIndex = 15;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(84, 32);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(200, 23);
            txtEmail.TabIndex = 14;
            // 
            // txtName
            // 
            txtName.Location = new Point(84, 6);
            txtName.Name = "txtName";
            txtName.Size = new Size(200, 23);
            txtName.TabIndex = 13;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 142);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(776, 389);
            dataGridView1.TabIndex = 12;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(451, 6);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(200, 23);
            txtPhone.TabIndex = 0;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(451, 32);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(200, 23);
            txtAddress.TabIndex = 2;
            // 
            // cmbStatus
            // 
            cmbStatus.Items.AddRange(new object[] { "Nowe", "W realizacji", "Zrealizowane" });
            cmbStatus.Location = new Point(451, 84);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(200, 23);
            cmbStatus.TabIndex = 6;
            // 
            // dtRegisteredAt
            // 
            dtRegisteredAt.Location = new Point(451, 58);
            dtRegisteredAt.Name = "dtRegisteredAt";
            dtRegisteredAt.Size = new Size(200, 23);
            dtRegisteredAt.TabIndex = 4;
            // 
            // lblPhone
            // 
            lblPhone.Location = new Point(345, 6);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(100, 23);
            lblPhone.TabIndex = 1;
            lblPhone.Text = "Phone:";
            // 
            // lblAddress
            // 
            lblAddress.Location = new Point(345, 32);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(100, 23);
            lblAddress.TabIndex = 3;
            lblAddress.Text = "Address:";
            // 
            // lblReg
            // 
            lblReg.Location = new Point(345, 58);
            lblReg.Name = "lblReg";
            lblReg.Size = new Size(100, 23);
            lblReg.TabIndex = 5;
            lblReg.Text = "Register date:";
            // 
            // lblStatus
            // 
            lblStatus.Location = new Point(345, 84);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(59, 23);
            lblStatus.TabIndex = 7;
            lblStatus.Text = "Status";
            // 
            // lblNote
            // 
            lblNote.Location = new Point(345, 110);
            lblNote.Name = "lblNote";
            lblNote.Size = new Size(59, 23);
            lblNote.TabIndex = 8;
            lblNote.Text = "Note:";
            // 
            // txtNote
            // 
            txtNote.Location = new Point(451, 110);
            txtNote.Name = "txtNote";
            txtNote.Size = new Size(200, 23);
            txtNote.TabIndex = 23;
            // 
            // button2
            // 
            button2.BackColor = Color.MediumTurquoise;
            button2.Location = new Point(713, 113);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 24;
            button2.Text = "Back";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.Plum;
            btnUpdate.Location = new Point(246, 113);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 25;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(667, 84);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 26;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(667, 66);
            label5.Name = "label5";
            label5.Size = new Size(105, 15);
            label5.TabIndex = 27;
            label5.Text = "Status zamówienia";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 543);
            Controls.Add(label5);
            Controls.Add(comboBox1);
            Controls.Add(btnUpdate);
            Controls.Add(button2);
            Controls.Add(txtNote);
            Controls.Add(lblPhone);
            Controls.Add(lblAddress);
            Controls.Add(lblReg);
            Controls.Add(lblStatus);
            Controls.Add(lblNote);
            Controls.Add(dtRegisteredAt);
            Controls.Add(cmbStatus);
            Controls.Add(txtAddress);
            Controls.Add(txtPhone);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnSave);
            Controls.Add(numericUpDown);
            Controls.Add(dateTimePicker);
            Controls.Add(txtEmail);
            Controls.Add(txtName);
            Controls.Add(dataGridView1);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private Button button1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnSave;
        private NumericUpDown numericUpDown;
        private DateTimePicker dateTimePicker;
        private TextBox txtEmail;
        private TextBox txtName;
        private DataGridView dataGridView1;
        private TextBox txtPhone;
        private TextBox txtAddress;
        private ComboBox cmbStatus;
        private DateTimePicker dtRegisteredAt;
        private Label lblPhone;
        private Label lblAddress;
        private Label lblReg;
        private Label lblStatus;
        private Label lblNote;
        private TextBox txtNote;
        private Button button2;
        private Button btnUpdate;
        private ComboBox comboBox1;
        private Label label5;
    }
}