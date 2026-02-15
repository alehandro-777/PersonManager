namespace PersonManager.WinForms
{
    partial class PersonDetailsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblName = new Label();
            dataGridViewAddresses = new DataGridView();
            dataGridViewPhones = new DataGridView();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAddresses).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPhones).BeginInit();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(26, 22);
            lblName.Name = "lblName";
            lblName.Size = new Size(50, 20);
            lblName.TabIndex = 0;
            lblName.Text = "label1";
            // 
            // dataGridViewAddresses
            // 
            dataGridViewAddresses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAddresses.Location = new Point(12, 63);
            dataGridViewAddresses.Name = "dataGridViewAddresses";
            dataGridViewAddresses.RowHeadersWidth = 51;
            dataGridViewAddresses.Size = new Size(574, 188);
            dataGridViewAddresses.TabIndex = 1;
            // 
            // dataGridViewPhones
            // 
            dataGridViewPhones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPhones.Location = new Point(592, 63);
            dataGridViewPhones.Name = "dataGridViewPhones";
            dataGridViewPhones.RowHeadersWidth = 51;
            dataGridViewPhones.Size = new Size(196, 188);
            dataGridViewPhones.TabIndex = 2;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(694, 292);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(94, 29);
            btnClose.TabIndex = 3;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click_1;
            // 
            // PersonDetailsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 351);
            Controls.Add(btnClose);
            Controls.Add(dataGridViewPhones);
            Controls.Add(dataGridViewAddresses);
            Controls.Add(lblName);
            Name = "PersonDetailsForm";
            Text = "PersonDetailsForm";
            ((System.ComponentModel.ISupportInitialize)dataGridViewAddresses).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPhones).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblName;
        private DataGridView dataGridViewAddresses;
        private DataGridView dataGridViewPhones;
        private Button btnClose;
    }
}