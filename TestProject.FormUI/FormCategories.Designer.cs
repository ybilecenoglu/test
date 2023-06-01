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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbxCategoryID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxDescripton = new System.Windows.Forms.TextBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnChoose = new System.Windows.Forms.Button();
            this.buttonAddOrUpdate = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxCategoryName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnChooseClear = new System.Windows.Forms.Button();
            this.gdwCategories = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tbxSearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdwCategories)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbxCategoryID);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbxDescripton);
            this.groupBox1.Controls.Add(this.btnRemove);
            this.groupBox1.Controls.Add(this.btnChoose);
            this.groupBox1.Controls.Add(this.buttonAddOrUpdate);
            this.groupBox1.Controls.Add(this.pictureBox);
            this.groupBox1.Controls.Add(this.label);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbxCategoryName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 441);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Categori Info";
            // 
            // tbxCategoryID
            // 
            this.tbxCategoryID.Location = new System.Drawing.Point(6, 40);
            this.tbxCategoryID.Name = "tbxCategoryID";
            this.tbxCategoryID.ReadOnly = true;
            this.tbxCategoryID.Size = new System.Drawing.Size(235, 23);
            this.tbxCategoryID.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 15);
            this.label5.TabIndex = 22;
            this.label5.Text = "Category ID";
            // 
            // tbxDescripton
            // 
            this.tbxDescripton.Location = new System.Drawing.Point(6, 148);
            this.tbxDescripton.Name = "tbxDescripton";
            this.tbxDescripton.Size = new System.Drawing.Size(235, 23);
            this.tbxDescripton.TabIndex = 21;
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.Red;
            this.btnRemove.Location = new System.Drawing.Point(166, 376);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 35);
            this.btnRemove.TabIndex = 19;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnChoose
            // 
            this.btnChoose.Location = new System.Drawing.Point(148, 338);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(93, 23);
            this.btnChoose.TabIndex = 2;
            this.btnChoose.Text = "Choose Folder";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // buttonAddOrUpdate
            // 
            this.buttonAddOrUpdate.BackColor = System.Drawing.Color.Chartreuse;
            this.buttonAddOrUpdate.Location = new System.Drawing.Point(76, 376);
            this.buttonAddOrUpdate.Name = "buttonAddOrUpdate";
            this.buttonAddOrUpdate.Size = new System.Drawing.Size(84, 35);
            this.buttonAddOrUpdate.TabIndex = 18;
            this.buttonAddOrUpdate.Text = "Add/Update";
            this.buttonAddOrUpdate.UseVisualStyleBackColor = false;
            this.buttonAddOrUpdate.Click += new System.EventHandler(this.buttonAddOrUpdate_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Image = global::TestProject.FormUI.Properties.Resources._1967356;
            this.pictureBox.Location = new System.Drawing.Point(76, 202);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(165, 121);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 2;
            this.pictureBox.TabStop = false;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(6, 211);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(44, 15);
            this.label.TabIndex = 5;
            this.label.Text = "Picture";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Descripton";
            // 
            // tbxCategoryName
            // 
            this.tbxCategoryName.Location = new System.Drawing.Point(6, 93);
            this.tbxCategoryName.Name = "tbxCategoryName";
            this.tbxCategoryName.Size = new System.Drawing.Size(235, 23);
            this.tbxCategoryName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Category Name";
            // 
            // btnChooseClear
            // 
            this.btnChooseClear.BackColor = System.Drawing.Color.DarkOrange;
            this.btnChooseClear.Location = new System.Drawing.Point(288, 28);
            this.btnChooseClear.Name = "btnChooseClear";
            this.btnChooseClear.Size = new System.Drawing.Size(91, 35);
            this.btnChooseClear.TabIndex = 20;
            this.btnChooseClear.Text = "Choose Clear";
            this.btnChooseClear.UseVisualStyleBackColor = false;
            this.btnChooseClear.Click += new System.EventHandler(this.btnChooseClear_Click);
            // 
            // gdwCategories
            // 
            this.gdwCategories.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gdwCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdwCategories.Location = new System.Drawing.Point(288, 69);
            this.gdwCategories.Name = "gdwCategories";
            this.gdwCategories.RowTemplate.Height = 25;
            this.gdwCategories.Size = new System.Drawing.Size(623, 416);
            this.gdwCategories.TabIndex = 1;
            this.gdwCategories.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gdwCategories_CellClick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tbxSearch
            // 
            this.tbxSearch.Location = new System.Drawing.Point(779, 40);
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.Size = new System.Drawing.Size(132, 23);
            this.tbxSearch.TabIndex = 22;
            this.tbxSearch.TextChanged += new System.EventHandler(this.tbxSearch_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(673, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 15);
            this.label3.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(728, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 15);
            this.label4.TabIndex = 21;
            this.label4.Text = "Search:";
            // 
            // FormCategories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 497);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnChooseClear);
            this.Controls.Add(this.tbxSearch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gdwCategories);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormCategories";
            this.Text = "FormCategories";
            this.Load += new System.EventHandler(this.FormCategories_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdwCategories)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}