namespace TestProject
{
    partial class FormEmployes
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
            label4 = new System.Windows.Forms.Label();
            tbxSearch = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            gdwEmployee = new System.Windows.Forms.DataGridView();
            groupBox1 = new System.Windows.Forms.GroupBox();
            tbxEmployeeId = new System.Windows.Forms.TextBox();
            label17 = new System.Windows.Forms.Label();
            rtbNote = new System.Windows.Forms.RichTextBox();
            label16 = new System.Windows.Forms.Label();
            tbxExtension = new System.Windows.Forms.TextBox();
            label15 = new System.Windows.Forms.Label();
            tbxPhone = new System.Windows.Forms.TextBox();
            btnChoose = new System.Windows.Forms.Button();
            label = new System.Windows.Forms.Label();
            pictureBox = new System.Windows.Forms.PictureBox();
            label14 = new System.Windows.Forms.Label();
            cbxCountry = new System.Windows.Forms.ComboBox();
            label13 = new System.Windows.Forms.Label();
            tbxPostalCode = new System.Windows.Forms.TextBox();
            label12 = new System.Windows.Forms.Label();
            cbxRegion = new System.Windows.Forms.ComboBox();
            label11 = new System.Windows.Forms.Label();
            cbxCity = new System.Windows.Forms.ComboBox();
            label10 = new System.Windows.Forms.Label();
            tbxAdress = new System.Windows.Forms.TextBox();
            label9 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            dtpHireDate = new System.Windows.Forms.DateTimePicker();
            label7 = new System.Windows.Forms.Label();
            dtpBirthDate = new System.Windows.Forms.DateTimePicker();
            tbxTitleOfCourtesy = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            tbxTitle = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            tbxFirstName = new System.Windows.Forms.TextBox();
            btnChooseClear = new System.Windows.Forms.Button();
            btnRemove = new System.Windows.Forms.Button();
            btnAddOrUpdate = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            tbxLastName = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)gdwEmployee).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(987, 494);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(45, 15);
            label4.TabIndex = 25;
            label4.Text = "Search:";
            // 
            // tbxSearch
            // 
            tbxSearch.Location = new System.Drawing.Point(1038, 491);
            tbxSearch.Name = "tbxSearch";
            tbxSearch.Size = new System.Drawing.Size(132, 23);
            tbxSearch.TabIndex = 27;
            tbxSearch.TextChanged += tbxSearch_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(673, 43);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(0, 15);
            label3.TabIndex = 26;
            // 
            // gdwEmployee
            // 
            gdwEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gdwEmployee.Location = new System.Drawing.Point(17, 527);
            gdwEmployee.Name = "gdwEmployee";
            gdwEmployee.RowTemplate.Height = 25;
            gdwEmployee.Size = new System.Drawing.Size(1153, 461);
            gdwEmployee.TabIndex = 24;
            gdwEmployee.CellClick += gdwEmployee_CellClick;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tbxEmployeeId);
            groupBox1.Controls.Add(label17);
            groupBox1.Controls.Add(rtbNote);
            groupBox1.Controls.Add(label16);
            groupBox1.Controls.Add(tbxExtension);
            groupBox1.Controls.Add(label15);
            groupBox1.Controls.Add(tbxPhone);
            groupBox1.Controls.Add(btnChoose);
            groupBox1.Controls.Add(label);
            groupBox1.Controls.Add(pictureBox);
            groupBox1.Controls.Add(label14);
            groupBox1.Controls.Add(cbxCountry);
            groupBox1.Controls.Add(label13);
            groupBox1.Controls.Add(tbxPostalCode);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(cbxRegion);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(cbxCity);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(tbxAdress);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(dtpHireDate);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(dtpBirthDate);
            groupBox1.Controls.Add(tbxTitleOfCourtesy);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(tbxTitle);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(tbxFirstName);
            groupBox1.Controls.Add(btnChooseClear);
            groupBox1.Controls.Add(btnRemove);
            groupBox1.Controls.Add(btnAddOrUpdate);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(tbxLastName);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new System.Drawing.Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(1158, 473);
            groupBox1.TabIndex = 23;
            groupBox1.TabStop = false;
            groupBox1.Text = "Employee Info";
            // 
            // tbxEmployeeId
            // 
            tbxEmployeeId.Location = new System.Drawing.Point(5, 46);
            tbxEmployeeId.Name = "tbxEmployeeId";
            tbxEmployeeId.ReadOnly = true;
            tbxEmployeeId.Size = new System.Drawing.Size(364, 23);
            tbxEmployeeId.TabIndex = 47;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new System.Drawing.Point(5, 28);
            label17.Name = "label17";
            label17.Size = new System.Drawing.Size(73, 15);
            label17.TabIndex = 46;
            label17.Text = "Employee ID";
            // 
            // rtbNote
            // 
            rtbNote.Location = new System.Drawing.Point(395, 289);
            rtbNote.Name = "rtbNote";
            rtbNote.Size = new System.Drawing.Size(363, 178);
            rtbNote.TabIndex = 45;
            rtbNote.Text = "";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new System.Drawing.Point(394, 267);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(38, 15);
            label16.TabIndex = 44;
            label16.Text = "Notes";
            // 
            // tbxExtension
            // 
            tbxExtension.Location = new System.Drawing.Point(6, 444);
            tbxExtension.Name = "tbxExtension";
            tbxExtension.Size = new System.Drawing.Size(364, 23);
            tbxExtension.TabIndex = 43;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new System.Drawing.Point(5, 426);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(58, 15);
            label15.TabIndex = 42;
            label15.Text = "Extension";
            // 
            // tbxPhone
            // 
            tbxPhone.Location = new System.Drawing.Point(394, 237);
            tbxPhone.Name = "tbxPhone";
            tbxPhone.Size = new System.Drawing.Size(364, 23);
            tbxPhone.TabIndex = 41;
            // 
            // btnChoose
            // 
            btnChoose.Location = new System.Drawing.Point(1059, 221);
            btnChoose.Name = "btnChoose";
            btnChoose.Size = new System.Drawing.Size(93, 23);
            btnChoose.TabIndex = 2;
            btnChoose.Text = "Choose Folder";
            btnChoose.UseVisualStyleBackColor = true;
            btnChoose.Click += btnChoose_Click;
            // 
            // label
            // 
            label.AutoSize = true;
            label.Location = new System.Drawing.Point(903, 19);
            label.Name = "label";
            label.Size = new System.Drawing.Size(39, 15);
            label.TabIndex = 5;
            label.Text = "Photo";
            // 
            // pictureBox
            // 
            pictureBox.Image = FormUI.Properties.Resources._1967356;
            pictureBox.Location = new System.Drawing.Point(948, 19);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new System.Drawing.Size(204, 186);
            pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox.TabIndex = 2;
            pictureBox.TabStop = false;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new System.Drawing.Point(393, 219);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(41, 15);
            label14.TabIndex = 40;
            label14.Text = "Phone";
            // 
            // cbxCountry
            // 
            cbxCountry.FormattingEnabled = true;
            cbxCountry.Items.AddRange(new object[] { "USA" });
            cbxCountry.Location = new System.Drawing.Point(393, 186);
            cbxCountry.Name = "cbxCountry";
            cbxCountry.Size = new System.Drawing.Size(365, 23);
            cbxCountry.TabIndex = 39;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new System.Drawing.Point(393, 168);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(50, 15);
            label13.TabIndex = 38;
            label13.Text = "Country";
            // 
            // tbxPostalCode
            // 
            tbxPostalCode.Location = new System.Drawing.Point(393, 139);
            tbxPostalCode.Name = "tbxPostalCode";
            tbxPostalCode.Size = new System.Drawing.Size(364, 23);
            tbxPostalCode.TabIndex = 37;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(393, 121);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(70, 15);
            label12.TabIndex = 36;
            label12.Text = "Postal Code";
            // 
            // cbxRegion
            // 
            cbxRegion.FormattingEnabled = true;
            cbxRegion.Location = new System.Drawing.Point(393, 46);
            cbxRegion.Name = "cbxRegion";
            cbxRegion.Size = new System.Drawing.Size(364, 23);
            cbxRegion.TabIndex = 35;
            cbxRegion.SelectedIndexChanged += cbxRegion_SelectedIndexChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(392, 28);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(44, 15);
            label11.TabIndex = 34;
            label11.Text = "Region";
            // 
            // cbxCity
            // 
            cbxCity.FormattingEnabled = true;
            cbxCity.Location = new System.Drawing.Point(392, 94);
            cbxCity.Name = "cbxCity";
            cbxCity.Size = new System.Drawing.Size(365, 23);
            cbxCity.TabIndex = 33;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(392, 76);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(28, 15);
            label10.TabIndex = 32;
            label10.Text = "City";
            // 
            // tbxAdress
            // 
            tbxAdress.Location = new System.Drawing.Point(5, 392);
            tbxAdress.Name = "tbxAdress";
            tbxAdress.Size = new System.Drawing.Size(364, 23);
            tbxAdress.TabIndex = 31;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(5, 374);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(49, 15);
            label9.TabIndex = 30;
            label9.Text = "Address";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(5, 321);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(53, 15);
            label8.TabIndex = 29;
            label8.Text = "HireDate";
            // 
            // dtpHireDate
            // 
            dtpHireDate.Location = new System.Drawing.Point(6, 339);
            dtpHireDate.Name = "dtpHireDate";
            dtpHireDate.Size = new System.Drawing.Size(364, 23);
            dtpHireDate.TabIndex = 28;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(5, 271);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(56, 15);
            label7.TabIndex = 27;
            label7.Text = "BirthDate";
            // 
            // dtpBirthDate
            // 
            dtpBirthDate.Location = new System.Drawing.Point(5, 289);
            dtpBirthDate.Name = "dtpBirthDate";
            dtpBirthDate.Size = new System.Drawing.Size(364, 23);
            dtpBirthDate.TabIndex = 26;
            // 
            // tbxTitleOfCourtesy
            // 
            tbxTitleOfCourtesy.Location = new System.Drawing.Point(5, 239);
            tbxTitleOfCourtesy.Name = "tbxTitleOfCourtesy";
            tbxTitleOfCourtesy.Size = new System.Drawing.Size(364, 23);
            tbxTitleOfCourtesy.TabIndex = 25;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(5, 221);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(89, 15);
            label6.TabIndex = 24;
            label6.Text = "TitleOfCourtesy";
            // 
            // tbxTitle
            // 
            tbxTitle.Location = new System.Drawing.Point(5, 189);
            tbxTitle.Name = "tbxTitle";
            tbxTitle.Size = new System.Drawing.Size(364, 23);
            tbxTitle.TabIndex = 23;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(5, 171);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(29, 15);
            label5.TabIndex = 22;
            label5.Text = "Title";
            // 
            // tbxFirstName
            // 
            tbxFirstName.Location = new System.Drawing.Point(5, 143);
            tbxFirstName.Name = "tbxFirstName";
            tbxFirstName.Size = new System.Drawing.Size(364, 23);
            tbxFirstName.TabIndex = 21;
            // 
            // btnChooseClear
            // 
            btnChooseClear.BackColor = System.Drawing.Color.DarkOrange;
            btnChooseClear.Location = new System.Drawing.Point(826, 267);
            btnChooseClear.Name = "btnChooseClear";
            btnChooseClear.Size = new System.Drawing.Size(91, 33);
            btnChooseClear.TabIndex = 20;
            btnChooseClear.Text = "Choose Clear";
            btnChooseClear.UseVisualStyleBackColor = false;
            btnChooseClear.Click += btnChooseClear_Click;
            // 
            // btnRemove
            // 
            btnRemove.BackColor = System.Drawing.Color.Red;
            btnRemove.Location = new System.Drawing.Point(1077, 426);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new System.Drawing.Size(75, 33);
            btnRemove.TabIndex = 19;
            btnRemove.Text = "Remove";
            btnRemove.UseVisualStyleBackColor = false;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnAddOrUpdate
            // 
            btnAddOrUpdate.BackColor = System.Drawing.Color.Chartreuse;
            btnAddOrUpdate.Location = new System.Drawing.Point(988, 426);
            btnAddOrUpdate.Name = "btnAddOrUpdate";
            btnAddOrUpdate.Size = new System.Drawing.Size(83, 33);
            btnAddOrUpdate.TabIndex = 18;
            btnAddOrUpdate.Text = "Add/Update";
            btnAddOrUpdate.UseVisualStyleBackColor = false;
            btnAddOrUpdate.Click += btnAddOrUpdate_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(5, 125);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(64, 15);
            label2.TabIndex = 4;
            label2.Text = "First Name";
            // 
            // tbxLastName
            // 
            tbxLastName.Location = new System.Drawing.Point(5, 95);
            tbxLastName.Name = "tbxLastName";
            tbxLastName.Size = new System.Drawing.Size(364, 23);
            tbxLastName.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(5, 77);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(63, 15);
            label1.TabIndex = 2;
            label1.Text = "Last Name";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // FormEmployess
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1217, 1061);
            Controls.Add(label4);
            Controls.Add(tbxSearch);
            Controls.Add(label3);
            Controls.Add(gdwEmployee);
            Controls.Add(groupBox1);
            Name = "FormEmployess";
            Text = "FormEmployess";
            Load += FormEmployess_Load;
            ((System.ComponentModel.ISupportInitialize)gdwEmployee).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView gdwEmployee;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox rtbNote;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tbxExtension;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbxPhone;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbxCountry;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbxPostalCode;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbxRegion;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbxCity;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbxAdress;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpHireDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpBirthDate;
        private System.Windows.Forms.TextBox tbxTitleOfCourtesy;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxTitle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxFirstName;
        private System.Windows.Forms.Button btnChooseClear;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAddOrUpdate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxLastName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox tbxEmployeeId;
        private System.Windows.Forms.Label label17;
    }
}