<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="courseSign.aspx.cs" Inherits="StudentTracking.Course.courseSign" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <%--<asp:DropDownList ID="DropDownList1" runat="server" Height="24px" Width="209px" DataSourceID="EntityDataSource1">
        </asp:DropDownList>--%>
        <asp:DropDownList ID="DropDownList1" runat="server" Height="24px" Width="209px" DataSourceID="EntityDataSource1">
</asp:DropDownList>

        <asp:Button ID="btnLeader" runat="server" OnClick="Leader_Click" Text="Leader" />
        <asp:Button ID="btnMember" runat="server" OnClick="Member_Click" Text="Member" />
    </form>
</body>
</html>
