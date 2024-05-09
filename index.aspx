<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="StudentTracking.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome</title>
    <!-- Bootstrap CSS -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
    <style>
        body {
            background-color: #f8f9fa;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }

        .container {
            text-align: center;
        }

        h1 {
            color: #007bff;
            margin-bottom: 30px;
        }

        .login-button {
            font-size: 16px;
            padding: 10px 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Welcome</h1>
            <div class="button-container">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Student Login" CssClass="btn btn-primary login-button" />
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Teacher Login" CssClass="btn btn-primary login-button" />
            </div>
        </div>
    </form>

    <!-- Bootstrap JS -->
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
