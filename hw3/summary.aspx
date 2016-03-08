<%@ Page Language="C#" AutoEventWireup="true" CodeFile="summary.aspx.cs" Inherits="hw3_summary" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>Ticket Holders for 
            <asp:Label ID="lblEventName" runat="server" ForeColor="Red" Font-Italic="true"></asp:Label>
        </h2>
        <p>
            <asp:Button ID="btnSellMore" runat="server" Text="Sell More Tickets" OnClick="btnSellMore_Click" />
&nbsp; Sort:<asp:RadioButtonList ID="rblSort" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="rblSort_SelectedIndexChanged" RepeatLayout="Flow">
                <asp:ListItem Selected="True" Value="purchase">Order Purchased</asp:ListItem>
                <asp:ListItem Value="name">Name</asp:ListItem>
                <asp:ListItem Value="number">Seat</asp:ListItem>
            </asp:RadioButtonList>
&nbsp;
            </p>
        <p>Remove Ticket Holder&nbsp;
            <asp:DropDownList ID="ddlBuyer" runat="server" >
            </asp:DropDownList>
&nbsp;
            <asp:Button ID="btnRemove" runat="server" Text="Remove" OnClick="btnRemove_Click" />
        </p>
        <p>
            <asp:TextBox ID="txtSummary" runat="server" Height="250px" Width="500px" TextMode="MultiLine"></asp:TextBox>
        </p>
    </div>
    </form>
</body>
</html>
