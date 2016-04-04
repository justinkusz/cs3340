using hw4;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    // Set database type. If working on campus use:
    //string dbType = "SQL_Server";
    // Open App_Code/hw4/ConnectionFactory.cs and examine the GetCommand method.
    // Open Web.config and examine the connectionStrings node.

    // If working from home, use:
    String dbType = "Access_Patients";

    protected void Page_Load(object sender, EventArgs e)
    {
        // These three lines of code are correct and do not need modifying.
        // You will write the referenced methods below.
        List<Property> props = getPropertyList(dbType);
        displayPropertyStats(props);
        displayProperties(props);
    }

    private List<Property> getPropertyList(string dbType)
    {
        try
        {
            // 1. Read data required Patient data from database
            //    See: https://lucius.valdosta.edu/dgibson/db1/default.aspx, Database Programming Primer notes, page 5, item 12.
            //    Parameter for GetCommand method should be "dbType";
            IDbCommand cmd = ConnectionFactory.GetCommand(dbType);
            cmd.CommandText = getSQL();
            cmd.Connection.Open();
            // 2. Create List for Patients.
            List<Property> properties = new List<Property>();
            IDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int listPrice = dr.GetInt32(0);
                int sqFeet = dr.GetInt32(1);
                int beds = dr.GetInt32(2);
                int baths = dr.GetInt32(3);
                int year = dr.GetInt32(4);
                properties.Add(new Property(listPrice, sqFeet, beds, baths, year));
            }
            
            cmd.Connection.Close();

            return properties;
        }
        catch (Exception ex)
        {
            txtMsg.Text = "\r\nError reading data\r\n";
            txtMsg.Text += ex.ToString();
        }
        return null;
    }

    private string getSQL()
    {
        // Write code to return SQL statement to retrieve the required data.
        return "Select ListPrice, SqFeet, Beds, Baths, YearBuilt FROM Properties";
    }

    private void displayPropertyStats(List<Property> props)
    {
        // Compute the required stats and display.
        int numProperties = props.Count;
        double average = 0.0;
        foreach (Property prop in props)
        {
            average += prop.ListPrice;
        }
        average /= props.Count;
        int numAboveAverage = 0;
        foreach (Property prop in props)
        {
            if (prop.ListPrice > average)
            {
                numAboveAverage++;
            }
        }
        lblNumProperties.Text = numProperties.ToString();
        lblAveragePrice.Text = average.ToString();
        lblNumAboveAvgPrice.Text = numAboveAverage.ToString();
    }

    private void displayProperties(List<Property> props)
    {
        // Loop over props and display each one.

        // txtProperties.Text = ...
    }
    protected void rblSortType_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Implement this if you can. It will require some changes to the code above and
        // some refactoring.
    }
}