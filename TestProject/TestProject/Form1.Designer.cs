namespace TestProject
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            gdwProduct = new System.Windows.Forms.DataGridView();
            groupBox1 = new System.Windows.Forms.GroupBox();
            buttonAdd = new System.Windows.Forms.Button();
            tbxQuantityPerUnit = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            tbxUnitInStock = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            tbxUnitPrice = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            tbxProductName = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            buttonRemove = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)gdwProduct).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // gdwProduct
            // 
            gdwProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gdwProduct.Location = new System.Drawing.Point(12, 12);
            gdwProduct.Name = "gdwProduct";
            gdwProduct.RowTemplate.Height = 25;
            gdwProduct.Size = new System.Drawing.Size(938, 307);
            gdwProduct.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(buttonAdd);
            groupBox1.Controls.Add(tbxQuantityPerUnit);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(tbxUnitInStock);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(tbxUnitPrice);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(tbxProductName);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new System.Drawing.Point(13, 337);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(233, 272);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Added Group";
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new System.Drawing.Point(149, 229);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new System.Drawing.Size(75, 23);
            buttonAdd.TabIndex = 6;
            buttonAdd.Text = "Add";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // tbxQuantityPerUnit
            // 
            tbxQuantityPerUnit.Location = new System.Drawing.Point(6, 183);
            tbxQuantityPerUnit.Name = "tbxQuantityPerUnit";
            tbxQuantityPerUnit.Size = new System.Drawing.Size(218, 23);
            tbxQuantityPerUnit.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(6, 165);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(98, 15);
            label4.TabIndex = 2;
            label4.Text = "Quantity Per Unit";
            // 
            // tbxUnitInStock
            // 
            tbxUnitInStock.Location = new System.Drawing.Point(6, 133);
            tbxUnitInStock.Name = "tbxUnitInStock";
            tbxUnitInStock.Size = new System.Drawing.Size(218, 23);
            tbxUnitInStock.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(6, 115);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(74, 15);
            label3.TabIndex = 4;
            label3.Text = "Unit In Stock";
            // 
            // tbxUnitPrice
            // 
            tbxUnitPrice.Location = new System.Drawing.Point(6, 83);
            tbxUnitPrice.Name = "tbxUnitPrice";
            tbxUnitPrice.Size = new System.Drawing.Size(218, 23);
            tbxUnitPrice.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(6, 65);
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
            // buttonRemove
            // 
            buttonRemove.Location = new System.Drawing.Point(329, 325);
            buttonRemove.Name = "buttonRemove";
            buttonRemove.Size = new System.Drawing.Size(75, 23);
            buttonRemove.TabIndex = 2;
            buttonRemove.Text = "Remove";
            buttonRemove.UseVisualStyleBackColor = true;
            buttonRemove.Click += buttonRemove_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(962, 719);
            Controls.Add(buttonRemove);
            Controls.Add(groupBox1);
            Controls.Add(gdwProduct);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)gdwProduct).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView gdwProduct;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.TextBox tbxQuantityPerUnit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxUnitInStock;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxUnitPrice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxProductName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonRemove;
    }
}
