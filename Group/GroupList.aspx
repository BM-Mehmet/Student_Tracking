<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GroupList.aspx.cs" Inherits="StudentTracking.Group.GroupList" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Group List</title>
    <!-- Bootstrap CSS -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server" class="container mt-5">
        <div class="card">
            <div class="card-header">
                <h1 class="text-center">Group List</h1>
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <asp:GridView ID="GridViewGroups" runat="server" AutoGenerateColumns="False" OnRowDeleting="GridViewGroups_RowDeleting" OnRowEditing="GridViewGroups_RowEditing" DataKeyNames="ID" CssClass="table">
                        <Columns>
                            <asp:BoundField DataField="group_name" HeaderText="Group Name" />
                            <asp:BoundField DataField="leader_student_id" HeaderText="Leader Student ID" />
                            <asp:BoundField DataField="program_id" HeaderText="Program ID" />
                            <asp:BoundField DataField="course_id" HeaderText="Course ID" />
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
