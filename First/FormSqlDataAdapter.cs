using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace First
{
    public partial class FormSqlDataAdapter : Form
    {

        private readonly SqlConnection sqlConnection;
        private SqlCommand sqlProductsCommand;
        private SqlDataAdapter sqlProductsDataAdapter;
        private DataTable productsDataTable;

        // For get Suppliers
        private SqlCommand sqlSpCommand;
        private SqlDataAdapter sqlSpDataAdapter;
        private DataTable suppliersDataTable;

        public FormSqlDataAdapter()
        {
            InitializeComponent();
            sqlConnection = new SqlConnection(@ConfigurationManager.ConnectionStrings["NorthwindDB"].ConnectionString);
        }

        private void FillListBox()
        {
            /// Complext Binding : give the whole source without iterate over the results "list" ...
            this.listProducts.DataSource = productsDataTable;
            this.listProducts.DisplayMember = "ProductName";       // chose the result that shows to user.
            this.listProducts.ValueMember = "ProductID";         // chose the value for select when you need any another commands depend on it


            this.listProducts.SelectedIndexChanged += (sender, e) => this.Text = $"Selected ProductID : {this.listProducts.SelectedValue}";


        }

        private void BtnGetProducts_Click(object sender, EventArgs e)
        {
            sqlProductsCommand = new SqlCommand("Select * from Products Where ProductID % 2 = @ID", sqlConnection);
            sqlProductsCommand.Parameters.AddWithValue("@ID", 0);

            sqlProductsDataAdapter = new SqlDataAdapter(sqlProductsCommand);

            productsDataTable = new DataTable();

            // For Suppliers :
            sqlSpCommand = new SqlCommand(@"Select SupplierID as SID , CompanyName from Suppliers", sqlConnection);
            sqlSpDataAdapter = new SqlDataAdapter(sqlSpCommand);
            suppliersDataTable = new DataTable();

            // Fill the Supplier DataTable
            sqlSpDataAdapter.Fill(suppliersDataTable);

            /// Fill : 
            /// 1- open connection 
            /// 2- execute command 
            /// 3- store the result on DataTable "DataSource"
            /// 4- close the connection
            sqlProductsDataAdapter.Fill(productsDataTable);

            FillListBox();

            FillGridView();

        }

        private void FillGridView()
        {
            var supplierColumn = new DataGridViewComboBoxColumn();
            supplierColumn.HeaderText = "Supplier Name";
            supplierColumn.DataSource = suppliersDataTable;
            supplierColumn.ValueMember = "SID"; // the background ref from Supplier Table
            supplierColumn.DisplayMember = "CompanyName"; // the Displayed Name from Supplier Table
            supplierColumn.DataPropertyName = "SupplierID";   // that link the selected value from this column to Products Table 


            this.gvProducts.DataSource = productsDataTable;
            this.gvProducts.Columns.AddRange(supplierColumn);
            this.gvProducts.Columns["SupplierID"].ReadOnly = true;
            
        }

        private void BtnSaveClick(object sender, EventArgs e)
        {
            // Still need SQL Command for : Update , Insert , Delete .
            // SqlCommandBuilder
            SqlCommandBuilder sqlCommandBuilder = new(sqlProductsDataAdapter);
            this.gvProducts.EndEdit();



            #region SqlCommandBuilder
            /*
             * The SqlDataAdapter automatically generates commands based on the 'RowState' of each row in the DataTable when you call Update().
             * You can use GetInsertCommand, GetUpdateCommand, or GetDeleteCommand to retrieve the automatically generated commands for customization if needed.
             * In most cases, you don't need to explicitly call these methods unless you require specific customizations for the commands.
             */
            #endregion

            //sqlDataAdapter.UpdateCommand = sqlCommandBuilder.GetUpdateCommand();   // for more customization in UPDATE
            sqlProductsDataAdapter.Update(productsDataTable);
        }
    }
}
