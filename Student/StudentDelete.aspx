<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentDelete.aspx.cs" Inherits="StudentTracking.Student.StudentDelete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Delete Student</title>
    <!-- Bootstrap CSS -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h1 class="text-center">Öğrenci Silme</h1>
            <hr />

            <div class="form-group">
                <label for="txtName">Ad:</label>
                <asp:TextBox ID="txtName" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="txtSurname">Soyad:</label>
                <asp:TextBox ID="txtSurname" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="txtEmail">E-posta:</label>
                <asp:TextBox ID="txtEmail" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="row justify-content-center">
                <div class="col-md-6">
                    <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-danger btn-block" Text="Sil" OnClick="btnDelete_Click" />
                </div>
                <div class="col-md-6">
                    <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-secondary btn-block" Text="Vazgeç" OnClick="btnCancel_Click" />
                </div>
            </div>
        </div>
    </form>

    <!-- Bootstrap JS -->
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
