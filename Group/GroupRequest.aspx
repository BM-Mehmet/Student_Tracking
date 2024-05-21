<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GroupRequest.aspx.cs" Inherits="StudentTracking.Group.GroupRequest" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gruba Katılma İsteği</title>
    <!-- Bootstrap CSS -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server" class="container mt-5">
        <div>
            <h2>Gruba Katıl</h2>
            <div class="form-group">
                <label for="ddlGroups" class="control-label">Grup Seç:</label>
                <asp:DropDownList ID="ddlGroups" runat="server" DataTextField="group_name" DataValueField="id" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="txtJoinMessage" class="control-label">Katılım Mesajı:</label>
                <asp:TextBox ID="txtJoinMessage" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4"></asp:TextBox>
            </div>
            <asp:Button ID="RequestJoinButton" runat="server" Text="Katılım İsteği Gönder" OnClick="RequestJoinButton_Click" CssClass="btn btn-primary" />
            <asp:Label ID="lblStatus" runat="server" Text="" ForeColor="Red" Visible="False"></asp:Label>
        </div>
    </form>
</body>
</html>
