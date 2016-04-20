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
        if (Page.IsPostBack)
        {
            
        }
    }
    protected void gvPatients_SelectedIndexChanged(object sender, EventArgs e)
    {
        string last = gvPatients.SelectedRow.Cells[3].Text;
        string first = gvPatients.SelectedRow.Cells[4].Text;
        string patientId = gvPatients.SelectedRow.Cells[2].Text;
        lblSelectedPatient.Text = last + ", " + first;
        lblTotalCharges.Text = getTotalCharges(dbType, patientId).ToString("C");
        lblSelectedVisit.Text = "";
    }
    protected void btnAddPatient_Click(object sender, EventArgs e)
    {
        string lastName = txtLastName.Text;
        string firstName = txtFirstName.Text;
        string address = txtAddress.Text;
        try
        {
            // 1. Read data required Patient data from database
            //    See: https://lucius.valdosta.edu/dgibson/db1/default.aspx, Database Programming Primer notes, page 5, item 12.
            //    Parameter for GetCommand method should be "dbType";
            dsSqlPatients.InsertParameters["LastName"].DefaultValue = lastName;
            dsSqlPatients.InsertParameters["FirstName"].DefaultValue = firstName;
            dsSqlPatients.InsertParameters["Address"].DefaultValue = address;
            dsSqlPatients.Insert();
        }
        catch (Exception ex)
        {

        }
        gvPatients.DataBind();
        clearInputFields();
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

    
    public bool hasVisits(string patientId)
    {
        bool result = true;
        try
        {
            // 1. Read data required Patient data from database
            //    See: https://lucius.valdosta.edu/dgibson/db1/default.aspx, Database Programming Primer notes, page 5, item 12.
            //    Parameter for GetCommand method should be "dbType";
            IDbCommand cmd = ConnectionFactory.GetCommand(dbType);
            cmd.CommandText = "SELECT COUNT(*) FROM [Visits] WHERE ([PatientID] = @PatientID)";
            IDbDataParameter param = cmd.CreateParameter();
            param.ParameterName = "@PatientID";
            param.Value = patientId;
            cmd.Parameters.Add(param);
            cmd.Connection.Open();
            IDataReader dr = cmd.ExecuteReader();
            int count = 0;
            while (dr.Read())
            {
                count = Convert.ToInt32(dr.GetValue(0));
            }

            cmd.Connection.Close();

            if (count > 0)
                result = true;
            else
                result = false;
        }
        catch (Exception ex)
        {

        }
        return result;
    }

    public bool hasPrescriptions(string visitId)
    {
        bool result = true;
        try
        {
            // 1. Read data required Patient data from database
            //    See: https://lucius.valdosta.edu/dgibson/db1/default.aspx, Database Programming Primer notes, page 5, item 12.
            //    Parameter for GetCommand method should be "dbType";
            IDbCommand cmd = ConnectionFactory.GetCommand(dbType);
            cmd.CommandText = "SELECT COUNT(*) FROM [Prescriptions] WHERE ([VisitID] = @VisitID)";
            IDbDataParameter param = cmd.CreateParameter();
            param.ParameterName = "@VisitID";
            param.Value = visitId;
            cmd.Parameters.Add(param);
            cmd.Connection.Open();
            IDataReader dr = cmd.ExecuteReader();
            int count = 0;
            while (dr.Read())
            {
                count = Convert.ToInt32(dr.GetValue(0));
            }

            cmd.Connection.Close();

            if (count > 0)
                result = true;
            else
                result = false;
        }
        catch (Exception ex)
        {

        }
        return result;
    }

    protected void btnAddVisit_Click(object sender, EventArgs e)
    {
        string visitDate = txtDate.Text;
        string charge = txtCharge.Text;
        string notes = txtNotes.Text;

        try
        {
            // 1. Read data required Patient data from database
            //    See: https://lucius.valdosta.edu/dgibson/db1/default.aspx, Database Programming Primer notes, page 5, item 12.
            //    Parameter for GetCommand method should be "dbType";
            dsSqlVisits.InsertParameters["PatientID"].DefaultValue = gvPatients.SelectedRow.Cells[2].Text;
            dsSqlVisits.InsertParameters["VisitDate"].DefaultValue = visitDate;
            dsSqlVisits.InsertParameters["Charge"].DefaultValue = charge;
            dsSqlVisits.InsertParameters["Notes"].DefaultValue = notes;
            dsSqlVisits.Insert();
        }
        catch (Exception ex)
        {

        }
        gvPatients.DataBind();
        clearInputFields();

        updateCharges();
    }

    private void updateCharges()
    {
        string patientId = gvPatients.SelectedRow.Cells[2].Text;
        lblTotalCharges.Text = getTotalCharges(dbType, patientId).ToString("C");
    }
    private void clearInputFields()
    {
        txtAddress.Text = "";
        txtCharge.Text = "";
        txtDate.Text = "";
        txtDrugName.Text = "";
        txtFirstName.Text = "";
        txtInstructions.Text = "";
        txtLastName.Text = "";
        txtNotes.Text = "";
    }
    protected void gvVisits_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        DataBind();
        updateCharges();
    }
    protected void gvVisits_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        updateCharges();
    }
    protected void gvVisits_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblSelectedVisit.Text = gvVisits.SelectedRow.Cells[4].Text;
    }
    protected void btnAddPrescription_Click(object sender, EventArgs e)
    {
        string drugName = txtDrugName.Text;
        string instructions = txtInstructions.Text;

        try
        {
            // 1. Read data required Patient data from database
            //    See: https://lucius.valdosta.edu/dgibson/db1/default.aspx, Database Programming Primer notes, page 5, item 12.
            //    Parameter for GetCommand method should be "dbType";
            dsSqlPrescriptions.InsertParameters["PatientID"].DefaultValue = gvPatients.SelectedRow.Cells[2].Text;
            dsSqlPrescriptions.InsertParameters["VisitID"].DefaultValue = gvVisits.SelectedRow.Cells[2].Text;
            dsSqlPrescriptions.InsertParameters["DrugName"].DefaultValue = drugName;
            dsSqlPrescriptions.InsertParameters["Instructions"].DefaultValue = instructions;
            dsSqlPrescriptions.Insert();
        }
        catch (Exception ex)
        {

        }
        DataBind();
        clearInputFields();
    }
    protected void gvPrescriptions_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        gvVisits.DataBind();
    }
}