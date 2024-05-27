<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="courseSign.aspx.cs" Inherits="StudentTracking.Course.courseSign" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Kayıt Olunan Dersler</title>
    <!-- Bootstrap CSS -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server" class="container mt-5">
        <div class="form-group">
            <label for="DropDownList1">Ders Seçiniz:</label>
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
            </asp:DropDownList>
        </div>
        <div class="form-group">
            <asp:Button ID="btnLeader" runat="server" OnClick="Leader_Click" Text="Grup Lideri Ol" CssClass="btn btn-primary" />
            <asp:Button ID="btnMember" runat="server" OnClick="Member_Click" Text="Gruba Katıl" CssClass="btn btn-primary" />
            <asp:Button ID="btnManageRequests" runat="server" OnClick="btnManageRequests_Click" Text="Manage Join Requests" CssClass="btn btn-secondary" />
        </div>
    </form>

    <!-- Bootstrap JS -->
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
