namespace TestProject
{
    partial class FormCategories
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
            groupBox1 = new System.Windows.Forms.GroupBox();
            tbxCategoryID = new System.Windows.Forms.TextBox();
            btnChooseClear = new System.Windows.Forms.Button();
            label5 = new System.Windows.Forms.Label();
            tbxDescripton = new System.Windows.Forms.TextBox();
            btnRemove = new System.Windows.Forms.Button();
            btnChoose = new System.Windows.Forms.Button();
            buttonAddOrUpdate = new System.Windows.Forms.Button();
            pictureBox = new System.Windows.Forms.PictureBox();
            label = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            tbxCategoryName = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            gdwCategories = new System.Windows.Forms.DataGridView();
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            tbxSearch = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            lblPageNo = new System.Windows.Forms.Label();
            btnPrevious = new System.Windows.Forms.Button();
            btnNextPage = new System.Windows.Forms.Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gdwCategories).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tbxCategoryID);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(tbxDescripton);
            groupBox1.Controls.Add(btnRemove);
            groupBox1.Controls.Add(btnChoose);
            groupBox1.Controls.Add(buttonAddOrUpdate);
            groupBox1.Controls.Add(pictureBox);
            groupBox1.Controls.Add(label);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(tbxCategoryName);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new System.Drawing.Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(526, 251);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Categori Info";
            // 
            // tbxCategoryID
            // 
            tbxCategoryID.Location = new System.Drawing.Point(6, 40);
            tbxCategoryID.Name = "tbxCategoryID";
            tbxCategoryID.ReadOnly = true;
            tbxCategoryID.Size = new System.Drawing.Size(235, 23);
            tbxCategoryID.TabIndex = 23;
            // 
            // btnChooseClear
            // 
            btnChooseClear.BackColor = System.Drawing.Color.DarkOrange;
            btnChooseClear.Location = new System.Drawing.Point(12, 269);
            btnChooseClear.Name = "btnChooseClear";
            btnChooseClear.Size = new System.Drawing.Size(91, 28);
            btnChooseClear.TabIndex = 20;
            btnChooseClear.Text = "Choose Clear";
            btnChooseClear.UseVisualStyleBackColor = false;
            btnChooseClear.Click += btnChooseClear_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(6, 22);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(69, 15);
            label5.TabIndex = 22;
            label5.Text = "Category ID";
            // 
            // tbxDescripton
            // 
            tbxDescripton.Location = new System.Drawing.Point(6, 148);
            tbxDescripton.Name = "tbxDescripton";
            tbxDescripton.Size = new System.Drawing.Size(235, 23);
            tbxDescripton.TabIndex = 21;
            // 
            // btnRemove
            // 
            btnRemove.BackColor = System.Drawing.Color.Red;
            btnRemove.Location = new System.Drawing.Point(433, 206);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new System.Drawing.Size(75, 35);
            btnRemove.TabIndex = 19;
            btnRemove.Text = "Remove";
            btnRemove.UseVisualStyleBackColor = false;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnChoose
            // 
            btnChoose.Location = new System.Drawing.Point(415, 158);
            btnChoose.Name = "btnChoose";
            btnChoose.Size = new System.Drawing.Size(93, 23);
            btnChoose.TabIndex = 2;
            btnChoose.Text = "Choose Folder";
            btnChoose.UseVisualStyleBackColor = true;
            btnChoose.Click += btnChoose_Click;
            // 
            // buttonAddOrUpdate
            // 
            buttonAddOrUpdate.BackColor = System.Drawing.Color.Chartreuse;
            buttonAddOrUpdate.Location = new System.Drawing.Point(343, 206);
            buttonAddOrUpdate.Name = "buttonAddOrUpdate";
            buttonAddOrUpdate.Size = new System.Drawing.Size(84, 35);
            buttonAddOrUpdate.TabIndex = 18;
            buttonAddOrUpdate.Text = "Add/Update";
            buttonAddOrUpdate.UseVisualStyleBackColor = false;
            buttonAddOrUpdate.Click += buttonAddOrUpdate_Click;
            // 
            // pictureBox
            // 
            pictureBox.Image = FormUI.Properties.Resources._1967356;
            pictureBox.Location = new System.Drawing.Point(343, 22);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new System.Drawing.Size(165, 121);
            pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox.TabIndex = 2;
            pictureBox.TabStop = false;
            // 
            // label
            // 
            label.AutoSize = true;
            label.Location = new System.Drawing.Point(273, 31);
            label.Name = "label";
            label.Size = new System.Drawing.Size(44, 15);
            label.TabIndex = 5;
            label.Text = "Picture";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(6, 130);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(64, 15);
            label2.TabIndex = 4;
            label2.Text = "Descripton";
            // 
            // tbxCategoryName
            // 
            tbxCategoryName.Location = new System.Drawing.Point(6, 93);
            tbxCategoryName.Name = "tbxCategoryName";
            tbxCategoryName.Size = new System.Drawing.Size(235, 23);
            tbxCategoryName.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(6, 75);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(90, 15);
            label1.TabIndex = 2;
            label1.Text = "Category Name";
            // 
            // gdwCategories
            // 
            gdwCategories.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            gdwCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gdwCategories.Location = new System.Drawing.Point(12, 303);
            gdwCategories.Name = "gdwCategories";
            gdwCategories.RowTemplate.Height = 25;
            gdwCategories.Size = new System.Drawing.Size(526, 216);
            gdwCategories.TabIndex = 1;
            gdwCategories.CellClick += gdwCategories_CellClick;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // tbxSearch
            // 
            tbxSearch.Location = new System.Drawing.Point(406, 273);
            tbxSearch.Name = "tbxSearch";
            tbxSearch.Size = new System.Drawing.Size(132, 23);
            tbxSearch.TabIndex = 22;
            tbxSearch.TextChanged += tbxSearch_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(673, 43);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(0, 15);
            label3.TabIndex = 21;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(355, 276);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(45, 15);
            label4.TabIndex = 21;
            label4.Text = "Search:";
            // 
            // lblPageNo
            // 
            lblPageNo.AutoSize = true;
            lblPageNo.Location = new System.Drawing.Point(241, 530);
            lblPageNo.Name = "lblPageNo";
            lblPageNo.Size = new System.Drawing.Size(44, 15);
            lblPageNo.TabIndex = 26;
            lblPageNo.Text = "Label 1";
            // 
            // btnPrevious
            // 
            btnPrevious.Location = new System.Drawing.Point(124, 525);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new System.Drawing.Size(75, 23);
            btnPrevious.TabIndex = 25;
            btnPrevious.Text = "<";
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += btnPrevious_Click;
            // 
            // btnNextPage
            // 
            btnNextPage.Location = new System.Drawing.Point(325, 525);
            btnNextPage.Name = "btnNextPage";
            btnNextPage.Size = new System.Drawing.Size(75, 23);
            btnNextPage.TabIndex = 24;
            btnNextPage.Text = ">";
            btnNextPage.UseVisualStyleBackColor = true;
            btnNextPage.Click += btnNextPage_Click;
            // 
            // FormCategories
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(555, 557);
            Controls.Add(lblPageNo);
            Controls.Add(btnChooseClear);
            Controls.Add(btnPrevious);
            Controls.Add(btnNextPage);
            Controls.Add(label4);
            Controls.Add(tbxSearch);
            Controls.Add(label3);
            Controls.Add(gdwCategories);
            Controls.Add(groupBox1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormCategories";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "FormCategories";
            Load += FormCategories_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)gdwCategories).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView gdwCategories;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxCategoryName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnChooseClear;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button buttonAddOrUpdate;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox tbxSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxDescripton;
        private System.Windows.Forms.TextBox tbxCategoryID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblPageNo;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNextPage;
    }
}