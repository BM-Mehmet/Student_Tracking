﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentLogin.aspx.cs" Inherits="StudentTracking.Student.StudentLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <script>
        function togglePassword() {
            var passwordField = document.getElementById('<%= TextBox2.ClientID %>');
            if (passwordField.type === "password") {
                passwordField.type = "text";
            } else {
                passwordField.type = "password";
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>
                Student Mail :
                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
            </p>
            <p>
                Password :
                <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
            </p>
            <p>
                <input type="checkbox" onchange="togglePassword()" />
                Show Password
            </p>
            <asp:Button ID="LoginButton" runat="server" OnClick="LoginButton_Click" Text="Login" CssClass="btn btn-primary" />
            <asp:Button ID="Button1" runat="server" OnClick="RegisterButton_Click" Text="Register" />
        </div>
    </form>
</body>
</html>
