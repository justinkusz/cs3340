using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Seat
/// </summary>
public class Seat
{
    private String name;
    private int number;
    private int age;
    private double price;

    public Seat(String name, int age, int number)
    {
        Name = name;
        Age = age;
        this.number = number;
    }

    public String Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Number
    {
        get { return number; }
    }

    public int Age
    {
        get { return age; }
        set
        {
            age = value;
            if (age < 13)
            {
                price = 5.00;
            }
            else
            {
                price = 10.00;
            }
        }
    }

    public double Price
    {
        get { return price; }
    }
}