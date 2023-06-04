using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace First
{
    public partial class Form1 : Form
    {
        private SqlConnection sqlConnection;
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
                sqlConnection.Open();
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
    }
}