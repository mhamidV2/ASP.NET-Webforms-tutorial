using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebApplication
{
    public partial class ExceptionHandlingExample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            string message = String.Empty;
            //try
            //{
                decimal expectedDecimal = decimal.Parse(txtDecimal.Text.Replace(".",","));
                message = "Your decimal is: " + expectedDecimal;
            //}
            //catch(Exception ex)
            //{
            //    message = "Something went wrong: "+ex.Message;
            //}
            lblMessage.Text = message;
            lblMessage.Visible = true;
        }
    }
}