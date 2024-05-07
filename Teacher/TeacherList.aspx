<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherList.aspx.cs" Inherits="StudentTracking.Teacher.TeacherList" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Teachers List</title>
    <link rel="stylesheet" type="text/css" href="../Css/TeacherList.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Teachers List</h1>
                   <asp:GridView ID="GridViewTeachers" runat="server" AutoGenerateColumns="False" CssClass="gridViewStyle" OnRowEditing="GridViewTeachers_RowEditing" OnRowDeleting="GridViewTeachers_RowDeleting"
SelectedRowStyle-CssClass="selectedRow" DataKeyNames="ID">
    <Columns>
     <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" />
     <asp:BoundField DataField="Name" HeaderText="Name" />
     <asp:BoundField DataField="Surname" HeaderText="Surname" />
     <asp:BoundField DataField="Email" HeaderText="Email" />
     <asp:CommandField ShowEditButton="True" ButtonType="Button" />
     <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="Delete" />
 </Columns>
</asp:GridView>

        </div>
    </form>
</body>
</html>