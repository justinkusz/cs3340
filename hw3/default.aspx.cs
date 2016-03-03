using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class _default : System.Web.UI.Page
{
    MyEvent newEvent;

    protected void Page_Load(object sender, EventArgs e)
    {
        newEvent = Session["Event"] as MyEvent;

        if ((newEvent != null) && (!Page.IsPostBack))
        {
            ddlSeats.DataSource = newEvent.AvailSeats;
            ddlSeats.DataBind();
            lblAvailTickets.Text = newEvent.NumAvailSeats.ToString();
        }
    }
    protected void btnMakeEvent_Click(object sender, EventArgs e)
    {
        String eventName = txtEventName.Text;
        int firstSeatNum = Convert.ToInt16(txtFirstSeat.Text);
        int lastSeatNum = Convert.ToInt16(txtLastSeat.Text);
        newEvent = new MyEvent(eventName, firstSeatNum, lastSeatNum);
        Session["Event"] = newEvent;
        lblAvailTickets.Text = newEvent.NumAvailSeats.ToString();
        ddlSeats.DataSource = newEvent.AvailSeats;
        ddlSeats.DataBind();
    }
    protected void btnPurchase_Click(object sender, EventArgs e)
    {
        String buyerName = txtBuyerName.Text;
        int buyerAge = Convert.ToInt16(txtBuyerAge.Text);
        int seatNum = Convert.ToInt16(ddlSeats.SelectedValue);
        newEvent.Purchase(buyerName, buyerAge, seatNum);
        lblAvailTickets.Text = newEvent.NumAvailSeats.ToString();
        Session["Event"] = newEvent;
        ddlSeats.DataSource = newEvent.AvailSeats;
        ddlSeats.DataBind();
        txtBuyerName.Text = String.Empty;
        txtBuyerAge.Text = String.Empty;
    }
    protected void btnSummary_Click(object sender, EventArgs e)
    {
        Response.Redirect("summary.aspx");
    }
}