<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="hw5_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HW 5 - Justin Kusz</title>
</head>
<body>
    <h2>HW 5 - <a href="../default.html">Justin Kusz</a></h2>
    <h2>Patient Management System</h2>
    <hr />
    <form id="form1" runat="server">
            <div>

        <h3>Patients<asp:GridView ID="gvPatients" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="VisitID" DataSourceID="SqlDbPatients">
            <Columns>
                <asp:BoundField DataField="VisitID" HeaderText="VisitID" InsertVisible="False" ReadOnly="True" SortExpression="VisitID" />
                <asp:BoundField DataField="VisitDate" HeaderText="VisitDate" SortExpression="VisitDate" />
                <asp:BoundField DataField="Charge" HeaderText="Charge" SortExpression="Charge" />
                <asp:BoundField DataField="Notes" HeaderText="Notes" SortExpression="Notes" />
                <asp:BoundField DataField="PatientID" HeaderText="PatientID" SortExpression="PatientID" />
            </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDbPatients" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringSqlServer %>" DeleteCommand="DELETE FROM [Visits] WHERE [VisitID] = @VisitID" InsertCommand="INSERT INTO [Visits] ([VisitDate], [Charge], [Notes], [PatientID]) VALUES (@VisitDate, @Charge, @Notes, @PatientID)" SelectCommand="SELECT [VisitID], [VisitDate], [Charge], [Notes], [PatientID] FROM [Visits]" UpdateCommand="UPDATE [Visits] SET [VisitDate] = @VisitDate, [Charge] = @Charge, [Notes] = @Notes, [PatientID] = @PatientID WHERE [VisitID] = @VisitID">
                <DeleteParameters>
                    <asp:Parameter Name="VisitID" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="VisitDate" Type="DateTime" />
                    <asp:Parameter Name="Charge" Type="Decimal" />
                    <asp:Parameter Name="Notes" Type="String" />
                    <asp:Parameter Name="PatientID" Type="Int32" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="VisitDate" Type="DateTime" />
                    <asp:Parameter Name="Charge" Type="Decimal" />
                    <asp:Parameter Name="Notes" Type="String" />
                    <asp:Parameter Name="PatientID" Type="Int32" />
                    <asp:Parameter Name="VisitID" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </h3>
        <p>
            <asp:Button ID="btnAddPatient" runat="server" Text="Add Patient" />
&nbsp; Last Name
            <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
&nbsp; First Name
            <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
&nbsp; Address
            <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
        </p>
        <p>Total charges for selected patient:
            <asp:Label ID="lblTotalCharges" runat="server" ForeColor="Red"></asp:Label>
        </p>
        <p style="font-weight: 700">Visits -
            <asp:Label ID="lblSelectedPatient" runat="server" ForeColor="Red"></asp:Label>
        </p>
                <p style="font-weight: 700">
                    <asp:GridView ID="gvVisits" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="VisitID" DataSourceID="SqlDbPatients">
                        <Columns>
                            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                            <asp:BoundField DataField="VisitID" HeaderText="VisitID" InsertVisible="False" ReadOnly="True" SortExpression="VisitID" />
                            <asp:BoundField DataField="VisitDate" HeaderText="VisitDate" SortExpression="VisitDate" />
                            <asp:BoundField DataField="Charge" HeaderText="Charge" SortExpression="Charge" />
                            <asp:BoundField DataField="Notes" HeaderText="Notes" SortExpression="Notes" />
                        </Columns>
                    </asp:GridView>
        </p>
                <p style="font-weight: 700">
                    <asp:Button ID="btnAddVisit" runat="server" Text="Add Visit" />
&nbsp; Date
                    <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
&nbsp; Charge
                    <asp:TextBox ID="txtCharge" runat="server"></asp:TextBox>
&nbsp; Notes
                    <asp:TextBox ID="txtNotes" runat="server"></asp:TextBox>
        </p>
                <p style="font-weight: 700">Prescriptions -
                    <asp:Label ID="lblSelectedVisit" runat="server" ForeColor="Red"></asp:Label>
        </p>
        
    </div>
    </form>
</body>
</html>
