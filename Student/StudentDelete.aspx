<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentDelete.aspx.cs" Inherits="StudentTracking.Student.StudentDelete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Delete Student</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
        }

        .container {
            max-width: 400px;
            margin: 50px auto;
            padding: 20px;
            border: 1px solid #ccc;
            border-radius: 5px;
            background-color: #f9f9f9;
        }

        .container h1 {
            margin-top: 0;
            text-align: center;
        }

        .form-group {
            margin-bottom: 20px;
        }

        .form-group label {
            display: block;
            margin-bottom: 5px;
        }

        .form-group input[type="text"] {
            width: 100%;
            padding: 10px;
            border-radius: 5px;
            border: 1px solid #ccc;
        }

        .btn-group {
            display: flex;
            justify-content: space-between;
        }

        .btn {
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }

        .btn-danger {
            background-color: #dc3545;
            color: #fff;
        }

        .btn-danger:hover {
            background-color: #c82333;
        }

        .btn-secondary {
            background-color: #6c757d;
            color: #fff;
        }

        .btn-secondary:hover {
            background-color: #5a6268;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Öğrenci Silme</h1>
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

            <div class="btn-group">
                <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-danger" Text="Sil" OnClick="btnDelete_Click" />
                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-secondary" Text="Vazgeç" OnClick="btnCancel_Click" />
            </div>
        </div>
    </form>
</body>
</html>
