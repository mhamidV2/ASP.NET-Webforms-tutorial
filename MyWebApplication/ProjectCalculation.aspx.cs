using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebApplication
{
    public partial class ProjectCalculation : System.Web.UI.Page
    {
        public decimal BasePrice = 100.00m;
        protected void Page_Load(object sender, EventArgs e)
        {
            ltBasePrice.Text = BasePrice.ToString("C", new CultureInfo("en-US"));
        }

        protected void ddlStates_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            States states = new States();
            decimal fee = states.GetFeeForState(ddlStates.SelectedValue);
            decimal finalPrice = BasePrice + fee;
            ltCustomPrice.Text = finalPrice.ToString("C", new CultureInfo("en-US"));
        }
    }

    public class StateFee
    {
        public string Name
        {
            get;
            private set;
        }

        public string TwoLetterCode
        {
            get;
            private set;
        }

        public decimal Fee
        {
            get;
            private set;
        }

        public StateFee(string name, string twoLetterCode, decimal fee)
        {
            Name = name;
            TwoLetterCode = twoLetterCode;
            Fee = fee;
        }
    }

    public class States
    {
        public List<StateFee> ServiceAreaStateFees = new List<StateFee>();
        public decimal OutOfAreaFee { get; private set; }

        public States()
        {
            ServiceAreaStateFees.Add(new StateFee("Arizona","AZ",8.99m));
            ServiceAreaStateFees.Add(new StateFee("California","CA",16.99m));
            ServiceAreaStateFees.Add(new StateFee("Indiana","IN",2.99m));
            ServiceAreaStateFees.Add(new StateFee("New York","NY",7.99m));

            OutOfAreaFee = 49.99m;
        }

        public decimal GetFeeForState(string twoLetterCode)
        {
            var state = ServiceAreaStateFees.FirstOrDefault(f => f.TwoLetterCode.Equals(twoLetterCode.ToUpper()));

            return state?.Fee ?? OutOfAreaFee;
        }
    }
}