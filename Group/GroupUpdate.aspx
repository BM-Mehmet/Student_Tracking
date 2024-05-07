<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GroupUpdate.aspx.cs" Inherits="StudentTracking.Group.GroupUpdate" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update Group</title>
    <link rel="stylesheet" type="text/css" href="~/Styles/GroupUpdate.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Update Group</h1>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
            <asp:TextBox ID="txtGroupName" runat="server" CssClass="form-control" placeholder="Group Name" Text='<%# Eval("GroupName") %>'></asp:TextBox>
            <asp:DropDownList ID="ddlLeaderStudent" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                <asp:ListItem Text="-- Select Leader Student --" Value=""></asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="ddlProgram" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                <asp:ListItem Text="-- Select Program --" Value=""></asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="ddlCourse" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                <asp:ListItem Text="-- Select Course --" Value=""></asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-primary" OnClick="btnUpdate_Click" />
        </div>
    </form>
</body>
</html>