<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="_default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h2>HW 3 - <a href="../default.aspx">Justin Kusz</a></h2>
    <form id="form1" runat="server">
    <div>
        <div style="border-color:black;border-width:1px;border-style:solid;">
            <p>Event Name:
                <asp:TextBox ID="txtEventName" runat="server"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="EventNameValidator" runat="server" ControlToValidate="txtEventName" ErrorMessage="Event name required." ForeColor="Red" ValidationGroup="Event">*</asp:RequiredFieldValidator>
&nbsp;Available Seat Numbers: First
                <asp:TextBox ID="txtFirstSeat" runat="server" Width="35px"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="FirstSeatValidator" runat="server" ControlToValidate="txtFirstSeat" ErrorMessage="First seat number required" ForeColor="Red" ValidationGroup="Event">*</asp:RequiredFieldValidator>
&nbsp;Last
                <asp:TextBox ID="txtLastSeat" runat="server" Width="35px"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="LastSeatValidator" runat="server" ControlToValidate="txtLastSeat" ErrorMessage="Last seat number required" ForeColor="Red" ValidationGroup="Event">*</asp:RequiredFieldValidator>
&nbsp;<asp:Button ID="btnMakeEvent" runat="server" Text="Make Event" OnClick="btnMakeEvent_Click" ValidationGroup="Event" />
            &nbsp;
            </p>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="Event" />
        </div>
        <br />
        <asp:Label ID="lblAvailTickets" runat="server" ForeColor="Red">0</asp:Label>
&nbsp;tickets available<br />
        <br />
        Name&nbsp;
        <asp:TextBox ID="txtBuyerName" runat="server"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="BuyerNameValidator" runat="server" ControlToValidate="txtBuyerName" ErrorMessage="Must specify name" ForeColor="Red" ValidationGroup="Purchase">*</asp:RequiredFieldValidator>
&nbsp;Age&nbsp;
        <asp:TextBox ID="txtBuyerAge" runat="server" Width="35px"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="BuyerAgeValidator" runat="server" ControlToValidate="txtBuyerAge" ErrorMessage="Must specify age" ForeColor="Red" ValidationGroup="Purchase">*</asp:RequiredFieldValidator>
&nbsp;Seat&nbsp;
        <asp:DropDownList ID="ddlSeats" runat="server">
        </asp:DropDownList>
&nbsp;<asp:RequiredFieldValidator ID="SeatNumValidator" runat="server" ControlToValidate="ddlSeats" ErrorMessage="Must specify seat number" ForeColor="Red" ValidationGroup="Purchase">*</asp:RequiredFieldValidator>
&nbsp;<asp:Button ID="btnPurchase" runat="server" Text="Purchase" Enabled="False" ValidationGroup="Purchase" />
&nbsp;
        <asp:Button ID="btnSummary" runat="server" Text="Event Summary" Enabled="False" />

        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ForeColor="Red" ValidationGroup="Purchase" />

    </div>
    </form>
</body>
</html>
