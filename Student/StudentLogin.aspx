<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentLogin.aspx.cs" Inherits="StudentTracking.Student.StudentLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <!-- Bootstrap CSS -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
    <!-- Font Awesome CSS -->
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css" rel="stylesheet">
    <script>
        function togglePassword() {
            var passwordField = document.getElementById('<%= TextBox2.ClientID %>');
            var icon = document.getElementById('togglePasswordIcon');
            if (passwordField.type === "password") {
                passwordField.type = "text";
                icon.classList.remove('fa-lock');
                icon.classList.add('fa-lock-open');
            } else {
                passwordField.type = "password";
                icon.classList.remove('fa-lock-open');
                icon.classList.add('fa-lock');
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server" class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title text-center">Login</h5>
                        <div class="form-group">
                            <label for="TextBox1">Student Mail:</label>
                            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"  placeholder="Example@ogr.ksu.edu.tr" ></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="TextBox2">Password:</label>
                            <div class="input-group">
                                <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                <div class="input-group-append">
                                    <div class="input-group-text">
                                        <i id="togglePasswordIcon" class="fas fa-lock"></i>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="custom-control custom-checkbox">
                                <input type="checkbox" class="custom-control-input" id="showPassword" onchange="togglePassword()">
                                <label class="custom-control-label" for="showPassword">Show Password</label>
                            </div>
                        </div>
                        <div class="text-center">
                            <asp:Button ID="LoginButton" runat="server" OnClick="LoginButton_Click" Text="Login" CssClass="btn btn-primary" />
                            <asp:Button ID="Button1" runat="server" OnClick="RegisterButton_Click" Text="Register" CssClass="btn btn-secondary" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <!-- Bootstrap JS -->
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
