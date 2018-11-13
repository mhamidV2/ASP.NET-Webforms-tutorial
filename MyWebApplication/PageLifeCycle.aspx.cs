using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebApplication
{
    public partial class PageLifeCycle : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            // The Start Stage is complete and Page properties have been loaded and we enter the Initialization Phase.
            // You now have access to properties such as "Page.IsPostBack"
            bool isPostBack = Page.IsPostBack;
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            // All controls and controls properties have now been initialized.
            // I can set control properties, such as the Text Propertyof a Label control
            lblInit.Text = "I set this text during Page_Init.";
        }

        protected void Page_InitComplete(object sender, EventArgs e)
        {
            // Everything has been initialized, this event can be used for tasks that require everything
            // to first be initialized
        }

        protected void Page_PreLoad(object sender, EventArgs e)
        {
            // If you need to perform a task before the page load.
            // We are transitioning from the Initialization stage to the Load stage.
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            // We are now in the load stage.
            // This is where you will perform most of your page related tasks such as
            // data binding to dropdowns and setting text.
            lblPageLoad.Text = "I set this text during the page load and this is where you will usually perform a task";

            if (Page.IsPostBack)
                lblPostBack.Text = "I set this text when the page posted back";
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            // We are now in the Post Back Event Handling stage.
            lblButtonEvent.Text = "I set this text when my button OnClick event method was fired";
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            // use this method when you need to perform a task after the Page Load Phase in completed.
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            // We are now in the rendering Phase.
            // Use this method if you need to modify a controls's markup output before it is rendered
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            // We are now in the Unload Phase.
            // Use this method if you need to do final cleanup.
            // The lifecycle is complete.
        }
    }
}