<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherManagement.aspx.cs" Inherits="StudentTracking.Teacher.TeacherManagement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Teacher Management</title>
    <link href="../Css/TeacherList.css" rel="stylesheet" type="text/css" />
    <style>
        /* Stil tanımlamaları */
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <div>
            <h1>Teacher Management</h1>

            
            <asp:Button ID="btnAddTeacher" runat="server" Text="Add Teacher" OnClick="btnAddTeacher_Click" />

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
