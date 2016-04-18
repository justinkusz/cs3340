using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class hw5_Default : System.Web.UI.Page
{
    // Set database type. If working on campus use:
    string dbType = "SQL_Server";
    // Open App_Code/hw4/ConnectionFactory.cs and examine the GetCommand method.
    // Open Web.config and examine the connectionStrings node.

    // If working from home, use:
    //String dbType = "Access_Patients"; 
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void gvPatients_SelectedIndexChanged(object sender, EventArgs e)
    {
        string last = gvPatients.SelectedRow.Cells[3].Text;
        string first = gvPatients.SelectedRow.Cells[4].Text;
        string patientId = gvPatients.SelectedRow.Cells[2].Text;
        lblSelectedPatient.Text = last + ", " + first;
        lblTotalCharges.Text = getTotalCharges(dbType, patientId).ToString("C");
    }
    protected void btnAddPatient_Click(object sender, EventArgs e)
    {

    }

    private double getTotalCharges(string dbType, string patientId)
    {
        double result = 0.0;

        try
        {
            // 1. Read data required Patient data from database
            //    See: https://lucius.valdosta.edu/dgibson/db1/default.aspx, Database Programming Primer notes, page 5, item 12.
            //    Parameter for GetCommand method should be "dbType";
            IDbCommand cmd = ConnectionFactory.GetCommand(dbType);
            cmd.CommandText = "SELECT [Charge] FROM [Visits] WHERE ([PatientID] = @PatientID)";
            IDbDataParameter param = cmd.CreateParameter();
            param.ParameterName = "@PatientID";
            param.Value = patientId;
            cmd.Parameters.Add(param);
            cmd.Connection.Open();
            IDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                result += Convert.ToDouble(dr.GetValue(0));
            }

            cmd.Connection.Close();

            return result;
        }
        catch (Exception ex)
        {
            
        }
        return result;
    }
}