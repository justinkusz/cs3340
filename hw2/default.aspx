<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="_default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HW 2 - Justin Kusz</title>
</head>
<body>
    <a href="default.aspx">Home</a>
    <h1>Course Registration System</h1>
    <form id="form1" runat="server">
        <asp:CheckBoxList ID="cblOpts" runat="server" Height="16px" RepeatDirection="Horizontal" Width="410px">
            <asp:ListItem Value="1000">Dorm</asp:ListItem>
            <asp:ListItem Value="500">Meal Plan</asp:ListItem>
            <asp:ListItem Value="50">Football Tix</asp:ListItem>
        </asp:CheckBoxList>
    <table>
        <tr><td colspan="2">Available Classes</td><td>Registered Classes</td></tr>
        <tr><td>
            <asp:ListBox ID="lbxAvailableClasses" runat="server" Height="175px" Width="90px"></asp:ListBox>
            </td>
            <td style="width:auto">
                <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" CausesValidation="False" /><br />
                <asp:Button ID="btnRemove" runat="server" Text="Remove" OnClick="btnRemove_Click" CausesValidation="False" /><br />
                <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" CausesValidation="False" /><br />
                Total Hours: <asp:Label ID="lblHours" runat="server" /><br />
                Total Cost: <asp:Label ID="lblCost" runat="server" Text="" />
            </td>
            <td><asp:ListBox ID="lbxRegisteredClasses" runat="server" Height="175px" Width="90px"></asp:ListBox></td>
        </tr>
    </table>
        <br />
        <asp:Label ID="lblErrHours" runat="server" ForeColor="Red" Text="You cannot register for more than 19 hours" Visible="False"></asp:Label>
        <br />
        <br />
        Class Number:
        <asp:TextBox ID="txtClassNum" runat="server"></asp:TextBox>
&nbsp; Credits:
        <asp:TextBox ID="txtCredits" runat="server"></asp:TextBox>
        <asp:RangeValidator ID="vldRangeCredits" runat="server" ControlToValidate="txtCredits" ErrorMessage="Credits must be 1-10" ForeColor="Red" MaximumValue="10" MinimumValue="1" Type="Integer"></asp:RangeValidator>
        <br />
        <asp:Button ID="btnMkAvail" runat="server" OnClick="btnMkAvail_Click" Text="Make Available" />
&nbsp;
        <asp:Button ID="btnRemAvail" runat="server" OnClick="btnRemAvail_Click" Text="Remove from Available" />
        <br />
        <asp:Label ID="lblErrCourse" runat="server" ForeColor="Red" Visible="False"></asp:Label>
    </form>
</body>
</html>
