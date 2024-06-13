<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentAdd.aspx.cs" Inherits="StudentTracking.Student.StudentAdd" %>

<%@ Register Src="~/Navbar.ascx" TagName="Navbar" TagPrefix="uc" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add New Student</title>
    <!-- Bootstrap CSS -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <uc:Navbar ID="Navbar1" runat="server" />
    <form id="form1" runat="server" class="container mt-5">
        <div style="text-align: center">
            <div class="card-header">
                <h2 class="text-center">Yeni öğreci ekle</h2>
            </div>
        </div>

        <div class="form-group row">
            <label for="txtNewName" class="col-md-2 col-form-label">Ad:</label>
            <div class="col-md-10">
                <asp:TextBox ID="txtNewName" runat="server" CssClass="form-control" placeholder="Ad"></asp:TextBox>
            </div>
        </div>
        <div class="form-group row">
            <label for="txtNewSurname" class="col-md-2 col-form-label">Soyad:</label>
            <div class="col-md-10">
                <asp:TextBox ID="txtNewSurname" runat="server" CssClass="form-control" placeholder="Soyad"></asp:TextBox>
            </div>
        </div>
        <div class="form-group row">
            <label for="txtNewEmail" class="col-md-2 col-form-label">Email:</label>
            <div class="col-md-10">
                <asp:TextBox ID="txtNewEmail" runat="server" CssClass="form-control" placeholder="Email"></asp:TextBox>
            </div>
        </div>
        <div class="form-group row">
            <div class="offset-md-2 col-md-10">
                <asp:Button ID="btnAddStudent" runat="server" Text="Öğrenciyi Ekle" OnClick="btnAddStudent_Click" CssClass="btn btn-success" />
            </div>
        </div>
        <div class="form-group row">
            <div class="offset-md-2 col-md-10">
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
            </div>
        </div>
    </form>

    <!-- Bootstrap JS -->
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
