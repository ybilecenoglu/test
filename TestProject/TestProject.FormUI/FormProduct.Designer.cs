namespace TestProject.Product
{
    partial class FormProduct
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
            this.buttonRemove = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.rdbNotForSeal = new System.Windows.Forms.RadioButton();
            this.rdbOnSale = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.tbxReorderLevel = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbxUnitsOnOrder = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbxSuppliers = new System.Windows.Forms.ComboBox();
            this.cbxCategories = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.tbxQuantityPerUnit = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxUnitInStock = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxUnitPrice = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxProductName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gdwProduct = new System.Windows.Forms.DataGridView();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbxShortByCategory = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdwProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(243, -43);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(75, 23);
            this.buttonRemove.TabIndex = 5;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonUpdate);
            this.groupBox1.Controls.Add(this.btnRemove);
            this.groupBox1.Controls.Add(this.rdbNotForSeal);
            this.groupBox1.Controls.Add(this.rdbOnSale);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.tbxReorderLevel);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tbxUnitsOnOrder);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cbxSuppliers);
            this.groupBox1.Controls.Add(this.cbxCategories);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.buttonAdd);
            this.groupBox1.Controls.Add(this.tbxQuantityPerUnit);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbxUnitInStock);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbxUnitPrice);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbxProductName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(249, 561);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Product Info";
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.BackColor = System.Drawing.Color.DarkOrange;
            this.buttonUpdate.Location = new System.Drawing.Point(87, 519);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdate.TabIndex = 17;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = false;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.Red;
            this.btnRemove.Location = new System.Drawing.Point(168, 519);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 16;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // rdbNotForSeal
            // 
            this.rdbNotForSeal.AutoSize = true;
            this.rdbNotForSeal.Location = new System.Drawing.Point(6, 485);
            this.rdbNotForSeal.Name = "rdbNotForSeal";
            this.rdbNotForSeal.Size = new System.Drawing.Size(89, 19);
            this.rdbNotForSeal.TabIndex = 7;
            this.rdbNotForSeal.TabStop = true;
            this.rdbNotForSeal.Text = "Not For Seal";
            this.rdbNotForSeal.UseVisualStyleBackColor = true;
            // 
            // rdbOnSale
            // 
            this.rdbOnSale.AutoSize = true;
            this.rdbOnSale.Location = new System.Drawing.Point(6, 460);
            this.rdbOnSale.Name = "rdbOnSale";
            this.rdbOnSale.Size = new System.Drawing.Size(65, 19);
            this.rdbOnSale.TabIndex = 6;
            this.rdbOnSale.TabStop = true;
            this.rdbOnSale.Text = "On Sale";
            this.rdbOnSale.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 442);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 15);
            this.label9.TabIndex = 15;
            this.label9.Text = "Discontinued";
            // 
            // tbxReorderLevel
            // 
            this.tbxReorderLevel.Location = new System.Drawing.Point(6, 405);
            this.tbxReorderLevel.Name = "tbxReorderLevel";
            this.tbxReorderLevel.Size = new System.Drawing.Size(237, 23);
            this.tbxReorderLevel.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 387);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 15);
            this.label8.TabIndex = 13;
            this.label8.Text = "Reorder Level";
            // 
            // tbxUnitsOnOrder
            // 
            this.tbxUnitsOnOrder.Location = new System.Drawing.Point(6, 348);
            this.tbxUnitsOnOrder.Name = "tbxUnitsOnOrder";
            this.tbxUnitsOnOrder.Size = new System.Drawing.Size(237, 23);
            this.tbxUnitsOnOrder.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 330);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 15);
            this.label7.TabIndex = 11;
            this.label7.Text = "Units On Order";
            // 
            // cbxSuppliers
            // 
            this.cbxSuppliers.FormattingEnabled = true;
            this.cbxSuppliers.Location = new System.Drawing.Point(6, 134);
            this.cbxSuppliers.Name = "cbxSuppliers";
            this.cbxSuppliers.Size = new System.Drawing.Size(237, 23);
            this.cbxSuppliers.TabIndex = 10;
            // 
            // cbxCategories
            // 
            this.cbxCategories.FormattingEnabled = true;
            this.cbxCategories.Location = new System.Drawing.Point(6, 85);
            this.cbxCategories.Name = "cbxCategories";
            this.cbxCategories.Size = new System.Drawing.Size(237, 23);
            this.cbxCategories.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "Categories";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Suppliers";
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.Color.Chartreuse;
            this.buttonAdd.Location = new System.Drawing.Point(6, 519);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 6;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // tbxQuantityPerUnit
            // 
            this.tbxQuantityPerUnit.Location = new System.Drawing.Point(6, 184);
            this.tbxQuantityPerUnit.Name = "tbxQuantityPerUnit";
            this.tbxQuantityPerUnit.Size = new System.Drawing.Size(237, 23);
            this.tbxQuantityPerUnit.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Quantity Per Unit";
            // 
            // tbxUnitInStock
            // 
            this.tbxUnitInStock.Location = new System.Drawing.Point(6, 291);
            this.tbxUnitInStock.Name = "tbxUnitInStock";
            this.tbxUnitInStock.Size = new System.Drawing.Size(237, 23);
            this.tbxUnitInStock.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 273);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Unit In Stock";
            // 
            // tbxUnitPrice
            // 
            this.tbxUnitPrice.Location = new System.Drawing.Point(6, 237);
            this.tbxUnitPrice.Name = "tbxUnitPrice";
            this.tbxUnitPrice.Size = new System.Drawing.Size(237, 23);
            this.tbxUnitPrice.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "UnitPrice";
            // 
            // tbxProductName
            // 
            this.tbxProductName.Location = new System.Drawing.Point(6, 37);
            this.tbxProductName.Name = "tbxProductName";
            this.tbxProductName.Size = new System.Drawing.Size(237, 23);
            this.tbxProductName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Product Name";
            // 
            // gdwProduct
            // 
            this.gdwProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdwProduct.Location = new System.Drawing.Point(289, 62);
            this.gdwProduct.MultiSelect = false;
            this.gdwProduct.Name = "gdwProduct";
            this.gdwProduct.RowTemplate.Height = 25;
            this.gdwProduct.Size = new System.Drawing.Size(777, 511);
            this.gdwProduct.TabIndex = 3;
            this.gdwProduct.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gdwProduct_CellClick);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(944, 33);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(122, 23);
            this.textBoxSearch.TabIndex = 18;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(893, 36);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 15);
            this.label10.TabIndex = 17;
            this.label10.Text = "Search:";
            // 
            // cbxShortByCategory
            // 
            this.cbxShortByCategory.FormattingEnabled = true;
            this.cbxShortByCategory.Location = new System.Drawing.Point(730, 33);
            this.cbxShortByCategory.Name = "cbxShortByCategory";
            this.cbxShortByCategory.Size = new System.Drawing.Size(131, 23);
            this.cbxShortByCategory.TabIndex = 19;
            this.cbxShortByCategory.SelectedIndexChanged += new System.EventHandler(this.cbxShortByCategory_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(616, 36);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 15);
            this.label11.TabIndex = 20;
            this.label11.Text = "Sort By Category:";
            // 
            // FormProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 678);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cbxShortByCategory);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gdwProduct);
            this.Name = "FormProduct";
            this.Text = "FormProduct";
            this.Load += new System.EventHandler(this.FormProduct_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdwProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbxReorderLevel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbxUnitsOnOrder;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbxSuppliers;
        private System.Windows.Forms.ComboBox cbxCategories;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.TextBox tbxQuantityPerUnit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxUnitInStock;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxUnitPrice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxProductName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gdwProduct;
        private System.Windows.Forms.RadioButton rdbNotForSeal;
        private System.Windows.Forms.RadioButton rdbOnSale;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.ComboBox cbxShortByCategory;
        private System.Windows.Forms.Label label11;
    }
}