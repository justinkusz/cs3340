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

    protected void Page_Load(object sender, EventArgs e)
    {
        currentEvent = Session["Event"] as MyEvent;
        tickets = currentEvent.Tickets;
        if (!Page.IsPostBack)
        {
            lblEventName.Text = currentEvent.Name;
            ddlBuyer.DataSource = tickets;
            ddlBuyer.DataTextField = "name";
            ddlBuyer.DataValueField = "name";
            ddlBuyer.DataBind();
            txtSummary.Text = display_summary("purchase");
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
        currentEvent.Refund(buyer);
        ddlBuyer.DataSource = tickets;
        ddlBuyer.DataBind();
        txtSummary.Text = display_summary(rblSort.SelectedValue);
        Session["Event"] = currentEvent;
    }

    protected String display_summary(String sortOrder)
    {
        String summary;
        if (currentEvent.NumTickets < 1)
        {
            return "No tickets purchased.";
        }
        List<Seat> sortedSeatList = tickets.OrderBy(o => o.Name).ToList();
        double total = 0.0;
        double average;
        summary = "Name             Seat  Age   Price" + System.Environment.NewLine;
        summary += "--------------- ----- ---- -------" + System.Environment.NewLine;
        switch (sortOrder){
            case "name":
                sortedSeatList = tickets.OrderBy(o => o.Name).ToList();
                break;
            case "number":
                sortedSeatList = tickets.OrderBy(o => o.Number).ToList();
                break;
            default:
                sortedSeatList = tickets;
                break;
        }
        foreach (Seat seat in sortedSeatList)
        {
            summary += String.Format("{0,-15} {1,5} {2,4} {3,7}", seat.Name, seat.Number, seat.Age, seat.Price.ToString("C")) + System.Environment.NewLine;
            total += seat.Price;
        }
        summary += "--------------- ----- ---- -------" + System.Environment.NewLine;
        average = total / currentEvent.NumTickets;
        summary += "Tickets Sold: " + currentEvent.NumTickets + System.Environment.NewLine;
        summary += "Tickets Available: " + currentEvent.NumAvailSeats + System.Environment.NewLine;
        summary += "Total Ticket Prices: " + total.ToString("C") + System.Environment.NewLine;
        summary += "Average Ticket Price: " + average.ToString("C") + System.Environment.NewLine;
        summary += "Available Seats: ";
        foreach (int number in currentEvent.AvailSeats)
        {
            summary += number + ", ";
        }
        summary = summary.Substring(0, summary.Length - 2);
        return summary;
    }
    protected void rblSort_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtSummary.Text = display_summary(rblSort.SelectedValue);
        Session["Event"] = currentEvent;
    }
}