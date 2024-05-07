<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GroupList.aspx.cs" Inherits="StudentTracking.Group.GroupList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Group List</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Group List</h1>
           <asp:GridView ID="GridViewGroups" runat="server" AutoGenerateColumns="False" OnRowDeleting="GridViewGroups_RowDeleting" OnRowEditing="GridViewGroups_RowEditing" DataKeyNames="ID">

                <Columns>
                    <asp:BoundField DataField="group_name" HeaderText="Group Name" />
                    <asp:BoundField DataField="leader_student_id" HeaderText="Leader Student ID" />
                    <asp:BoundField DataField="program_id" HeaderText="Program ID" />
                    <asp:BoundField DataField="course_id" HeaderText="Course ID" />
                    <asp:CommandField ShowEditButton="True" ButtonType="Button" />
                    <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="Delete" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>