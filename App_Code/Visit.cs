using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Visit
/// </summary>
public class Visit
{
    string date;
    double charge;
    string notes;

	public Visit(string date, double charge, string notes)
	{
        this.date = date;
        this.charge = charge;
        this.notes = notes;
	}

    public string Date
    {
        get { return date; }
    }

    public double Charge
    {
        get { return charge; }
    }

    public string Notes
    {
        get { return notes; }
    }
}