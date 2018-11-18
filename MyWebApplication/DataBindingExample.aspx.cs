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
    public partial class DataBindingExample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                BindDataToGridView();
        }

        protected void BindDataToGridView()
        {
            var connectionFromConfiguration = WebConfigurationManager.ConnectionStrings["DBConnection"];

            using (SqlConnection dbConnection = new SqlConnection(connectionFromConfiguration.ConnectionString))
            {
                try
                {
                    dbConnection.Open();
                    SqlCommand command = new SqlCommand("SELECT id, display_name, hex_code FROM colors ORDER BY hex_code",dbConnection);
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    DataSet dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);
                    if (dataSet.Tables[0].Rows.Count > 0)
                    {
                        gvColors.DataSource = dataSet;
                        gvColors.DataBind();
                    }
                }
                catch (SqlException ex)
                {
                    ltError.Text = "Error: " + ex.Message;
                }
            }
        }

        protected void gvColors_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ltError.Text = String.Empty;
            GridViewRow gvRow = gvColors.Rows[e.RowIndex];
            HiddenField hdnColorID = (HiddenField) gvRow.FindControl("hdnColorId");

            var connectionFromConfiguration = WebConfigurationManager.ConnectionStrings["DBConnection"];

            using (SqlConnection dbConnection = new SqlConnection(connectionFromConfiguration.ConnectionString))
            {
                try
                {
                    dbConnection.Open();
                    string sql = $"DELETE FROM colors WHERE id='{hdnColorID.Value}'";
                    SqlCommand command = new SqlCommand(sql, dbConnection);
                    command.ExecuteNonQuery();
                    gvColors.EditIndex = -1;
                    BindDataToGridView();
                }
                catch (Exception ex)
                {
                    ltError.Text = ex.Message;
                }
            }
        }

        protected void gvColors_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            ltError.Text = string.Empty;
            gvColors.EditIndex = e.NewEditIndex;
            BindDataToGridView();
        }

        protected void gvColors_OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            ltError.Text = String.Empty;
            GridViewRow gvRow = (GridViewRow) gvColors.Rows[e.RowIndex];
            HiddenField hdnColorID = (HiddenField) gvRow.FindControl("hdnColorId");
            TextBox TxtName = (TextBox) gvRow.Cells[1].Controls[0];
            TextBox TxtHex = (TextBox) gvRow.Cells[2].Controls[0];

            var connectionFromConfiguration = WebConfigurationManager.ConnectionStrings["DBConnection"];

            using (SqlConnection dbConnection = new SqlConnection(connectionFromConfiguration.ConnectionString))
            {
                try
                {
                    dbConnection.Open();
                    string sql = $"UPDATE colors SET display_name='{TxtName.Text}', hex_code='{TxtName.Text}' WHERE id='{hdnColorID.Value}'";
                    SqlCommand command = new SqlCommand(sql, dbConnection);
                    command.ExecuteNonQuery();
                    gvColors.EditIndex = -1;
                    BindDataToGridView();
                }
                catch (Exception ex)
                {
                    ltError.Text = ex.Message;
                }
            }
        }

        protected void gvColors_OnRowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvColors.EditIndex = -1;
            BindDataToGridView();
        }

        protected void btnAddRow_OnClick(object sender, EventArgs e)
        {
            var connectionFromConfiguration = WebConfigurationManager.ConnectionStrings["DBConnection"];

            using (SqlConnection dbConnection = new SqlConnection(connectionFromConfiguration.ConnectionString))
            {
                try
                {
                    dbConnection.Open();
                    SqlCommand command = new SqlCommand("INSERT INTO colors (display_name,hex_code) values ('','')", dbConnection);
                    command.ExecuteNonQuery();
                    gvColors.EditIndex = -1;
                    BindDataToGridView();
                }
                catch (Exception ex)
                {
                    ltError.Text = ex.Message;
                }
            }
        }
    }
}