using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)        //For initial page creation
        {
            ListItem[] availableCourses = buildAvailableCourseList();
            lbxAvailableClasses.DataSource = availableCourses;
            lbxAvailableClasses.DataTextField = "Text";
            lbxAvailableClasses.DataValueField = "Value";
            lbxAvailableClasses.DataBind();
        }
        lblErrHours.Visible = false;
        lblErrCourse.Visible = false;
    }
    private ListItem[] buildAvailableCourseList()
    {
        ListItem[] tempList = { new ListItem("CS 1301-4", "CS 1301-4"),
                                new ListItem("CS 1302-4", "CS 1302-4"),
                                new ListItem("CS 1303-4", "CS 1303-4"),
                                new ListItem("CS 2202-2", "CS 2202-2"),
                                new ListItem("CS 2224-2", "CS 2224-2"),
                                new ListItem("CS 3300-3", "CS 3300-3"),
                                new ListItem("CS 3301-1", "CS 3301-1"),
                                new ListItem("CS 3302-1", "CS 3302-1"),
                                new ListItem("CS 3340-3", "CS 3340-3"),
                                new ListItem("CS 4321-3", "CS 4321-3"),
                                new ListItem("CS 4322-3", "CS 4322-3")
                              };
        return tempList;
    }

    private int HoursRegistered()
    {
        int result = 0;
        foreach (ListItem course in lbxRegisteredClasses.Items)
        {
            result += Convert.ToInt16(course.Value.Split('-')[1]);
        }
        return result;
    }

    private int OptionsCost()
    {
        int result = 0;
        foreach (ListItem opt in cblOpts.Items)
        {
            if (opt.Selected)
            {
                result += Convert.ToInt16(opt.Value);
            }
        }
        return result;
    }

    private bool courseExists(String name)
    {
        bool result=false;

        foreach (ListItem course in lbxAvailableClasses.Items)
        {
            if (name.Equals(course.Value.Split('-')[0]))
            {
                result = true;
                break;
            }
        }
        foreach (ListItem course in lbxRegisteredClasses.Items)
        {
            if (name.Equals(course.Value.Split('-')[0]))
            {
                result = true;
                break;
            }
        }

        return result;
    }

    private void update()
    {
        lblHours.Text = "" + HoursRegistered();
        lblCost.Text = "$" + Convert.ToString((HoursRegistered() * 100) + OptionsCost());
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (lbxAvailableClasses.SelectedIndex > -1)
        {
            ListItem course = lbxAvailableClasses.SelectedItem;
            lbxAvailableClasses.ClearSelection();
            int hoursRegistered = HoursRegistered();
            int hours = Convert.ToInt16(course.Value.Split('-')[1]);
            if (hoursRegistered + hours < 20)
            {
                lbxAvailableClasses.Items.Remove(course);
                lbxRegisteredClasses.Items.Add(course);
            }
            else
                lblErrHours.Visible = true;
        }
        update();
    }
    protected void btnRemove_Click(object sender, EventArgs e)
    {
        if (lbxRegisteredClasses.SelectedIndex > -1)
        {
            ListItem course = lbxRegisteredClasses.SelectedItem;
            lbxRegisteredClasses.ClearSelection();
            lbxAvailableClasses.Items.Add(course);
            lbxRegisteredClasses.Items.Remove(course);
        }
        update();
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        ListItem[] availableCourses = buildAvailableCourseList();
        lbxRegisteredClasses.Items.Clear();
        lbxAvailableClasses.Items.Clear();
        lbxAvailableClasses.DataSource = availableCourses;
        lbxAvailableClasses.DataTextField = "Text";
        lbxAvailableClasses.DataValueField = "Value";
        lbxAvailableClasses.DataBind();
        cblOpts.ClearSelection();
        update();
    }
    protected void btnMkAvail_Click(object sender, EventArgs e)
    {
        String number = txtClassNum.Text;
        String credits = txtCredits.Text;

        if (courseExists(number))
        {
            lblErrCourse.Text = "Not added. Course already exists.";
            lblErrCourse.Visible = true;
        }
        else
        {
            ListItem course = new ListItem(number + "-" + credits);
            lbxAvailableClasses.Items.Add(course);
        }
    }
    protected void btnRemAvail_Click(object sender, EventArgs e)
    {
        String name = txtClassNum.Text;

        foreach (ListItem course in lbxRegisteredClasses.Items)
        {
            if (name.Equals(course.Value.Split('-')[0]))
            {
                lblErrCourse.Text = "Not removed. Course is registered for.";
                lblErrCourse.Visible = true;
                return;
            }
        }

        foreach (ListItem course in lbxAvailableClasses.Items)
        {
            if (name.Equals(course.Value.Split('-')[0]))
            {
                lbxAvailableClasses.Items.Remove(course);
                return;
            }
        }
        lblErrCourse.Text = "Course not found";
        lblErrCourse.Visible = true;
    }
}