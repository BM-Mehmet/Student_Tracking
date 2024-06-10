<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherUpdate.aspx.cs" Inherits="StudentTracking.Teacher.TeacherUpdate" %>

<%@ Register Src="~/Navbar.ascx" TagName="Navbar" TagPrefix="uc" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Öğretmen Güncelleme</title>
    <!-- Bootstrap CSS -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet"/>
    <!-- Custom CSS -->
    <link rel="stylesheet" type="text/css" href="../Css/TeacherUpdate.css" />
</head>
<body>
    <uc:Navbar ID="Navbar1" runat="server" />
    <form id="form1" runat="server" class="container mt-5">
        <div class="row">
            <div class="col-md-6 offset-md-3">
                <h1 class="text-center">Öğretmen Güncelleme</h1>
                <div class="form-group">
                    <label for="txtName">Ad:</label>
                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtSurname">Soyad:</label>
                    <asp:TextBox ID="txtSurname" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtEmail">Email:</label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtPassword">Şifre:</label>
                    <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <asp:Button ID="btnUpdate" runat="server" Text="Güncelle" OnClick="btnUpdate_Click" CssClass="btn btn-primary btn-block" />
            </div>
        </div>
    </form>
    <!-- Bootstrap JS -->
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>