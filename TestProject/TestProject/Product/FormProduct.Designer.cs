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
            buttonRemove = new System.Windows.Forms.Button();
            groupBox1 = new System.Windows.Forms.GroupBox();
            rdbNotForSeal = new System.Windows.Forms.RadioButton();
            rdbOnSale = new System.Windows.Forms.RadioButton();
            label9 = new System.Windows.Forms.Label();
            tbxReorderLevel = new System.Windows.Forms.TextBox();
            label8 = new System.Windows.Forms.Label();
            tbxUnitsOnOrder = new System.Windows.Forms.TextBox();
            label7 = new System.Windows.Forms.Label();
            cbxSuppliers = new System.Windows.Forms.ComboBox();
            cbxCategories = new System.Windows.Forms.ComboBox();
            label6 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            buttonAdd = new System.Windows.Forms.Button();
            tbxQuantityPerUnit = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            tbxUnitInStock = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            tbxUnitPrice = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            tbxProductName = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            gdwProduct = new System.Windows.Forms.DataGridView();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gdwProduct).BeginInit();
            SuspendLayout();
            // 
            // buttonRemove
            // 
            buttonRemove.Location = new System.Drawing.Point(243, -43);
            buttonRemove.Name = "buttonRemove";
            buttonRemove.Size = new System.Drawing.Size(75, 23);
            buttonRemove.TabIndex = 5;
            buttonRemove.Text = "Remove";
            buttonRemove.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rdbNotForSeal);
            groupBox1.Controls.Add(rdbOnSale);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(tbxReorderLevel);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(tbxUnitsOnOrder);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(cbxSuppliers);
            groupBox1.Controls.Add(cbxCategories);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(buttonAdd);
            groupBox1.Controls.Add(tbxQuantityPerUnit);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(tbxUnitInStock);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(tbxUnitPrice);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(tbxProductName);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new System.Drawing.Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(249, 532);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Product Info";
            // 
            // rdbNotForSeal
            // 
            rdbNotForSeal.AutoSize = true;
            rdbNotForSeal.Location = new System.Drawing.Point(6, 485);
            rdbNotForSeal.Name = "rdbNotForSeal";
            rdbNotForSeal.Size = new System.Drawing.Size(89, 19);
            rdbNotForSeal.TabIndex = 7;
            rdbNotForSeal.TabStop = true;
            rdbNotForSeal.Text = "Not For Seal";
            rdbNotForSeal.UseVisualStyleBackColor = true;
            // 
            // rdbOnSale
            // 
            rdbOnSale.AutoSize = true;
            rdbOnSale.Location = new System.Drawing.Point(6, 460);
            rdbOnSale.Name = "rdbOnSale";
            rdbOnSale.Size = new System.Drawing.Size(65, 19);
            rdbOnSale.TabIndex = 6;
            rdbOnSale.TabStop = true;
            rdbOnSale.Text = "On Sale";
            rdbOnSale.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(6, 442);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(77, 15);
            label9.TabIndex = 15;
            label9.Text = "Discontinued";
            // 
            // tbxReorderLevel
            // 
            tbxReorderLevel.Location = new System.Drawing.Point(6, 405);
            tbxReorderLevel.Name = "tbxReorderLevel";
            tbxReorderLevel.Size = new System.Drawing.Size(218, 23);
            tbxReorderLevel.TabIndex = 14;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(6, 387);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(78, 15);
            label8.TabIndex = 13;
            label8.Text = "Reorder Level";
            // 
            // tbxUnitsOnOrder
            // 
            tbxUnitsOnOrder.Location = new System.Drawing.Point(6, 348);
            tbxUnitsOnOrder.Name = "tbxUnitsOnOrder";
            tbxUnitsOnOrder.Size = new System.Drawing.Size(218, 23);
            tbxUnitsOnOrder.TabIndex = 12;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(6, 330);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(86, 15);
            label7.TabIndex = 11;
            label7.Text = "Units On Order";
            // 
            // cbxSuppliers
            // 
            cbxSuppliers.FormattingEnabled = true;
            cbxSuppliers.Location = new System.Drawing.Point(6, 134);
            cbxSuppliers.Name = "cbxSuppliers";
            cbxSuppliers.Size = new System.Drawing.Size(218, 23);
            cbxSuppliers.TabIndex = 10;
            // 
            // cbxCategories
            // 
            cbxCategories.FormattingEnabled = true;
            cbxCategories.Location = new System.Drawing.Point(6, 85);
            cbxCategories.Name = "cbxCategories";
            cbxCategories.Size = new System.Drawing.Size(218, 23);
            cbxCategories.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(6, 67);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(63, 15);
            label6.TabIndex = 8;
            label6.Text = "Categories";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(6, 116);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(55, 15);
            label5.TabIndex = 7;
            label5.Text = "Suppliers";
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new System.Drawing.Point(149, 503);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new System.Drawing.Size(75, 23);
            buttonAdd.TabIndex = 6;
            buttonAdd.Text = "Add";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // tbxQuantityPerUnit
            // 
            tbxQuantityPerUnit.Location = new System.Drawing.Point(6, 184);
            tbxQuantityPerUnit.Name = "tbxQuantityPerUnit";
            tbxQuantityPerUnit.Size = new System.Drawing.Size(218, 23);
            tbxQuantityPerUnit.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(6, 166);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(98, 15);
            label4.TabIndex = 2;
            label4.Text = "Quantity Per Unit";
            // 
            // tbxUnitInStock
            // 
            tbxUnitInStock.Location = new System.Drawing.Point(6, 291);
            tbxUnitInStock.Name = "tbxUnitInStock";
            tbxUnitInStock.Size = new System.Drawing.Size(218, 23);
            tbxUnitInStock.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(6, 273);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(74, 15);
            label3.TabIndex = 4;
            label3.Text = "Unit In Stock";
            // 
            // tbxUnitPrice
            // 
            tbxUnitPrice.Location = new System.Drawing.Point(6, 237);
            tbxUnitPrice.Name = "tbxUnitPrice";
            tbxUnitPrice.Size = new System.Drawing.Size(218, 23);
            tbxUnitPrice.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(6, 219);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(55, 15);
            label2.TabIndex = 2;
            label2.Text = "UnitPrice";
            // 
            // tbxProductName
            // 
            tbxProductName.Location = new System.Drawing.Point(6, 37);
            tbxProductName.Name = "tbxProductName";
            tbxProductName.Size = new System.Drawing.Size(218, 23);
            tbxProductName.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(6, 19);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(84, 15);
            label1.TabIndex = 0;
            label1.Text = "Product Name";
            // 
            // gdwProduct
            // 
            gdwProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gdwProduct.Location = new System.Drawing.Point(267, 12);
            gdwProduct.Name = "gdwProduct";
            gdwProduct.RowTemplate.Height = 25;
            gdwProduct.Size = new System.Drawing.Size(777, 532);
            gdwProduct.TabIndex = 3;
            // 
            // FormProduct
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1078, 678);
            Controls.Add(buttonRemove);
            Controls.Add(groupBox1);
            Controls.Add(gdwProduct);
            Name = "FormProduct";
            Text = "FormProduct";
            Load += FormProduct_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gdwProduct).EndInit();
            ResumeLayout(false);
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
    }
}