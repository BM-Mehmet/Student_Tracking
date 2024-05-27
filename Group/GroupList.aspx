<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GroupList.aspx.cs" Inherits="StudentTracking.Group.GroupList" %>

<%@ Register Src="~/Navbar.ascx" TagName="Navbar" TagPrefix="uc" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Group List</title>
    <!-- Bootstrap CSS -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" class="container mt-5">
        <div class="card">
            <div class="card-header">
                <h5 class="text-center">Group List</h5>
                <uc:Navbar ID="Navbar1" runat="server" />
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <asp:GridView ID="GridViewGroups" runat="server" AutoGenerateColumns="False"
                        OnRowDeleting="GridViewGroups_RowDeleting" OnRowEditing="GridViewGroups_RowEditing"
                        OnRowDataBound="GridViewGroups_RowDataBound" DataKeyNames="id" CssClass="table table-hover">
                        <Columns>
                            <asp:BoundField DataField="group_name" HeaderText="Group Name" />
                            <asp:BoundField DataField="LeaderStudentName" HeaderText="Leader Student Name" />
                            <asp:BoundField DataField="CourseName" HeaderText="Course Name" />
                            <asp:CommandField ShowEditButton="True" ButtonType="Button" ControlStyle-CssClass="btn btn-primary" />
                            <asp:CommandField ShowDeleteButton="True" ButtonType="Button" ControlStyle-CssClass="btn btn-danger" />
                            <asp:TemplateField HeaderText="Members">
                                <ItemTemplate>
                                    <asp:GridView ID="GridViewMembers" runat="server" AutoGenerateColumns="False" CssClass="table table-sm">
                                        <Columns>
                                            <asp:BoundField DataField="student_name" HeaderText="Student Name" />
                                            <asp:BoundField DataField="join_date" HeaderText="Join Date" DataFormatString="{0:yyyy-MM-dd}" />
                                            <asp:BoundField DataField="status" HeaderText="Status" />
                                        </Columns>
                                    </asp:GridView>
                                </ItemTemplate>
                            </asp:TemplateField>
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
