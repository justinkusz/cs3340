using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _default : System.Web.UI.Page
{
    int availSeats;
    List<Seat> seats;
    ListItem[] seatNums;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {
            seatNums = (ListItem[])Session["SeatNums"];
            seats = (List<Seat>)Session["Seats"];
            availSeats = (int)Session["AvailSeats"];
            
        }
        else
        {
            availSeats = 0;
            Session["AvailSeats"] = availSeats;
        }
        lblAvailTickets.Text = availSeats.ToString();
    }
    protected void btnMakeEvent_Click(object sender, EventArgs e)
    {
        String eventName = txtEventName.Text;
        int firstSeat = Convert.ToInt32(txtFirstSeat.Text);
        int lastSeat = Convert.ToInt32(txtLastSeat.Text);
        int numSeats = (lastSeat - firstSeat) + 1;
        seatNums = new ListItem[numSeats];
        for (int i = 0; i < numSeats; i++)
        {
            seatNums[i] = new ListItem((i + firstSeat).ToString());
        }
        ddlSeats.DataSource = seatNums;
        ddlSeats.DataBind();
        Session["SeatNums"] = seatNums;
        Session["AvailSeats"] = numSeats;
        btnPurchase.Enabled = true;
        btnSummary.Enabled = true;
        lblAvailTickets.Text = numSeats.ToString();
    }
    protected void btnPurchase_Click(object sender, EventArgs e)
    {
        String buyerName = txtBuyerName.Text;
        int buyerAge = Convert.ToInt32(txtBuyerAge.Text);
        int seatNum = Convert.ToInt32(ddlSeats.SelectedItem.Text);
        
        seats.Add(new Seat(buyerName, seatNum, buyerAge));
        Session["Seats"] = seats;
    }
}

/*public class MyEvent
{
    private String name;
    private int availSeats;
    private List<Seat> seats;

    public MyEvent(String name, int numSeats)
    {
        this.name = name;
        this.availSeats = numSeats;
        this.seats = new List<Seat>();
    }

    public String Name
    {
        get { return name; }
    }

    public int AvailSeats
    {
        get { return availSeats; }
    }

    public List<Seat> Seats
    {
        get { return seats; }
    }

    public bool PurchaseSeat(Seat seat)
    {
        if (availSeats > 0)
        {
            seats.Add(seat);
            availSeats--;
            return true;
        }
        return false;
    }
}*/

public class Seat
{
    private String name;
    private int number;
    private int age;
    private double price;

    public Seat(String name, int number, int age)
    {
        this.name = name;
        this.number = number;
        this.age = age;

        if (age < 13)
        {
            this.price = 5.00;
        }
        else
        {
            this.price = 10.00;
        }
    }

    public String Name
    {
        get { return name; }
    }

    public int Number
    {
        get { return number; }
    }

    public int Age{
        get { return age; }
    }

    public double Price{
        get { return price; }
    }
}