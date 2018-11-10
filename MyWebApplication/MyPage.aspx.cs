using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebApplication
{
    public partial class MyPage : System.Web.UI.Page
    {
        private List<MyEvent> _myEvents;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["MyEvents"] = new List<MyEvent>();
            }
        }

        protected void btnEvent_Click(object sender, EventArgs e)
        {
            UpdateEvents();
            BindEvents();
        }

        private void UpdateEvents()
        {
            if (Session["MyEvents"] != null)
                _myEvents = (List<MyEvent>) Session["MyEvents"];
            else
                _myEvents = new List<MyEvent>();

            _myEvents.Add(new MyEvent(
                txtEvent.Text, 
                calendarEvents.SelectedDate
            ));

            Session["MyEvents"] = _myEvents;
        }

        private void BindEvents()
        {
            rptEvents.DataSource = _myEvents;
            rptEvents.DataBind();
        }
    }

    public class MyEvent
    {
        public string EventName { get; private set; }
        public string EventDate { get; private set; }

        public MyEvent(string eventName, DateTime eventDate)
        {
            EventName = eventName;
            EventDate = eventDate.ToShortDateString();    
        }
    }
}