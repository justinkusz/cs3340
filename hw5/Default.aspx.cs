using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class hw5_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void gvPatients_SelectedIndexChanged(object sender, EventArgs e)
    {
        string last = gvPatients.SelectedRow.Cells[2].Text;
        string first = gvPatients.SelectedRow.Cells[3].Text;
        lblSelectedPatient.Text = last + ", " + first;
    }
    protected void btnAddPatient_Click(object sender, EventArgs e)
    {

    }
}