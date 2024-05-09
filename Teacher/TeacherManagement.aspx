<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherManagement.aspx.cs" Inherits="StudentTracking.Teacher.TeacherManagement" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Teacher Management</title>
    <!-- Bootstrap CSS -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
    <!-- Custom CSS -->
    <link href="../Css/TeacherList.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" class="container mt-5">
        <div class="row">
            <div class="col">
                <h1>Teacher Management</h1>
                <asp:Button ID="btnAddTeacher" runat="server" Text="Add Teacher" OnClick="btnAddTeacher_Click" CssClass="btn btn-primary mb-3" />
                <div class="table-responsive">
                    <asp:GridView ID="GridViewTeachers" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" OnRowEditing="GridViewTeachers_RowEditing" OnRowDeleting="GridViewTeachers_RowDeleting"
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
            </div>
        </div>
    </form>
    <!-- Bootstrap JS -->
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
