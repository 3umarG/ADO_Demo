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
        private SqlCommand sqlCommand;
        private SqlDataAdapter sqlDataAdapter;
        private DataTable dataTable;
        public FormSqlDataAdapter()
        {
            InitializeComponent();
            sqlConnection = new SqlConnection(@ConfigurationManager.ConnectionStrings["NorthwindDB"].ConnectionString);
        }

        private void FillListBox()
        {
            /// Complext Binding : give the whole source without iterate over the results "list" ...
            this.listProducts.DataSource = dataTable;
            this.listProducts.DisplayMember = "ProductName";       // chose the result that shows to user.
            this.listProducts.ValueMember = "ProductID";         // chose the value for select when you need any another commands depend on it


            this.listProducts.SelectedIndexChanged += (sender, e) => this.Text = $"Selected ProductID : {this.listProducts.SelectedValue}";


        }

        private void BtnGetProducts_Click(object sender, EventArgs e)
        {
            sqlCommand = new SqlCommand("Select * from Products Where ProductID % 2 = @ID", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@ID", 0);

            sqlDataAdapter = new SqlDataAdapter(sqlCommand);

            dataTable = new DataTable();

            /// Fill : 
            /// 1- open connection 
            /// 2- execute command 
            /// 3- store the result on DataTable "DataSource"
            /// 4- close the connection
            sqlDataAdapter.Fill(dataTable);

            FillListBox();

            FillGridView();

        }

        private void FillGridView()
        {
            this.gvProducts.DataSource = dataTable;
        }

        private void BtnSaveClick(object sender, EventArgs e)
        {
            // Still need SQL Command for : Update , Insert , Delete .
            // SqlCommandBuilder
            sqlDataAdapter.Update(dataTable);
        }
    }
}
