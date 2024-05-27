<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="StudentTracking.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>E-posta Gönderme Formu</title>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" class="container mt-5">
        <div class="card">
            <div class="card-body">
                <h2 class="card-title">E-posta Gönderme Formu</h2>
                <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                <div class="form-group">
                    <label for="txtRecipient">Alıcı E-posta Adresi</label>
                    <asp:TextBox ID="txtRecipient" runat="server" CssClass="form-control" placeholder="Alıcı E-posta Adresi"></asp:TextBox>
                </div>
                <asp:Button ID="btnSendEmail" runat="server" Text="Gönder" OnClick="btnSendEmail_Click" CssClass="btn btn-primary" />
            </div>
        </div>
    </form>
</body>
</html>
