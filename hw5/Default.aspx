<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="hw5_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HW 5 - Justin Kusz</title>
    <script type="text/javascript">
        function ConfirmDelete() 
        {
            return confirm("Are you sure you want to delete this entry?");
        }
    </script>
</head>
<body>
    <h2>HW 5 - <a href="../default.html">Justin Kusz</a></h2>
    <h2>Patient Management System</h2>
    <hr />
    <form id="form1" runat="server">
            <div>

        <h3>Patients<asp:GridView ID="gvPatients" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="PatientID" DataSourceID="SqlDbPatients" OnSelectedIndexChanged="gvPatients_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowEditButton="True" ShowSelectButton="True" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="gvPatientsDelButton" runat="server" CommandName="Delete" OnClientClick="return ConfirmDelete()">Delete</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="PatientID" HeaderText="PatientID" InsertVisible="False" ReadOnly="True" SortExpression="PatientID" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
            </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDbPatients" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringSqlServer %>" DeleteCommand="DELETE FROM [Patients] WHERE [PatientID] = @PatientID" InsertCommand="INSERT INTO [Patients] ([LastName], [FirstName], [Address]) VALUES (@LastName, @FirstName, @Address)" SelectCommand="SELECT [PatientID], [LastName], [FirstName], [Address] FROM [Patients]" UpdateCommand="UPDATE [Patients] SET [LastName] = @LastName, [FirstName] = @FirstName, [Address] = @Address WHERE [PatientID] = @PatientID">
                <DeleteParameters>
                    <asp:Parameter Name="PatientID" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="LastName" Type="String" />
                    <asp:Parameter Name="FirstName" Type="String" />
                    <asp:Parameter Name="Address" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="LastName" Type="String" />
                    <asp:Parameter Name="FirstName" Type="String" />
                    <asp:Parameter Name="Address" Type="String" />
                    <asp:Parameter Name="PatientID" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="dsSqlVisits" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringSqlServer %>" DeleteCommand="DELETE FROM [Visits] WHERE [VisitID] = @VisitID" InsertCommand="INSERT INTO [Visits] ([VisitDate], [Charge], [Notes]) VALUES (@VisitDate, @Charge, @Notes)" SelectCommand="SELECT [VisitID], [VisitDate], [Charge], [Notes] FROM [Visits] WHERE ([PatientID] = @PatientID)" UpdateCommand="UPDATE [Visits] SET [VisitDate] = @VisitDate, [Charge] = @Charge, [Notes] = @Notes WHERE [VisitID] = @VisitID">
                <DeleteParameters>
                    <asp:Parameter Name="VisitID" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="VisitDate" Type="DateTime" />
                    <asp:Parameter Name="Charge" Type="Decimal" />
                    <asp:Parameter Name="Notes" Type="String" />
                </InsertParameters>
                <SelectParameters>
                    <asp:ControlParameter ControlID="gvPatients" Name="PatientID" PropertyName="SelectedValue" Type="Int32" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="VisitDate" Type="DateTime" />
                    <asp:Parameter Name="Charge" Type="Decimal" />
                    <asp:Parameter Name="Notes" Type="String" />
                    <asp:Parameter Name="VisitID" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="dsSqlPrescriptions" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringSqlServer %>" DeleteCommand="DELETE FROM [Prescriptions] WHERE [PrescriptionID] = @PrescriptionID" InsertCommand="INSERT INTO [Prescriptions] ([PatientID], [VisitID], [DrugName], [Instructions]) VALUES (@PatientID, @VisitID, @DrugName, @Instructions)" SelectCommand="SELECT [PrescriptionID], [PatientID], [VisitID], [DrugName], [Instructions] FROM [Prescriptions]" UpdateCommand="UPDATE [Prescriptions] SET [PatientID] = @PatientID, [VisitID] = @VisitID, [DrugName] = @DrugName, [Instructions] = @Instructions WHERE [PrescriptionID] = @PrescriptionID">
                <DeleteParameters>
                    <asp:Parameter Name="PrescriptionID" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="PatientID" Type="Int32" />
                    <asp:Parameter Name="VisitID" Type="Int32" />
                    <asp:Parameter Name="DrugName" Type="String" />
                    <asp:Parameter Name="Instructions" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="PatientID" Type="Int32" />
                    <asp:Parameter Name="VisitID" Type="Int32" />
                    <asp:Parameter Name="DrugName" Type="String" />
                    <asp:Parameter Name="Instructions" Type="String" />
                    <asp:Parameter Name="PrescriptionID" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </h3>
        <p>
            <asp:Button ID="btnAddPatient" runat="server" Text="Add Patient" OnClick="btnAddPatient_Click" />
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
                    <asp:GridView ID="gvVisits" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="VisitID" DataSourceID="dsSqlVisits">
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
                <p style="font-weight: 700">
                    <asp:GridView ID="gvPrescriptions" runat="server" AutoGenerateColumns="False" DataKeyNames="PrescriptionID" DataSourceID="dsSqlPrescriptions">
                        <Columns>
                            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                            <asp:BoundField DataField="PrescriptionID" HeaderText="PrescriptionID" InsertVisible="False" ReadOnly="True" SortExpression="PrescriptionID" />
                            <asp:BoundField DataField="PatientID" HeaderText="PatientID" SortExpression="PatientID" />
                            <asp:BoundField DataField="VisitID" HeaderText="VisitID" SortExpression="VisitID" />
                            <asp:BoundField DataField="DrugName" HeaderText="DrugName" SortExpression="DrugName" />
                            <asp:BoundField DataField="Instructions" HeaderText="Instructions" SortExpression="Instructions" />
                        </Columns>
                    </asp:GridView>
        </p>
                <p style="font-weight: 700">
                    <asp:Button ID="btnAddPrescription" runat="server" Text="Add Prescription" />
&nbsp; Drug Name
                    <asp:TextBox ID="txtDrugName" runat="server"></asp:TextBox>
&nbsp; Instructions
                    <asp:TextBox ID="txtInstructions" runat="server"></asp:TextBox>
        </p>
        
    </div>
    </form>
</body>
</html>
