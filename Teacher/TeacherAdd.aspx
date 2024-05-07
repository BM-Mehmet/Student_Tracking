<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherAdd.aspx.cs" Inherits="StudentTracking.Teacher.TeacherAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Teacher</title>
    <link rel="stylesheet" type="text/css" href="../Css/TeacherAdd.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Add Teacher</h1>
            <div>
                <label for="txtName" class="label">Name:</label>
                <asp:TextBox ID="txtName" runat="server" CssClass="input"></asp:TextBox>
            </div>
            <div>
                <label for="txtSurname" class="label">Surname:</label>
                <asp:TextBox ID="txtSurname" runat="server" CssClass="input"></asp:TextBox>
            </div>
            <div>
                <label for="txtEmail" class="label">Email:</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="input"></asp:TextBox>
            </div>
            <div>
                <label for="txtPassword" class="label">Password:</label>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="input"></asp:TextBox>
            </div>

            <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
        </div>
    </form>
</body>
</html>
