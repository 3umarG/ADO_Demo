using System.Data.SqlClient;

namespace First
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// Data Source : the Server you want to connect , . or Server Name that connected to it ==> Local 
        /// Initial Catalog : Current DB 
        /// Integrated Securty : true ===> Windows Auth , false ===> SQL Auth

        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-EF44UM4\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=true");

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void openConnection(object sender, EventArgs e)
        {
            sqlConnection.Open();
        }

        private void closeConnection(object sender, EventArgs e)
        {
            sqlConnection.Close();
        }
    }
}