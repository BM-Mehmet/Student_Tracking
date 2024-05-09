<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentAdd.aspx.cs" Inherits="StudentTracking.Student.StudentAdd" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add New Student</title>
    <!-- Bootstrap CSS -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server" class="container mt-5">
        <div>
            <h1>Add New Student</h1>
            <div class="form-group row">
                <label for="txtNewName" class="col-md-2 col-form-label">Name:</label>
                <div class="col-md-10">
                    <asp:TextBox ID="txtNewName" runat="server" CssClass="form-control" placeholder="Name"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <label for="txtNewSurname" class="col-md-2 col-form-label">Surname:</label>
                <div class="col-md-10">
                    <asp:TextBox ID="txtNewSurname" runat="server" CssClass="form-control" placeholder="Surname"></asp:TextBox>
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
                    <asp:Button ID="btnAddStudent" runat="server" Text="Add Student" OnClick="btnAddStudent_Click" CssClass="btn btn-primary" />
                </div>
            </div>
        </div>
    </form>

    <!-- Bootstrap JS -->
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
