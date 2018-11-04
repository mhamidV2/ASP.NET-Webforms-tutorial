using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebApplication
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            string message =
                string.Format(
                    "You said your name is {0} and your email address is {1}. Your favorite color is {2}. Your favorite color is {3}",
                    txtName.Text, txtEmail.Text, txtAge.Text, ddlColor.SelectedValue);

            ltMessage.Text = message;
        }
    }
}