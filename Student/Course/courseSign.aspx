<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="courseSign.aspx.cs" Inherits="StudentTracking.Course.courseSign" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Course Sign</title>
    <!-- Bootstrap CSS -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server" class="container mt-5">
        <div class="form-group">
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" Height="35px" Width="209px" DataSourceID="EntityDataSource1"></asp:DropDownList>

        </div>
        <asp:Button ID="btnLeader" runat="server" OnClick="Leader_Click" Text="Leader" CssClass="btn btn-primary" />
        <asp:Button ID="btnMember" runat="server" OnClick="Member_Click" Text="Member" CssClass="btn btn-primary" />
    </form>

    <!-- Bootstrap JS -->
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
