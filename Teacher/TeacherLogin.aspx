<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherLogin.aspx.cs" Inherits="StudentTracking.Teacher.TeacherLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Teacher Login</title>
    <!-- Bootstrap ve Font Awesome CSS kısmını aynı bırakabilirsiniz -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css" rel="stylesheet">
    <script>
        function togglePassword() {
            var passwordField = document.getElementById('<%= PasswordTextBox.ClientID %>');
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
                        <h5 class="card-title text-center">Teacher Login</h5>
                        <div class="form-group">
                            <label for="EmailTextBox">Teacher Email:</label>
                            <asp:TextBox ID="EmailTextBox" runat="server" CssClass="form-control" placeholder="Example@uni.edu.tr"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="PasswordTextBox">Password:</label>
                            <div class="input-group">
                                <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
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
