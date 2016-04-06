using hw4;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Patients : System.Web.UI.Page
{
    // Set database type. If working on campus use:
    string dbType = "SQL_Server";

    //string dbType = "Access_Patients";

    //----------------------------------------------
    // You will write the three methods below.
    // You will want to examine the event handlers
    // that call these which are further below.
    //----------------------------------------------

    private void BuildInsertPatientCommand(IDbCommand cmd)
    {
        // Build parameterized insert statement
        //    See: https://lucius.valdosta.edu/dgibson/db1/default.aspx, Database Programming Primer notes, page 6, item 14.
        cmd.CommandText = "Insert Into Patients ( LastName, FirstName, Address ) " + "Values ( @LastName, @FirstName, @Address )";
        cmd.Parameters.Clear();
        IDbDataParameter param = cmd.CreateParameter();
        param.ParameterName = "@LastName";
        param.Value = txtAddLName.Text;
        cmd.Parameters.Add(param);
        param = cmd.CreateParameter();
        param.ParameterName = "@FirstName";
        param.Value = txtAddFName.Text;
        cmd.Parameters.Add(param);
        param = cmd.CreateParameter();
        param.ParameterName = "@Address";
        param.Value = txtAddAddress.Text;
        cmd.Parameters.Add(param);
    }

    private void BuildDeletePatientCommand(IDbCommand cmd)
    {
        // Build parameterized insert statement
        //    See: https://lucius.valdosta.edu/dgibson/db1/default.aspx, Database Programming Primer notes, page 6, item 14.
        cmd.CommandText = "DELETE FROM Patients WHERE PatientID=@PatientID";
        cmd.Parameters.Clear();
        IDbDataParameter param = cmd.CreateParameter();
        param.ParameterName = "@PatientID";
        param.Value = txtDelID.Text;
        cmd.Parameters.Add(param);
    }

    private void BuildUpdatePatientCommand(IDbCommand cmd)
    {
        // Build parameterized delete statement
        //    See: https://lucius.valdosta.edu/dgibson/db1/default.aspx, Database Programming Primer notes, page 6, item 14.
        cmd.CommandText = "UPDATE Patients SET LastName=@LastName, FirstName=@FirstName, Address=@Address WHERE PatientID=@PatientID";
        cmd.Parameters.Clear();
        IDbDataParameter param = cmd.CreateParameter();
        param.ParameterName = "@LastName";
        param.Value = txtUpdLName.Text;
        cmd.Parameters.Add(param);
        param.ParameterName = "@FirstName";
        param.Value = txtUpdFName.Text;
        cmd.Parameters.Add(param);
        param.ParameterName = "@Address";
        param.Value = txtUpdAddress.Text;
        cmd.Parameters.Add(param);
        param.ParameterName = "@PatientID";
        param.Value = txtUpdID.Text;
    }

    //----------------------------------------------
    // Do not modify code below
    //----------------------------------------------

    protected void Page_Load(object sender, EventArgs e)
    {
        txtMsg.Text = "";

        if (!Page.IsPostBack)
        {
            displayPatients(dbType);
        }
    }
    protected void btnAddPatient_Click(object sender, EventArgs e)
    {
        try
        {
            IDbCommand cmd = ConnectionFactory.GetCommand(dbType);
            BuildInsertPatientCommand(cmd);
            cmd.Connection.Open();

            int numRowsAffected = cmd.ExecuteNonQuery();

            txtMsg.Text += "IDbConnection.State: " + cmd.Connection.State.ToString() + Environment.NewLine; ;
            txtMsg.Text += "Num rows affected: " + numRowsAffected + Environment.NewLine;
            txtMsg.Text += "cmd.CommandText: " + cmd.CommandText + Environment.NewLine + Environment.NewLine + Environment.NewLine;


            cmd.Connection.Close();
            clearInputFields();
            displayPatients(dbType);
        }
        catch (Exception ex)
        {
            txtMsg.Text = "\r\nError adding patient\r\n";
            txtMsg.Text += ex.ToString();
        }
    }
    protected void btnDeletePatient_Click(object sender, EventArgs e)
    {
        try
        {
            IDbCommand cmd = ConnectionFactory.GetCommand(dbType);
            BuildDeletePatientCommand(cmd);
            cmd.Connection.Open();

            int numRowsAffected = cmd.ExecuteNonQuery();

            txtMsg.Text += "IDbConnection.State: " + cmd.Connection.State.ToString() + Environment.NewLine; ;
            txtMsg.Text += "Num rows affected: " + numRowsAffected + Environment.NewLine;
            txtMsg.Text += "cmd.CommandText: " + cmd.CommandText + Environment.NewLine + Environment.NewLine + Environment.NewLine;

            cmd.Connection.Close();
            clearInputFields();
            displayPatients(dbType);
        }
        catch (Exception ex)
        {
            txtMsg.Text = "\r\nError deleting patient\r\n";
            txtMsg.Text += ex.ToString();
        }

    }

    protected void btnUpdatePatient_Click(object sender, EventArgs e)
    {
        try
        {
            IDbCommand cmd = ConnectionFactory.GetCommand(dbType);
            BuildUpdatePatientCommand(cmd);
            cmd.Connection.Open();

            int numRowsAffected = cmd.ExecuteNonQuery();

            txtMsg.Text += "IDbConnection.State: " + cmd.Connection.State.ToString() + Environment.NewLine; ;
            txtMsg.Text += "Num rows affected: " + numRowsAffected + Environment.NewLine;
            txtMsg.Text += "cmd.CommandText: " + cmd.CommandText + Environment.NewLine + Environment.NewLine + Environment.NewLine;

            cmd.Connection.Close();
            clearInputFields();
            displayPatients(dbType);
        }
        catch (Exception ex)
        {
            txtMsg.Text = "\r\nError updating patient\r\n";
            txtMsg.Text += ex.ToString();
        }

    }

    private void displayPatients(string dbType)
    {
        try
        {
            IDbCommand cmd = ConnectionFactory.GetCommand(dbType);
            cmd.CommandText = getSQL();
            cmd.Connection.Open();
            IDataReader dr = cmd.ExecuteReader();

            txtMsg.Text += "IDbConnection.State: " + cmd.Connection.State.ToString() + Environment.NewLine; ;
            txtMsg.Text += "IDataReader.IsClosed: " + dr.IsClosed + Environment.NewLine;
            txtMsg.Text += "cmd.CommandText: " + cmd.CommandText + Environment.NewLine + Environment.NewLine;

            txtPatients.Text = "";

            while (dr.Read())
            {
                int id = dr.GetInt32(0);
                String lname = dr.GetString(1);
                String fname = dr.GetString(2);
                String address = dr.GetString(3);

                String patient = String.Format("{0,2:0} {1,-10:0} {2,-8:0} {3,-40:0}", id, lname, fname, address);
                txtPatients.Text += patient + Environment.NewLine;
            }

            dr.Close();
            cmd.Connection.Close();

        }
        catch (Exception ex)
        {
            txtMsg.Text = "\r\nError reading data\r\n";
            txtMsg.Text += ex.ToString();
        }
    }

    private String getSQL()
    {
        String sql =
            "SELECT " +
                "Patients.PatientID, " +
                "Patients.LastName, " +
                "Patients.FirstName, " +
                "Patients.Address " +
            "FROM " +
                "Patients " +
            "ORDER BY " + "Patients.LastName Asc";

        return sql;

    }

    private void clearInputFields()
    {
        txtAddLName.Text = "";
        txtAddFName.Text = "";
        txtAddAddress.Text = "";
        txtDelID.Text = "";
        txtUpdID.Text = "";
        txtUpdLName.Text = "";
        txtUpdFName.Text = "";
        txtUpdAddress.Text = "";
    }

}