<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentRegister.aspx.cs" Inherits="StudentTracking.Student.StudentRegister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gmail API Sample</title>
    <!-- Bootstrap CSS -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server" class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="card">
                    <div class="card-body">
                        <h2 class="card-title text-center">Gmail API ile E-posta Gönderme</h2>
                        <div class="form-group">
                            <label for="EmailTextBox">E-posta Adresi:</label>
                            <asp:TextBox ID="EmailTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <asp:Button ID="SendEmailButton" runat="server" Text="E-posta Gönder" OnClick="SendEmailButton_Click" CssClass="btn btn-primary btn-block" />
                        <p class="mt-3">
                            <asp:Label ID="InfoLabel" runat="server"></asp:Label>
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <!-- Bootstrap JS -->
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
