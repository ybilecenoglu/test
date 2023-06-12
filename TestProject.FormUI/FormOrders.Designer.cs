namespace TestProject.FormUI
{
    partial class FormOrders
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
            dgwOrders = new System.Windows.Forms.DataGridView();
            dtpStart = new System.Windows.Forms.DateTimePicker();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            dtpEnd = new System.Windows.Forms.DateTimePicker();
            btnGetList = new System.Windows.Forms.Button();
            groupBox1 = new System.Windows.Forms.GroupBox();
            cbxEmployee = new System.Windows.Forms.ComboBox();
            label4 = new System.Windows.Forms.Label();
            cbxCustomer = new System.Windows.Forms.ComboBox();
            label3 = new System.Windows.Forms.Label();
            btnNextPage = new System.Windows.Forms.Button();
            btnPrevious = new System.Windows.Forms.Button();
            lblPageNo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)dgwOrders).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dgwOrders
            // 
            dgwOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgwOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwOrders.Location = new System.Drawing.Point(12, 276);
            dgwOrders.Name = "dgwOrders";
            dgwOrders.RowTemplate.Height = 25;
            dgwOrders.Size = new System.Drawing.Size(1032, 471);
            dgwOrders.TabIndex = 0;
            // 
            // dtpStart
            // 
            dtpStart.Location = new System.Drawing.Point(557, 247);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new System.Drawing.Size(164, 23);
            dtpStart.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(555, 225);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(31, 15);
            label1.TabIndex = 2;
            label1.Text = "Start";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(744, 225);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(27, 15);
            label2.TabIndex = 4;
            label2.Text = "End";
            // 
            // dtpEnd
            // 
            dtpEnd.Location = new System.Drawing.Point(746, 247);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new System.Drawing.Size(164, 23);
            dtpEnd.TabIndex = 3;
            // 
            // btnGetList
            // 
            btnGetList.Location = new System.Drawing.Point(926, 247);
            btnGetList.Name = "btnGetList";
            btnGetList.Size = new System.Drawing.Size(118, 23);
            btnGetList.TabIndex = 5;
            btnGetList.Text = "Get List";
            btnGetList.UseVisualStyleBackColor = true;
            btnGetList.Click += btnGetList_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cbxEmployee);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(cbxCustomer);
            groupBox1.Controls.Add(label3);
            groupBox1.Location = new System.Drawing.Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(489, 258);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Order Details";
            // 
            // cbxEmployee
            // 
            cbxEmployee.FormattingEnabled = true;
            cbxEmployee.Location = new System.Drawing.Point(6, 96);
            cbxEmployee.Name = "cbxEmployee";
            cbxEmployee.Size = new System.Drawing.Size(121, 23);
            cbxEmployee.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(6, 78);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(59, 15);
            label4.TabIndex = 2;
            label4.Text = "Employee";
            // 
            // cbxCustomer
            // 
            cbxCustomer.FormattingEnabled = true;
            cbxCustomer.Location = new System.Drawing.Point(6, 43);
            cbxCustomer.Name = "cbxCustomer";
            cbxCustomer.Size = new System.Drawing.Size(121, 23);
            cbxCustomer.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(6, 25);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(59, 15);
            label3.TabIndex = 0;
            label3.Text = "Customer";
            // 
            // btnNextPage
            // 
            btnNextPage.Location = new System.Drawing.Point(598, 770);
            btnNextPage.Name = "btnNextPage";
            btnNextPage.Size = new System.Drawing.Size(75, 23);
            btnNextPage.TabIndex = 7;
            btnNextPage.Text = ">";
            btnNextPage.UseVisualStyleBackColor = true;
            btnNextPage.Click += btnNextPage_Click;
            // 
            // btnPrevious
            // 
            btnPrevious.Location = new System.Drawing.Point(397, 770);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new System.Drawing.Size(75, 23);
            btnPrevious.TabIndex = 8;
            btnPrevious.Text = "<";
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += btnPrevious_Click;
            // 
            // lblPageNo
            // 
            lblPageNo.AutoSize = true;
            lblPageNo.Location = new System.Drawing.Point(514, 775);
            lblPageNo.Name = "lblPageNo";
            lblPageNo.Size = new System.Drawing.Size(44, 15);
            lblPageNo.TabIndex = 9;
            lblPageNo.Text = "Label 1";
            // 
            // FormOrders
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1056, 830);
            Controls.Add(lblPageNo);
            Controls.Add(btnPrevious);
            Controls.Add(btnNextPage);
            Controls.Add(groupBox1);
            Controls.Add(btnGetList);
            Controls.Add(label2);
            Controls.Add(dtpEnd);
            Controls.Add(label1);
            Controls.Add(dtpStart);
            Controls.Add(dgwOrders);
            Name = "FormOrders";
            Text = "FormOrders";
            Load += FormOrders_Load;
            ((System.ComponentModel.ISupportInitialize)dgwOrders).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgwOrders;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Button btnGetList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbxEmployee;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxCustomer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Label lblPageNo;
    }
}