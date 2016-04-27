<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="hw6_app.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>HW 6 - <a href="../index.html">Justin Kusz</a></h1>
        <p>Type in data seperated by spaces</p>
        <p>
            <asp:TextBox ID="txtInputData" runat="server" Height="45px" Width="509px"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="btnCalculate" runat="server" OnClick="btnCalculate_Click" Text="Calculate" />
        </p>
        <p>
            <asp:TextBox ID="txtResults" runat="server" Height="139px" TextMode="MultiLine" Width="506px"></asp:TextBox>
        </p>
    </div>
    </form>
</body>
</html>
