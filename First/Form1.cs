using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace First
{
    public partial class Form1 : Form
    {
        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;
        public Form1()
        {
            InitializeComponent();

            /// Data Source : the Server you want to connect , . or Server Name that connected to it ==> Local 
            /// Initial Catalog : Current DB 
            /// Integrated Securty : true ===> Windows Auth , false ===> SQL Auth     
            sqlConnection = new SqlConnection(@ConfigurationManager.ConnectionStrings["NorthwindDB"].ConnectionString);


            // Subscribe for some events : 
            // 1- when the state of sql connection changed : Closed  ,Opened ...
            sqlConnection.StateChange += (sender, e) => Text = ($"The SQL connection was : {e.OriginalState} and changed to " +
                $": {e.CurrentState}");

            // 2- when there is message from Database : like when any SQL command or query failed
            sqlConnection.InfoMessage += (sender, e) => MessageBox.Show($"Message come from SQL : {e.Message}");
        }



        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void openConnection(object sender, EventArgs e)
        {
            // Check for the connection is closed to prevent the Excpetions
            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
                cbIDs_LoadItems(sender, e);
            }
            else this.Text =
            $"The Connection State is already Opened";
        }

        private void closeConnection(object sender, EventArgs e)
        {
            if (sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
            else this.Text =
            $"The Connection State is already Closed";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.ChangeDatabase("Northwind");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.ChangeDatabase("iti");
            }
        }

        private void btnCount_Click(object sender, EventArgs e)
        {
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            //sqlCommand.CommandType = CommandType.StoredProcedure; // to use stored procedure as query
            sqlCommand.CommandText = "SELECT Count(*) From Products";

            if (sqlConnection.State == ConnectionState.Closed)
                sqlConnection.Open();

            /// When use these functions you should open and close the Connection mannually 
            //sqlCommand.ExecuteNonQuery();        // execute commands : that returns n raws affected
            //sqlCommand.ExecuteReader();          // returns raws and columns
            var result = sqlCommand.ExecuteScalar();            // returns single value for Aggregate functions

            if (int.TryParse(result?.ToString() ?? "0", out int Number))
            {
                this.Text = $"Count : {Number}";
                Thread.Sleep(2000);
                sqlConnection.Close();
            }
        }

        private void btnNonQuery_Click(object sender, EventArgs e)
        {
            sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "UpdateProductNameById";     // stored procedure name

            // alert the sql Command that there is parameters
            sqlCommand.Parameters.Add("@ProductID", SqlDbType.Int);
            sqlCommand.Parameters.Add("@ProductName", SqlDbType.NVarChar, 40);

            // give the sql commands its parameters based on their names
            sqlCommand.Parameters["@ProductID"].Value = 1;
            sqlCommand.Parameters["@ProductName"].Value = "Updated Name from Windows Form";

            if (sqlConnection.State == ConnectionState.Closed)
                sqlConnection.Open();

            // Non Query : Commands ...
            int result = sqlCommand.ExecuteNonQuery();
            Thread.Sleep(3000);
            this.Text = "Stored Procedure Done !!";
        }

        private void btnCommand_Click(object sender, EventArgs e)
        {

            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText =
                                @"Update Products 
                                Set Products.ReorderLevel = 12
                                Where Products.ProductID % 2 = 0";

            if (sqlConnection.State == ConnectionState.Closed)
                sqlConnection.Open();

            var rawsEffected = sqlCommand.ExecuteNonQuery();
            Thread.Sleep(3000);
            this.Text = $"{rawsEffected} Raws Effected !!!";
        }

        private void cbIDs_LoadItems(object sender, EventArgs e)
        {
            sqlCommand = new SqlCommand("Select ProductID from Products", sqlConnection);

            if (sqlConnection.State == ConnectionState.Closed)
                sqlConnection.Open();

            // By using DataReader you have like a wrapper to the Database , but you have not the actual raws and columns
            // you  should start to iterate on them and get them one-by-one
            // ���� ������ ������ ��� ������ �� �� ���� ��� ���� ��� ������ ������ ������ ��� ��� ���� ��� �����
            SqlDataReader results = sqlCommand.ExecuteReader();


            // Thats what we called DataBinding
            while (results.Read())
            {
                cbIDs.Items.Add(results["ProductID"]);

            }

            sqlConnection.Close();
        }
    }
}