namespace First
{
    partial class FormSqlDataAdapter
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
            listProducts = new ListBox();
            btnGetProducts = new Button();
            gvProducts = new DataGridView();
            btnSave = new Button();
            ((System.ComponentModel.ISupportInitialize)gvProducts).BeginInit();
            SuspendLayout();
            // 
            // listProducts
            // 
            listProducts.FormattingEnabled = true;
            listProducts.ItemHeight = 15;
            listProducts.Location = new Point(668, 13);
            listProducts.Name = "listProducts";
            listProducts.Size = new Size(120, 244);
            listProducts.TabIndex = 0;
            // 
            // btnGetProducts
            // 
            btnGetProducts.Location = new Point(668, 295);
            btnGetProducts.Name = "btnGetProducts";
            btnGetProducts.Size = new Size(120, 23);
            btnGetProducts.TabIndex = 1;
            btnGetProducts.Text = "Get Products";
            btnGetProducts.UseVisualStyleBackColor = true;
            btnGetProducts.Click += BtnGetProducts_Click;
            // 
            // gvProducts
            // 
            gvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gvProducts.Location = new Point(12, 12);
            gvProducts.Name = "gvProducts";
            gvProducts.RowTemplate.Height = 25;
            gvProducts.Size = new Size(638, 245);
            gvProducts.TabIndex = 2;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(12, 295);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 3;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += BtnSaveClick;
            // 
            // FormSqlDataAdapter
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSave);
            Controls.Add(gvProducts);
            Controls.Add(btnGetProducts);
            Controls.Add(listProducts);
            Name = "FormSqlDataAdapter";
            Text = "FormSqlDataAdapter";
            ((System.ComponentModel.ISupportInitialize)gvProducts).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ListBox listProducts;
        private Button btnGetProducts;
        private DataGridView gvProducts;
        private Button btnSave;
    }
}