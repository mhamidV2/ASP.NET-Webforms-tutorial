using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebApplication
{
    public partial class DBConnectionExample : System.Web.UI.Page
    {

        public void DisplayQueryResultsWithLiteral(SqlDataReader reader, Literal literal)
        {
            while (reader.Read())
            {
                literal.Text += $"<li> {reader.GetString(0)} -- {reader.GetString(1)} </li>";
            }
        }

        public SqlDataReader ExecQuery(string query, SqlConnection dbConnection)
        {
            SqlCommand command = new SqlCommand(query, dbConnection);
            return command.ExecuteReader();
        }

        public bool OpenConnection(SqlConnection dbConnection)
        {
            dbConnection.Open();
            return ConnectionState.Open == dbConnection.State;
        }

        private const string SUCCESSFUL_CONNECTION_MESSAGE = "Connection successful.";
        private const string FAILED_QUERY_MESSAGE = "Select Command Failed:";
        private const string FAILED_CONNECTION_MESSAGE = "Connection failed:";

        protected void Page_Load(object sender, EventArgs e)
        {
            var connectionFromConfiguration = WebConfigurationManager.ConnectionStrings["DBConnection"];

            using (SqlConnection dbConnection = new SqlConnection(connectionFromConfiguration.ConnectionString))
            {
                try
                {
                    if(OpenConnection(dbConnection))
                        ltConnectionMessage.Text = SUCCESSFUL_CONNECTION_MESSAGE;

                    try
                    {
                        SqlDataReader reader = ExecQuery("SELECT Nom, NomSeo FROM Formation", dbConnection);
                        if (reader.HasRows)
                            DisplayQueryResultsWithLiteral(reader, ltOutput);
                    }
                    catch (SqlException ex)
                    {
                        ltOutput.Text += $"<li> {FAILED_QUERY_MESSAGE} {ex.Message} </li>";
                    }
                }
                catch (SqlException ex)
                {
                    ltConnectionMessage.Text = $"{FAILED_CONNECTION_MESSAGE} " + ex.Message;
                }
            }
        }
    }
}