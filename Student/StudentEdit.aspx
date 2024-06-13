<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentEdit.aspx.cs" Inherits="StudentTracking.Student.StudentEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Student</title>
    <!-- Bootstrap CSS -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server" class="container mt-5">
        <div>
            <div class="card-header">
                <h2 class ="text-center">Edit Student</h2>
            </div>
            <div class="form-group row">
                <label for="txtName" class="col-md-2 col-form-label">Name:</label>
                <div class="col-md-10">
                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <label for="txtSurname" class="col-md-2 col-form-label">Surname:</label>
                <div class="col-md-10">
                    <asp:TextBox ID="txtSurname" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <label for="txtEmail" class="col-md-2 col-form-label">Email:</label>
                <div class="col-md-10">
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <label for="txtPassword" class="col-md-2 col-form-label">Password:</label>
                <div class="col-md-10">
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <div class="col-md-10 offset-md-2">
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="btn btn-primary" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="btn btn-secondary" />
                </div>
            </div>
        </div>
    </form>

    <!-- Bootstrap JS -->
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
