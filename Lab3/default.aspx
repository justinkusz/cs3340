<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="_default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lab 3 - Justin Kusz</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Lab 3 - Justin Kusz</h2>
        <p>&nbsp;</p>
    <div>
    
    </div>
        <asp:Button ID="btnCompute" runat="server" OnClick="btnCompute_Click" Text="Square Root" />
&nbsp;
        <asp:TextBox ID="txtInput" runat="server"></asp:TextBox>
&nbsp;<asp:Label ID="lblAnswer" runat="server"></asp:Label>
        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtInput" ErrorMessage="Input must be positive" ForeColor="Red" MaximumValue="Double.MaxValue" MinimumValue="0"></asp:RangeValidator>
        <br />
        <br />
        <br />
    </form>
</body>
</html>
