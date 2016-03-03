using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class hw3_summary : System.Web.UI.Page
{
    MyEvent currentEvent;
    List<Seat> tickets;
    String output;

    protected void Page_Load(object sender, EventArgs e)
    {
        currentEvent = Session["Event"] as MyEvent;
        if (!Page.IsPostBack)
        {
            lblEventName.Text = currentEvent.Name;
            tickets = currentEvent.Tickets;
            ddlBuyer.DataSource = tickets;
            ddlBuyer.DataTextField = "name";
            ddlBuyer.DataValueField = "name";
            ddlBuyer.DataBind();

            output = "Name          Seat    Age    Price \n";
            txtSummary.Text = output;
        }
    }

    protected void btnSellMore_Click(object sender, EventArgs e)
    {
        Session["Event"] = currentEvent;
        Response.Redirect("default.aspx");
    }
    protected void btnRemove_Click(object sender, EventArgs e)
    {
        String buyer = ddlBuyer.SelectedValue;
        txtSummary.Text = "Removed " + buyer;
        currentEvent.Refund(buyer);
        ddlBuyer.DataSource = tickets;
        ddlBuyer.DataBind();
        Session["Event"] = currentEvent;
    }
    
}