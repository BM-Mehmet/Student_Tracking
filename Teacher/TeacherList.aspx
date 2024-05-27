<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherList.aspx.cs" Inherits="StudentTracking.Teacher.TeacherList" %>
<%@ Register Src="~/Navbar.ascx" TagName="Navbar" TagPrefix="uc" %>
<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Teachers List</title>
    <!-- Bootstrap CSS -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
    <!-- Custom CSS -->
    <link rel="stylesheet" type="text/css" href="../Css/TeacherAdd.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
               <uc:Navbar ID="Navbar1" runat="server" />
            <h5>Teachers List</h5>
            <!-- Add Button -->
            <asp:Button ID="btnAddTeacher" runat="server" Text="Add" CssClass="btn btn-success mb-3" OnClick="btnAddTeacher_Click" />
            <asp:GridView ID="GridViewTeachers" runat="server" AutoGenerateColumns="False" CssClass="gridViewStyle" OnRowEditing="GridViewTeachers_RowEditing" OnRowDeleting="GridViewTeachers_RowDeleting"
                SelectedRowStyle-CssClass="selectedRow" DataKeyNames="ID">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" />
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Surname" HeaderText="Surname" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:CommandField ShowEditButton="True" ButtonType="Button" ControlStyle-CssClass="btn btn-primary" />
                    <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="Delete" ControlStyle-CssClass="btn btn-danger" />
                </Columns>
            </asp:GridView>
        </div>
    </form>

    <!-- Bootstrap JS -->
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
