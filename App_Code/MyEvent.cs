using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MyEvent
/// </summary>
public class MyEvent
{
    private String name;
    private List<int> availSeats;
    private List<Seat> tickets;

    public MyEvent(String name, int firstSeat, int lastSeat)
    {
        int numAvailSeats = (lastSeat - firstSeat) + 1;
        this.name = name;
        tickets = new List<Seat>();
        availSeats = new List<int>();

        for (int i = firstSeat; i <= lastSeat; i++)
        {
            availSeats.Add(i);
        }

    }

    public void Purchase(String name, int age, int seatNum)
    {
        availSeats.Remove(seatNum);
        tickets.Add(new Seat(name, age, seatNum));
    }

    public void Refund(String buyer)
    {
        foreach (Seat seat in tickets)
        {
            if (seat.Name.Equals(buyer))
            {
                availSeats.Add(seat.Number);
                availSeats.Sort();
                tickets.Remove(seat);
                break;
            }
        }

    }

    public String Name
    {
        get { return name; }
        set { name = value; }
    }

    public int NumAvailSeats
    {
        get { return availSeats.Count; }
    }

    public List<int> AvailSeats
    {
        get { return availSeats; }
    }

    public List<Seat> Tickets
    {
        get { return tickets; }
        set { tickets = value; }
    }

    public int NumTickets
    {
        get { return tickets.Count; }
    }
}