<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentEdit.aspx.cs" Inherits="StudentTracking.Student.StudentEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Student</title>
    <style>
        .form-group {
            margin-bottom: 10px;
            display: flex;
            align-items: center;
        }

            .form-group label {
                width: 100px;
                text-align: right;
                margin-right: 10px;
            }

            .form-group input[type="text"] {
                width: 200px;
            }

        .btn-group {
            margin-top: 10px;
            display: flex;
            align-items: center;
            margin-left: 110px; /* Input alanlarının başladığı yerin sağında butonları hizalar */
        }

            .btn-group .btn {
                margin-right: 10px;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Edit Student</h2>
            <div class="form-group">
                <label for="txtName">Name:</label>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtSurname">Surname:</label>
                <asp:TextBox ID="txtSurname" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtEmail">Email:</label>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtPassword">Password:</label>
                <asp:TextBox ID="TextPassword" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <div class="btn-group">
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="btn btn-primary" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="btn btn-secondary" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
